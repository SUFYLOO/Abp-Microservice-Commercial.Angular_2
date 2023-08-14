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
using Resume.CompanyJobPays;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobPays
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobPays.Default)]
    public class CompanyJobPaysAppService : ApplicationService, ICompanyJobPaysAppService
    {
        private readonly IDistributedCache<CompanyJobPayExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobPayRepository _companyJobPayRepository;
        private readonly CompanyJobPayManager _companyJobPayManager;

        public CompanyJobPaysAppService(ICompanyJobPayRepository companyJobPayRepository, CompanyJobPayManager companyJobPayManager, IDistributedCache<CompanyJobPayExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobPayRepository = companyJobPayRepository;
            _companyJobPayManager = companyJobPayManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobPayDto>> GetListAsync(GetCompanyJobPaysInput input)
        {
            var totalCount = await _companyJobPayRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.JobPayTypeCode, input.DateRealMin, input.DateRealMax, input.IsCancel, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobPayRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.JobPayTypeCode, input.DateRealMin, input.DateRealMax, input.IsCancel, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobPayDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobPay>, List<CompanyJobPayDto>>(items)
            };
        }

        public virtual async Task<CompanyJobPayDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobPay, CompanyJobPayDto>(await _companyJobPayRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobPays.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobPayRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobPays.Create)]
        public virtual async Task<CompanyJobPayDto> CreateAsync(CompanyJobPayCreateDto input)
        {

            var companyJobPay = await _companyJobPayManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.JobPayTypeCode, input.IsCancel, input.DateReal, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobPay, CompanyJobPayDto>(companyJobPay);
        }

        [Authorize(ResumePermissions.CompanyJobPays.Edit)]
        public virtual async Task<CompanyJobPayDto> UpdateAsync(Guid id, CompanyJobPayUpdateDto input)
        {

            var companyJobPay = await _companyJobPayManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.JobPayTypeCode, input.IsCancel, input.DateReal, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobPay, CompanyJobPayDto>(companyJobPay);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobPayExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobPayRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.JobPayTypeCode, input.DateRealMin, input.DateRealMax, input.IsCancel, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobPay>, List<CompanyJobPayExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobPays.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobPayExcelDownloadTokenCacheItem { Token = token },
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