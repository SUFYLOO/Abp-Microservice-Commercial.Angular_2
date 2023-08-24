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
using Resume.CompanyJobWorkHourss;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobWorkHourss
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobWorkHourss.Default)]
    public class CompanyJobWorkHourssAppService : ApplicationService, ICompanyJobWorkHourssAppService
    {
        private readonly IDistributedCache<CompanyJobWorkHoursExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobWorkHoursRepository _companyJobWorkHoursRepository;
        private readonly CompanyJobWorkHoursManager _companyJobWorkHoursManager;

        public CompanyJobWorkHourssAppService(ICompanyJobWorkHoursRepository companyJobWorkHoursRepository, CompanyJobWorkHoursManager companyJobWorkHoursManager, IDistributedCache<CompanyJobWorkHoursExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobWorkHoursRepository = companyJobWorkHoursRepository;
            _companyJobWorkHoursManager = companyJobWorkHoursManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobWorkHoursDto>> GetListAsync(GetCompanyJobWorkHourssInput input)
        {
            var totalCount = await _companyJobWorkHoursRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkHoursCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobWorkHoursRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkHoursCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobWorkHoursDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobWorkHours>, List<CompanyJobWorkHoursDto>>(items)
            };
        }

        public virtual async Task<CompanyJobWorkHoursDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobWorkHours, CompanyJobWorkHoursDto>(await _companyJobWorkHoursRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobWorkHourss.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobWorkHoursRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobWorkHourss.Create)]
        public virtual async Task<CompanyJobWorkHoursDto> CreateAsync(CompanyJobWorkHoursCreateDto input)
        {

            var companyJobWorkHours = await _companyJobWorkHoursManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.WorkHoursCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobWorkHours, CompanyJobWorkHoursDto>(companyJobWorkHours);
        }

        [Authorize(ResumePermissions.CompanyJobWorkHourss.Edit)]
        public virtual async Task<CompanyJobWorkHoursDto> UpdateAsync(Guid id, CompanyJobWorkHoursUpdateDto input)
        {

            var companyJobWorkHours = await _companyJobWorkHoursManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.WorkHoursCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CompanyJobWorkHours, CompanyJobWorkHoursDto>(companyJobWorkHours);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobWorkHoursExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobWorkHoursRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkHoursCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobWorkHours>, List<CompanyJobWorkHoursExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobWorkHourss.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobWorkHoursExcelDownloadTokenCacheItem { Token = token },
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