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
using Resume.ShareTags;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareTags
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareTags.Default)]
    public class ShareTagsAppService : ApplicationService, IShareTagsAppService
    {
        private readonly IDistributedCache<ShareTagExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareTagRepository _shareTagRepository;
        private readonly ShareTagManager _shareTagManager;

        public ShareTagsAppService(IShareTagRepository shareTagRepository, ShareTagManager shareTagManager, IDistributedCache<ShareTagExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareTagRepository = shareTagRepository;
            _shareTagManager = shareTagManager;
        }

        public virtual async Task<PagedResultDto<ShareTagDto>> GetListAsync(GetShareTagsInput input)
        {
            var totalCount = await _shareTagRepository.GetCountAsync(input.FilterText, input.ColorCode, input.Key1, input.Key2, input.Key3, input.Name, input.TagCategoryCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareTagRepository.GetListAsync(input.FilterText, input.ColorCode, input.Key1, input.Key2, input.Key3, input.Name, input.TagCategoryCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareTagDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareTag>, List<ShareTagDto>>(items)
            };
        }

        public virtual async Task<ShareTagDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareTag, ShareTagDto>(await _shareTagRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareTags.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareTagRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareTags.Create)]
        public virtual async Task<ShareTagDto> CreateAsync(ShareTagCreateDto input)
        {

            var shareTag = await _shareTagManager.CreateAsync(
            input.ColorCode, input.Key1, input.Key2, input.Key3, input.Name, input.TagCategoryCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareTag, ShareTagDto>(shareTag);
        }

        [Authorize(ResumePermissions.ShareTags.Edit)]
        public virtual async Task<ShareTagDto> UpdateAsync(Guid id, ShareTagUpdateDto input)
        {

            var shareTag = await _shareTagManager.UpdateAsync(
            id,
            input.ColorCode, input.Key1, input.Key2, input.Key3, input.Name, input.TagCategoryCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareTag, ShareTagDto>(shareTag);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareTagExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareTagRepository.GetListAsync(input.FilterText, input.ColorCode, input.Key1, input.Key2, input.Key3, input.Name, input.TagCategoryCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareTag>, List<ShareTagExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareTags.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareTagExcelDownloadTokenCacheItem { Token = token },
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