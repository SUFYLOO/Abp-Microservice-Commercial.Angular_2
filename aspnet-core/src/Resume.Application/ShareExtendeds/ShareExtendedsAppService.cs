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
using Resume.ShareExtendeds;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareExtendeds
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareExtendeds.Default)]
    public class ShareExtendedsAppService : ApplicationService, IShareExtendedsAppService
    {
        private readonly IDistributedCache<ShareExtendedExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareExtendedRepository _shareExtendedRepository;
        private readonly ShareExtendedManager _shareExtendedManager;

        public ShareExtendedsAppService(IShareExtendedRepository shareExtendedRepository, ShareExtendedManager shareExtendedManager, IDistributedCache<ShareExtendedExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareExtendedRepository = shareExtendedRepository;
            _shareExtendedManager = shareExtendedManager;
        }

        public virtual async Task<PagedResultDto<ShareExtendedDto>> GetListAsync(GetShareExtendedsInput input)
        {
            var totalCount = await _shareExtendedRepository.GetCountAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.Key4, input.Key5, input.KeyId, input.FieldValue, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareExtendedRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.Key4, input.Key5, input.KeyId, input.FieldValue, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareExtendedDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareExtended>, List<ShareExtendedDto>>(items)
            };
        }

        public virtual async Task<ShareExtendedDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareExtended, ShareExtendedDto>(await _shareExtendedRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareExtendeds.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareExtendedRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareExtendeds.Create)]
        public virtual async Task<ShareExtendedDto> CreateAsync(ShareExtendedCreateDto input)
        {

            var shareExtended = await _shareExtendedManager.CreateAsync(
            input.Key1, input.Key2, input.Key3, input.Key4, input.Key5, input.FieldValue, input.KeyId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareExtended, ShareExtendedDto>(shareExtended);
        }

        [Authorize(ResumePermissions.ShareExtendeds.Edit)]
        public virtual async Task<ShareExtendedDto> UpdateAsync(Guid id, ShareExtendedUpdateDto input)
        {

            var shareExtended = await _shareExtendedManager.UpdateAsync(
            id,
            input.Key1, input.Key2, input.Key3, input.Key4, input.Key5, input.FieldValue, input.KeyId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareExtended, ShareExtendedDto>(shareExtended);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareExtendedExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareExtendedRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.Key4, input.Key5, input.KeyId, input.FieldValue, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareExtended>, List<ShareExtendedExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareExtendeds.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareExtendedExcelDownloadTokenCacheItem { Token = token },
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