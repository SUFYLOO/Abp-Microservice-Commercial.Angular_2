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
using Resume.SystemUserNotifys;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.SystemUserNotifys
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.SystemUserNotifys.Default)]
    public class SystemUserNotifysAppService : ApplicationService, ISystemUserNotifysAppService
    {
        private readonly IDistributedCache<SystemUserNotifyExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ISystemUserNotifyRepository _systemUserNotifyRepository;
        private readonly SystemUserNotifyManager _systemUserNotifyManager;

        public SystemUserNotifysAppService(ISystemUserNotifyRepository systemUserNotifyRepository, SystemUserNotifyManager systemUserNotifyManager, IDistributedCache<SystemUserNotifyExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _systemUserNotifyRepository = systemUserNotifyRepository;
            _systemUserNotifyManager = systemUserNotifyManager;
        }

        public virtual async Task<PagedResultDto<SystemUserNotifyDto>> GetListAsync(GetSystemUserNotifysInput input)
        {
            var totalCount = await _systemUserNotifyRepository.GetCountAsync(input.FilterText, input.UserMainId, input.KeyId, input.KeyName, input.NotifyTypeCode, input.AppName, input.AppCode, input.TitleContents, input.Contents, input.IsRead, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _systemUserNotifyRepository.GetListAsync(input.FilterText, input.UserMainId, input.KeyId, input.KeyName, input.NotifyTypeCode, input.AppName, input.AppCode, input.TitleContents, input.Contents, input.IsRead, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SystemUserNotifyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SystemUserNotify>, List<SystemUserNotifyDto>>(items)
            };
        }

        public virtual async Task<SystemUserNotifyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<SystemUserNotify, SystemUserNotifyDto>(await _systemUserNotifyRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.SystemUserNotifys.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _systemUserNotifyRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.SystemUserNotifys.Create)]
        public virtual async Task<SystemUserNotifyDto> CreateAsync(SystemUserNotifyCreateDto input)
        {

            var systemUserNotify = await _systemUserNotifyManager.CreateAsync(
            input.UserMainId, input.KeyId, input.KeyName, input.NotifyTypeCode, input.AppName, input.AppCode, input.TitleContents, input.Contents, input.IsRead, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemUserNotify, SystemUserNotifyDto>(systemUserNotify);
        }

        [Authorize(ResumePermissions.SystemUserNotifys.Edit)]
        public virtual async Task<SystemUserNotifyDto> UpdateAsync(Guid id, SystemUserNotifyUpdateDto input)
        {

            var systemUserNotify = await _systemUserNotifyManager.UpdateAsync(
            id,
            input.UserMainId, input.KeyId, input.KeyName, input.NotifyTypeCode, input.AppName, input.AppCode, input.TitleContents, input.Contents, input.IsRead, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemUserNotify, SystemUserNotifyDto>(systemUserNotify);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemUserNotifyExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _systemUserNotifyRepository.GetListAsync(input.FilterText, input.UserMainId, input.KeyId, input.KeyName, input.NotifyTypeCode, input.AppName, input.AppCode, input.TitleContents, input.Contents, input.IsRead, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SystemUserNotify>, List<SystemUserNotifyExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SystemUserNotifys.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SystemUserNotifyExcelDownloadTokenCacheItem { Token = token },
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