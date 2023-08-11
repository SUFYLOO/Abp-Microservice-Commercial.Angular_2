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
using Resume.ShareLanguages;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareLanguages
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareLanguages.Default)]
    public class ShareLanguagesAppService : ApplicationService, IShareLanguagesAppService
    {
        private readonly IDistributedCache<ShareLanguageExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareLanguageRepository _shareLanguageRepository;
        private readonly ShareLanguageManager _shareLanguageManager;

        public ShareLanguagesAppService(IShareLanguageRepository shareLanguageRepository, ShareLanguageManager shareLanguageManager, IDistributedCache<ShareLanguageExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareLanguageRepository = shareLanguageRepository;
            _shareLanguageManager = shareLanguageManager;
        }

        public virtual async Task<PagedResultDto<ShareLanguageDto>> GetListAsync(GetShareLanguagesInput input)
        {
            var totalCount = await _shareLanguageRepository.GetCountAsync(input.FilterText, input.Name, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareLanguageRepository.GetListAsync(input.FilterText, input.Name, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareLanguageDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareLanguage>, List<ShareLanguageDto>>(items)
            };
        }

        public virtual async Task<ShareLanguageDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareLanguage, ShareLanguageDto>(await _shareLanguageRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareLanguages.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareLanguageRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareLanguages.Create)]
        public virtual async Task<ShareLanguageDto> CreateAsync(ShareLanguageCreateDto input)
        {

            var shareLanguage = await _shareLanguageManager.CreateAsync(
            input.Name, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareLanguage, ShareLanguageDto>(shareLanguage);
        }

        [Authorize(ResumePermissions.ShareLanguages.Edit)]
        public virtual async Task<ShareLanguageDto> UpdateAsync(Guid id, ShareLanguageUpdateDto input)
        {

            var shareLanguage = await _shareLanguageManager.UpdateAsync(
            id,
            input.Name, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareLanguage, ShareLanguageDto>(shareLanguage);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareLanguageExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareLanguageRepository.GetListAsync(input.FilterText, input.Name, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareLanguage>, List<ShareLanguageExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareLanguages.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareLanguageExcelDownloadTokenCacheItem { Token = token },
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