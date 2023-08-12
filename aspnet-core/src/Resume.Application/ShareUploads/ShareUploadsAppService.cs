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
using Resume.ShareUploads;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareUploads
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareUploads.Default)]
    public class ShareUploadsAppService : ApplicationService, IShareUploadsAppService
    {
        private readonly IDistributedCache<ShareUploadExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareUploadRepository _shareUploadRepository;
        private readonly ShareUploadManager _shareUploadManager;

        public ShareUploadsAppService(IShareUploadRepository shareUploadRepository, ShareUploadManager shareUploadManager, IDistributedCache<ShareUploadExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareUploadRepository = shareUploadRepository;
            _shareUploadManager = shareUploadManager;
        }

        public virtual async Task<PagedResultDto<ShareUploadDto>> GetListAsync(GetShareUploadsInput input)
        {
            var totalCount = await _shareUploadRepository.GetCountAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.UploadName, input.ServerName, input.Type, input.SizeMin, input.SizeMax, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareUploadRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.UploadName, input.ServerName, input.Type, input.SizeMin, input.SizeMax, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareUploadDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareUpload>, List<ShareUploadDto>>(items)
            };
        }

        public virtual async Task<ShareUploadDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareUpload, ShareUploadDto>(await _shareUploadRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareUploads.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareUploadRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareUploads.Create)]
        public virtual async Task<ShareUploadDto> CreateAsync(ShareUploadCreateDto input)
        {

            var shareUpload = await _shareUploadManager.CreateAsync(
            input.Key1, input.Key2, input.Key3, input.UploadName, input.ServerName, input.Type, input.Size, input.SystemUse, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareUpload, ShareUploadDto>(shareUpload);
        }

        [Authorize(ResumePermissions.ShareUploads.Edit)]
        public virtual async Task<ShareUploadDto> UpdateAsync(Guid id, ShareUploadUpdateDto input)
        {

            var shareUpload = await _shareUploadManager.UpdateAsync(
            id,
            input.Key1, input.Key2, input.Key3, input.UploadName, input.ServerName, input.Type, input.Size, input.SystemUse, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ShareUpload, ShareUploadDto>(shareUpload);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareUploadExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareUploadRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.UploadName, input.ServerName, input.Type, input.SizeMin, input.SizeMax, input.SystemUse, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareUpload>, List<ShareUploadExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareUploads.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareUploadExcelDownloadTokenCacheItem { Token = token },
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