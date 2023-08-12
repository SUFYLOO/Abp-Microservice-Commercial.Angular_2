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
using Resume.ResumeMains;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeMains
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeMains.Default)]
    public class ResumeMainsAppService : ApplicationService, IResumeMainsAppService
    {
        private readonly IDistributedCache<ResumeMainExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeMainRepository _resumeMainRepository;
        private readonly ResumeMainManager _resumeMainManager;

        public ResumeMainsAppService(IResumeMainRepository resumeMainRepository, ResumeMainManager resumeMainManager, IDistributedCache<ResumeMainExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeMainRepository = resumeMainRepository;
            _resumeMainManager = resumeMainManager;
        }

        public virtual async Task<PagedResultDto<ResumeMainDto>> GetListAsync(GetResumeMainsInput input)
        {
            var totalCount = await _resumeMainRepository.GetCountAsync(input.FilterText, input.UserMainId, input.ResumeName, input.MarriageCode, input.MilitaryCode, input.DisabilityCategoryCode, input.SpecialIdentityCode, input.Main, input.Autobiography1, input.Autobiography2, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeMainRepository.GetListAsync(input.FilterText, input.UserMainId, input.ResumeName, input.MarriageCode, input.MilitaryCode, input.DisabilityCategoryCode, input.SpecialIdentityCode, input.Main, input.Autobiography1, input.Autobiography2, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeMainDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeMain>, List<ResumeMainDto>>(items)
            };
        }

        public virtual async Task<ResumeMainDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeMain, ResumeMainDto>(await _resumeMainRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeMains.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeMainRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeMains.Create)]
        public virtual async Task<ResumeMainDto> CreateAsync(ResumeMainCreateDto input)
        {

            var resumeMain = await _resumeMainManager.CreateAsync(
            input.UserMainId, input.ResumeName, input.MarriageCode, input.MilitaryCode, input.DisabilityCategoryCode, input.SpecialIdentityCode, input.Main, input.Autobiography1, input.Autobiography2, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeMain, ResumeMainDto>(resumeMain);
        }

        [Authorize(ResumePermissions.ResumeMains.Edit)]
        public virtual async Task<ResumeMainDto> UpdateAsync(Guid id, ResumeMainUpdateDto input)
        {

            var resumeMain = await _resumeMainManager.UpdateAsync(
            id,
            input.UserMainId, input.ResumeName, input.MarriageCode, input.MilitaryCode, input.DisabilityCategoryCode, input.SpecialIdentityCode, input.Main, input.Autobiography1, input.Autobiography2, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeMain, ResumeMainDto>(resumeMain);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeMainExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeMainRepository.GetListAsync(input.FilterText, input.UserMainId, input.ResumeName, input.MarriageCode, input.MilitaryCode, input.DisabilityCategoryCode, input.SpecialIdentityCode, input.Main, input.Autobiography1, input.Autobiography2, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeMain>, List<ResumeMainExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeMains.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeMainExcelDownloadTokenCacheItem { Token = token },
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