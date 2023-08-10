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
using Resume.ShareCodes;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareCodes
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareCodes.Default)]
    public class ShareCodesAppService : ApplicationService, IShareCodesAppService
    {
        private readonly IDistributedCache<ShareCodeExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareCodeRepository _shareCodeRepository;
        private readonly ShareCodeManager _shareCodeManager;

        public ShareCodesAppService(IShareCodeRepository shareCodeRepository, ShareCodeManager shareCodeManager, IDistributedCache<ShareCodeExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareCodeRepository = shareCodeRepository;
            _shareCodeManager = shareCodeManager;
        }

        public virtual async Task<PagedResultDto<ShareCodeDto>> GetListAsync(GetShareCodesInput input)
        {
            var totalCount = await _shareCodeRepository.GetCountAsync(input.FilterText, input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.Column1, input.Column2, input.Column3, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareCodeRepository.GetListAsync(input.FilterText, input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.Column1, input.Column2, input.Column3, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareCodeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareCode>, List<ShareCodeDto>>(items)
            };
        }

        public virtual async Task<ShareCodeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareCode, ShareCodeDto>(await _shareCodeRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareCodes.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareCodeRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareCodes.Create)]
        public virtual async Task<ShareCodeDto> CreateAsync(ShareCodeCreateDto input)
        {

            var shareCode = await _shareCodeManager.CreateAsync(
            input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.Column1, input.Column2, input.Column3, input.SystemUse, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareCode, ShareCodeDto>(shareCode);
        }

        [Authorize(ResumePermissions.ShareCodes.Edit)]
        public virtual async Task<ShareCodeDto> UpdateAsync(Guid id, ShareCodeUpdateDto input)
        {

            var shareCode = await _shareCodeManager.UpdateAsync(
            id,
            input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.Column1, input.Column2, input.Column3, input.SystemUse, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareCode, ShareCodeDto>(shareCode);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareCodeExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareCodeRepository.GetListAsync(input.FilterText, input.GroupCode, input.Key1, input.Key2, input.Key3, input.Name, input.Column1, input.Column2, input.Column3, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareCode>, List<ShareCodeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareCodes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareCodeExcelDownloadTokenCacheItem { Token = token },
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