using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Resume.Permissions;
using Resume.CompanyJobApplicationMethods;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobApplicationMethods
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobApplicationMethods.Default)]
    public class CompanyJobApplicationMethodsAppService : ApplicationService, ICompanyJobApplicationMethodsAppService
    {
        private readonly IDistributedCache<CompanyJobApplicationMethodExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobApplicationMethodRepository _companyJobApplicationMethodRepository;
        private readonly CompanyJobApplicationMethodManager _companyJobApplicationMethodManager;

        public CompanyJobApplicationMethodsAppService(ICompanyJobApplicationMethodRepository companyJobApplicationMethodRepository, CompanyJobApplicationMethodManager companyJobApplicationMethodManager, IDistributedCache<CompanyJobApplicationMethodExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobApplicationMethodRepository = companyJobApplicationMethodRepository;
            _companyJobApplicationMethodManager = companyJobApplicationMethodManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobApplicationMethodDto>> GetListAsync(GetCompanyJobApplicationMethodsInput input)
        {
            var totalCount = await _companyJobApplicationMethodRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OrgContactPerson, input.OrgContactMail, input.ToRespondDayMin, input.ToRespondDayMax, input.ToRespond, input.SystemSendResume, input.DisplayMail, input.Telephone, input.Personally, input.PersonallyAddress, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobApplicationMethodRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OrgContactPerson, input.OrgContactMail, input.ToRespondDayMin, input.ToRespondDayMax, input.ToRespond, input.SystemSendResume, input.DisplayMail, input.Telephone, input.Personally, input.PersonallyAddress, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobApplicationMethodDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobApplicationMethod>, List<CompanyJobApplicationMethodDto>>(items)
            };
        }

        public virtual async Task<CompanyJobApplicationMethodDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobApplicationMethod, CompanyJobApplicationMethodDto>(await _companyJobApplicationMethodRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobApplicationMethods.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobApplicationMethodRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobApplicationMethods.Create)]
        public virtual async Task<CompanyJobApplicationMethodDto> CreateAsync(CompanyJobApplicationMethodCreateDto input)
        {

            var companyJobApplicationMethod = await _companyJobApplicationMethodManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.OrgContactPerson, input.OrgContactMail, input.ToRespondDay, input.ToRespond, input.SystemSendResume, input.DisplayMail, input.Telephone, input.Personally, input.PersonallyAddress, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobApplicationMethod, CompanyJobApplicationMethodDto>(companyJobApplicationMethod);
        }

        [Authorize(ResumePermissions.CompanyJobApplicationMethods.Edit)]
        public virtual async Task<CompanyJobApplicationMethodDto> UpdateAsync(Guid id, CompanyJobApplicationMethodUpdateDto input)
        {

            var companyJobApplicationMethod = await _companyJobApplicationMethodManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.OrgContactPerson, input.OrgContactMail, input.ToRespondDay, input.ToRespond, input.SystemSendResume, input.DisplayMail, input.Telephone, input.Personally, input.PersonallyAddress, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobApplicationMethod, CompanyJobApplicationMethodDto>(companyJobApplicationMethod);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobApplicationMethodExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobApplicationMethodRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OrgContactPerson, input.OrgContactMail, input.ToRespondDayMin, input.ToRespondDayMax, input.ToRespond, input.SystemSendResume, input.DisplayMail, input.Telephone, input.Personally, input.PersonallyAddress, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobApplicationMethod>, List<CompanyJobApplicationMethodExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobApplicationMethods.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobApplicationMethodExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}