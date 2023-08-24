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
using Resume.ResumeExperiencesJobs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeExperiencesJobs
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeExperiencesJobs.Default)]
    public class ResumeExperiencesJobsAppService : ApplicationService, IResumeExperiencesJobsAppService
    {
        private readonly IDistributedCache<ResumeExperiencesJobExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeExperiencesJobRepository _resumeExperiencesJobRepository;
        private readonly ResumeExperiencesJobManager _resumeExperiencesJobManager;

        public ResumeExperiencesJobsAppService(IResumeExperiencesJobRepository resumeExperiencesJobRepository, ResumeExperiencesJobManager resumeExperiencesJobManager, IDistributedCache<ResumeExperiencesJobExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeExperiencesJobRepository = resumeExperiencesJobRepository;
            _resumeExperiencesJobManager = resumeExperiencesJobManager;
        }

        public virtual async Task<PagedResultDto<ResumeExperiencesJobDto>> GetListAsync(GetResumeExperiencesJobsInput input)
        {
            var totalCount = await _resumeExperiencesJobRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.ResumeExperiencesId, input.JobType, input.YearMin, input.YearMax, input.MonthMin, input.MonthMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeExperiencesJobRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.ResumeExperiencesId, input.JobType, input.YearMin, input.YearMax, input.MonthMin, input.MonthMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeExperiencesJobDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeExperiencesJob>, List<ResumeExperiencesJobDto>>(items)
            };
        }

        public virtual async Task<ResumeExperiencesJobDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeExperiencesJob, ResumeExperiencesJobDto>(await _resumeExperiencesJobRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeExperiencesJobs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeExperiencesJobRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeExperiencesJobs.Create)]
        public virtual async Task<ResumeExperiencesJobDto> CreateAsync(ResumeExperiencesJobCreateDto input)
        {

            var resumeExperiencesJob = await _resumeExperiencesJobManager.CreateAsync(
            input.ResumeMainId, input.ResumeExperiencesId, input.JobType, input.Year, input.Month, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeExperiencesJob, ResumeExperiencesJobDto>(resumeExperiencesJob);
        }

        [Authorize(ResumePermissions.ResumeExperiencesJobs.Edit)]
        public virtual async Task<ResumeExperiencesJobDto> UpdateAsync(Guid id, ResumeExperiencesJobUpdateDto input)
        {

            var resumeExperiencesJob = await _resumeExperiencesJobManager.UpdateAsync(
            id,
            input.ResumeMainId, input.ResumeExperiencesId, input.JobType, input.Year, input.Month, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ResumeExperiencesJob, ResumeExperiencesJobDto>(resumeExperiencesJob);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeExperiencesJobExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeExperiencesJobRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.ResumeExperiencesId, input.JobType, input.YearMin, input.YearMax, input.MonthMin, input.MonthMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeExperiencesJob>, List<ResumeExperiencesJobExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeExperiencesJobs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeExperiencesJobExcelDownloadTokenCacheItem { Token = token },
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