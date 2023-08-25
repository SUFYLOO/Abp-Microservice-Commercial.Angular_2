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
using Resume.CompanyJobWorkIdentities;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobWorkIdentities
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobWorkIdentities.Default)]
    public class CompanyJobWorkIdentitiesAppService : ApplicationService, ICompanyJobWorkIdentitiesAppService
    {
        private readonly IDistributedCache<CompanyJobWorkIdentityExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobWorkIdentityRepository _companyJobWorkIdentityRepository;
        private readonly CompanyJobWorkIdentityManager _companyJobWorkIdentityManager;

        public CompanyJobWorkIdentitiesAppService(ICompanyJobWorkIdentityRepository companyJobWorkIdentityRepository, CompanyJobWorkIdentityManager companyJobWorkIdentityManager, IDistributedCache<CompanyJobWorkIdentityExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobWorkIdentityRepository = companyJobWorkIdentityRepository;
            _companyJobWorkIdentityManager = companyJobWorkIdentityManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobWorkIdentityDto>> GetListAsync(GetCompanyJobWorkIdentitiesInput input)
        {
            var totalCount = await _companyJobWorkIdentityRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkIdentityCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobWorkIdentityRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkIdentityCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobWorkIdentityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobWorkIdentity>, List<CompanyJobWorkIdentityDto>>(items)
            };
        }

        public virtual async Task<CompanyJobWorkIdentityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobWorkIdentity, CompanyJobWorkIdentityDto>(await _companyJobWorkIdentityRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobWorkIdentities.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobWorkIdentityRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobWorkIdentities.Create)]
        public virtual async Task<CompanyJobWorkIdentityDto> CreateAsync(CompanyJobWorkIdentityCreateDto input)
        {

            var companyJobWorkIdentity = await _companyJobWorkIdentityManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.WorkIdentityCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobWorkIdentity, CompanyJobWorkIdentityDto>(companyJobWorkIdentity);
        }

        [Authorize(ResumePermissions.CompanyJobWorkIdentities.Edit)]
        public virtual async Task<CompanyJobWorkIdentityDto> UpdateAsync(Guid id, CompanyJobWorkIdentityUpdateDto input)
        {

            var companyJobWorkIdentity = await _companyJobWorkIdentityManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.WorkIdentityCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobWorkIdentity, CompanyJobWorkIdentityDto>(companyJobWorkIdentity);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobWorkIdentityExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobWorkIdentityRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkIdentityCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobWorkIdentity>, List<CompanyJobWorkIdentityExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobWorkIdentities.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobWorkIdentityExcelDownloadTokenCacheItem { Token = token },
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