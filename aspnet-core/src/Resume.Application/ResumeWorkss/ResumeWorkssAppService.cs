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
using Resume.ResumeWorkss;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeWorkss
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeWorkss.Default)]
    public class ResumeWorkssAppService : ApplicationService, IResumeWorkssAppService
    {
        private readonly IDistributedCache<ResumeWorksExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeWorksRepository _resumeWorksRepository;
        private readonly ResumeWorksManager _resumeWorksManager;

        public ResumeWorkssAppService(IResumeWorksRepository resumeWorksRepository, ResumeWorksManager resumeWorksManager, IDistributedCache<ResumeWorksExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeWorksRepository = resumeWorksRepository;
            _resumeWorksManager = resumeWorksManager;
        }

        public virtual async Task<PagedResultDto<ResumeWorksDto>> GetListAsync(GetResumeWorkssInput input)
        {
            var totalCount = await _resumeWorksRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.Name, input.Link, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeWorksRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.Link, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeWorksDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeWorks>, List<ResumeWorksDto>>(items)
            };
        }

        public virtual async Task<ResumeWorksDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeWorks, ResumeWorksDto>(await _resumeWorksRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeWorkss.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeWorksRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeWorkss.Create)]
        public virtual async Task<ResumeWorksDto> CreateAsync(ResumeWorksCreateDto input)
        {

            var resumeWorks = await _resumeWorksManager.CreateAsync(
            input.ResumeMainId, input.Name, input.Link, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeWorks, ResumeWorksDto>(resumeWorks);
        }

        [Authorize(ResumePermissions.ResumeWorkss.Edit)]
        public virtual async Task<ResumeWorksDto> UpdateAsync(Guid id, ResumeWorksUpdateDto input)
        {

            var resumeWorks = await _resumeWorksManager.UpdateAsync(
            id,
            input.ResumeMainId, input.Name, input.Link, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeWorks, ResumeWorksDto>(resumeWorks);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeWorksExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeWorksRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.Link, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeWorks>, List<ResumeWorksExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeWorkss.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeWorksExcelDownloadTokenCacheItem { Token = token },
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