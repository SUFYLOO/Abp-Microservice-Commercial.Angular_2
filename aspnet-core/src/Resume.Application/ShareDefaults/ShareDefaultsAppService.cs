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
using Resume.ShareDefaults;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareDefaults
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareDefaults.Default)]
    public class ShareDefaultsAppService : ApplicationService, IShareDefaultsAppService
    {
        private readonly IDistributedCache<ShareDefaultExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareDefaultRepository _shareDefaultRepository;
        private readonly ShareDefaultManager _shareDefaultManager;

        public ShareDefaultsAppService(IShareDefaultRepository shareDefaultRepository, ShareDefaultManager shareDefaultManager, IDistributedCache<ShareDefaultExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareDefaultRepository = shareDefaultRepository;
            _shareDefaultManager = shareDefaultManager;
        }

        public virtual async Task<PagedResultDto<ShareDefaultDto>> GetListAsync(GetShareDefaultsInput input)
        {
            var totalCount = await _shareDefaultRepository.GetCountAsync(input.FilterText, input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.FieldKey, input.FieldValue, input.ColumnTypeCode, input.FormTypeCode, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareDefaultRepository.GetListAsync(input.FilterText, input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.FieldKey, input.FieldValue, input.ColumnTypeCode, input.FormTypeCode, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareDefaultDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareDefault>, List<ShareDefaultDto>>(items)
            };
        }

        public virtual async Task<ShareDefaultDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareDefault, ShareDefaultDto>(await _shareDefaultRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareDefaults.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareDefaultRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareDefaults.Create)]
        public virtual async Task<ShareDefaultDto> CreateAsync(ShareDefaultCreateDto input)
        {

            var shareDefault = await _shareDefaultManager.CreateAsync(
            input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.FieldKey, input.FieldValue, input.ColumnTypeCode, input.FormTypeCode, input.SystemUse, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareDefault, ShareDefaultDto>(shareDefault);
        }

        [Authorize(ResumePermissions.ShareDefaults.Edit)]
        public virtual async Task<ShareDefaultDto> UpdateAsync(Guid id, ShareDefaultUpdateDto input)
        {

            var shareDefault = await _shareDefaultManager.UpdateAsync(
            id,
            input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.FieldKey, input.FieldValue, input.ColumnTypeCode, input.FormTypeCode, input.SystemUse, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareDefault, ShareDefaultDto>(shareDefault);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareDefaultExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareDefaultRepository.GetListAsync(input.FilterText, input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.FieldKey, input.FieldValue, input.ColumnTypeCode, input.FormTypeCode, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareDefault>, List<ShareDefaultExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareDefaults.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareDefaultExcelDownloadTokenCacheItem { Token = token },
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