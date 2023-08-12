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
using Resume.ShareDictionarys;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareDictionarys
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareDictionarys.Default)]
    public class ShareDictionarysAppService : ApplicationService, IShareDictionarysAppService
    {
        private readonly IDistributedCache<ShareDictionaryExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareDictionaryRepository _shareDictionaryRepository;
        private readonly ShareDictionaryManager _shareDictionaryManager;

        public ShareDictionarysAppService(IShareDictionaryRepository shareDictionaryRepository, ShareDictionaryManager shareDictionaryManager, IDistributedCache<ShareDictionaryExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareDictionaryRepository = shareDictionaryRepository;
            _shareDictionaryManager = shareDictionaryManager;
        }

        public virtual async Task<PagedResultDto<ShareDictionaryDto>> GetListAsync(GetShareDictionarysInput input)
        {
            var totalCount = await _shareDictionaryRepository.GetCountAsync(input.FilterText, input.ShareLanguageId, input.ShareTagId, input.Key1, input.Key2, input.Key3, input.Name, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareDictionaryRepository.GetListAsync(input.FilterText, input.ShareLanguageId, input.ShareTagId, input.Key1, input.Key2, input.Key3, input.Name, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareDictionaryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareDictionary>, List<ShareDictionaryDto>>(items)
            };
        }

        public virtual async Task<ShareDictionaryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareDictionary, ShareDictionaryDto>(await _shareDictionaryRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareDictionarys.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareDictionaryRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareDictionarys.Create)]
        public virtual async Task<ShareDictionaryDto> CreateAsync(ShareDictionaryCreateDto input)
        {

            var shareDictionary = await _shareDictionaryManager.CreateAsync(
            input.ShareLanguageId, input.ShareTagId, input.Key1, input.Key2, input.Key3, input.Name, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareDictionary, ShareDictionaryDto>(shareDictionary);
        }

        [Authorize(ResumePermissions.ShareDictionarys.Edit)]
        public virtual async Task<ShareDictionaryDto> UpdateAsync(Guid id, ShareDictionaryUpdateDto input)
        {

            var shareDictionary = await _shareDictionaryManager.UpdateAsync(
            id,
            input.ShareLanguageId, input.ShareTagId, input.Key1, input.Key2, input.Key3, input.Name, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareDictionary, ShareDictionaryDto>(shareDictionary);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareDictionaryExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareDictionaryRepository.GetListAsync(input.FilterText, input.ShareLanguageId, input.ShareTagId, input.Key1, input.Key2, input.Key3, input.Name, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareDictionary>, List<ShareDictionaryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareDictionarys.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareDictionaryExcelDownloadTokenCacheItem { Token = token },
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