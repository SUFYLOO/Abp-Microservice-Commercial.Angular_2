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
using Resume.CompanyJobs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobs
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobs.Default)]
    public class CompanyJobsAppService : ApplicationService, ICompanyJobsAppService
    {
        private readonly IDistributedCache<CompanyJobExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobRepository _companyJobRepository;
        private readonly CompanyJobManager _companyJobManager;

        public CompanyJobsAppService(ICompanyJobRepository companyJobRepository, CompanyJobManager companyJobManager, IDistributedCache<CompanyJobExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobRepository = companyJobRepository;
            _companyJobManager = companyJobManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobDto>> GetListAsync(GetCompanyJobsInput input)
        {
            var totalCount = await _companyJobRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.Name, input.JobTypeCode, input.JobOpen, input.MailTplId, input.SMSTplId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.Name, input.JobTypeCode, input.JobOpen, input.MailTplId, input.SMSTplId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJob>, List<CompanyJobDto>>(items)
            };
        }

        public virtual async Task<CompanyJobDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJob, CompanyJobDto>(await _companyJobRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobs.Create)]
        public virtual async Task<CompanyJobDto> CreateAsync(CompanyJobCreateDto input)
        {

            var companyJob = await _companyJobManager.CreateAsync(
            input.CompanyMainId, input.Name, input.JobTypeCode, input.JobOpen, input.MailTplId, input.SMSTplId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJob, CompanyJobDto>(companyJob);
        }

        [Authorize(ResumePermissions.CompanyJobs.Edit)]
        public virtual async Task<CompanyJobDto> UpdateAsync(Guid id, CompanyJobUpdateDto input)
        {

            var companyJob = await _companyJobManager.UpdateAsync(
            id,
            input.CompanyMainId, input.Name, input.JobTypeCode, input.JobOpen, input.MailTplId, input.SMSTplId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJob, CompanyJobDto>(companyJob);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.Name, input.JobTypeCode, input.JobOpen, input.MailTplId, input.SMSTplId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJob>, List<CompanyJobExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobExcelDownloadTokenCacheItem { Token = token },
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