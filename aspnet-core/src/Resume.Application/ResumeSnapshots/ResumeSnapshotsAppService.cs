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
using Resume.ResumeSnapshots;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeSnapshots
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeSnapshots.Default)]
    public class ResumeSnapshotsAppService : ApplicationService, IResumeSnapshotsAppService
    {
        private readonly IDistributedCache<ResumeSnapshotExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeSnapshotRepository _resumeSnapshotRepository;
        private readonly ResumeSnapshotManager _resumeSnapshotManager;

        public ResumeSnapshotsAppService(IResumeSnapshotRepository resumeSnapshotRepository, ResumeSnapshotManager resumeSnapshotManager, IDistributedCache<ResumeSnapshotExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeSnapshotRepository = resumeSnapshotRepository;
            _resumeSnapshotManager = resumeSnapshotManager;
        }

        public virtual async Task<PagedResultDto<ResumeSnapshotDto>> GetListAsync(GetResumeSnapshotsInput input)
        {
            var totalCount = await _resumeSnapshotRepository.GetCountAsync(input.FilterText, input.UserMainId, input.ResumeMainId, input.CompanyMainId, input.CompanyJobId, input.Snapshot, input.UserCompanyBindId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeSnapshotRepository.GetListAsync(input.FilterText, input.UserMainId, input.ResumeMainId, input.CompanyMainId, input.CompanyJobId, input.Snapshot, input.UserCompanyBindId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeSnapshotDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeSnapshot>, List<ResumeSnapshotDto>>(items)
            };
        }

        public virtual async Task<ResumeSnapshotDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeSnapshot, ResumeSnapshotDto>(await _resumeSnapshotRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeSnapshots.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeSnapshotRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeSnapshots.Create)]
        public virtual async Task<ResumeSnapshotDto> CreateAsync(ResumeSnapshotCreateDto input)
        {

            var resumeSnapshot = await _resumeSnapshotManager.CreateAsync(
            input.UserMainId, input.ResumeMainId, input.CompanyMainId, input.Snapshot, input.DateA, input.DateD, input.Sort, input.Status, input.CompanyJobId, input.UserCompanyBindId, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeSnapshot, ResumeSnapshotDto>(resumeSnapshot);
        }

        [Authorize(ResumePermissions.ResumeSnapshots.Edit)]
        public virtual async Task<ResumeSnapshotDto> UpdateAsync(Guid id, ResumeSnapshotUpdateDto input)
        {

            var resumeSnapshot = await _resumeSnapshotManager.UpdateAsync(
            id,
            input.UserMainId, input.ResumeMainId, input.CompanyMainId, input.Snapshot, input.DateA, input.DateD, input.Sort, input.Status, input.CompanyJobId, input.UserCompanyBindId, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeSnapshot, ResumeSnapshotDto>(resumeSnapshot);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeSnapshotExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeSnapshotRepository.GetListAsync(input.FilterText, input.UserMainId, input.ResumeMainId, input.CompanyMainId, input.CompanyJobId, input.Snapshot, input.UserCompanyBindId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeSnapshot>, List<ResumeSnapshotExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeSnapshots.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeSnapshotExcelDownloadTokenCacheItem { Token = token },
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