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
using Resume.SystemDisplayMessages;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.SystemDisplayMessages
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.SystemDisplayMessages.Default)]
    public class SystemDisplayMessagesAppService : ApplicationService, ISystemDisplayMessagesAppService
    {
        private readonly IDistributedCache<SystemDisplayMessageExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ISystemDisplayMessageRepository _systemDisplayMessageRepository;
        private readonly SystemDisplayMessageManager _systemDisplayMessageManager;

        public SystemDisplayMessagesAppService(ISystemDisplayMessageRepository systemDisplayMessageRepository, SystemDisplayMessageManager systemDisplayMessageManager, IDistributedCache<SystemDisplayMessageExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _systemDisplayMessageRepository = systemDisplayMessageRepository;
            _systemDisplayMessageManager = systemDisplayMessageManager;
        }

        public virtual async Task<PagedResultDto<SystemDisplayMessageDto>> GetListAsync(GetSystemDisplayMessagesInput input)
        {
            var totalCount = await _systemDisplayMessageRepository.GetCountAsync(input.FilterText, input.DisplayTypeCode, input.TitleContents, input.Contents, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _systemDisplayMessageRepository.GetListAsync(input.FilterText, input.DisplayTypeCode, input.TitleContents, input.Contents, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SystemDisplayMessageDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SystemDisplayMessage>, List<SystemDisplayMessageDto>>(items)
            };
        }

        public virtual async Task<SystemDisplayMessageDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<SystemDisplayMessage, SystemDisplayMessageDto>(await _systemDisplayMessageRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.SystemDisplayMessages.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _systemDisplayMessageRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.SystemDisplayMessages.Create)]
        public virtual async Task<SystemDisplayMessageDto> CreateAsync(SystemDisplayMessageCreateDto input)
        {

            var systemDisplayMessage = await _systemDisplayMessageManager.CreateAsync(
            input.DisplayTypeCode, input.TitleContents, input.Contents, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemDisplayMessage, SystemDisplayMessageDto>(systemDisplayMessage);
        }

        [Authorize(ResumePermissions.SystemDisplayMessages.Edit)]
        public virtual async Task<SystemDisplayMessageDto> UpdateAsync(Guid id, SystemDisplayMessageUpdateDto input)
        {

            var systemDisplayMessage = await _systemDisplayMessageManager.UpdateAsync(
            id,
            input.DisplayTypeCode, input.TitleContents, input.Contents, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemDisplayMessage, SystemDisplayMessageDto>(systemDisplayMessage);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemDisplayMessageExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _systemDisplayMessageRepository.GetListAsync(input.FilterText, input.DisplayTypeCode, input.TitleContents, input.Contents, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SystemDisplayMessage>, List<SystemDisplayMessageExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SystemDisplayMessages.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SystemDisplayMessageExcelDownloadTokenCacheItem { Token = token },
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