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
using Resume.ShareSendQueues;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareSendQueues
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareSendQueues.Default)]
    public class ShareSendQueuesAppService : ApplicationService, IShareSendQueuesAppService
    {
        private readonly IDistributedCache<ShareSendQueueExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareSendQueueRepository _shareSendQueueRepository;
        private readonly ShareSendQueueManager _shareSendQueueManager;

        public ShareSendQueuesAppService(IShareSendQueueRepository shareSendQueueRepository, ShareSendQueueManager shareSendQueueManager, IDistributedCache<ShareSendQueueExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareSendQueueRepository = shareSendQueueRepository;
            _shareSendQueueManager = shareSendQueueManager;
        }

        public virtual async Task<PagedResultDto<ShareSendQueueDto>> GetListAsync(GetShareSendQueuesInput input)
        {
            var totalCount = await _shareSendQueueRepository.GetCountAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.SendTypeCode, input.FromAddr, input.ToAddr, input.TitleContents, input.Contents, input.RetryMin, input.RetryMax, input.Sucess, input.Suspend, input.DateSendMin, input.DateSendMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareSendQueueRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.SendTypeCode, input.FromAddr, input.ToAddr, input.TitleContents, input.Contents, input.RetryMin, input.RetryMax, input.Sucess, input.Suspend, input.DateSendMin, input.DateSendMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareSendQueueDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareSendQueue>, List<ShareSendQueueDto>>(items)
            };
        }

        public virtual async Task<ShareSendQueueDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareSendQueue, ShareSendQueueDto>(await _shareSendQueueRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareSendQueues.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareSendQueueRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareSendQueues.Create)]
        public virtual async Task<ShareSendQueueDto> CreateAsync(ShareSendQueueCreateDto input)
        {

            var shareSendQueue = await _shareSendQueueManager.CreateAsync(
            input.Key1, input.Key2, input.Key3, input.SendTypeCode, input.FromAddr, input.ToAddr, input.TitleContents, input.Contents, input.Retry, input.Sucess, input.Suspend, input.DateSend, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareSendQueue, ShareSendQueueDto>(shareSendQueue);
        }

        [Authorize(ResumePermissions.ShareSendQueues.Edit)]
        public virtual async Task<ShareSendQueueDto> UpdateAsync(Guid id, ShareSendQueueUpdateDto input)
        {

            var shareSendQueue = await _shareSendQueueManager.UpdateAsync(
            id,
            input.Key1, input.Key2, input.Key3, input.SendTypeCode, input.FromAddr, input.ToAddr, input.TitleContents, input.Contents, input.Retry, input.Sucess, input.Suspend, input.DateSend, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareSendQueue, ShareSendQueueDto>(shareSendQueue);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareSendQueueExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareSendQueueRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.SendTypeCode, input.FromAddr, input.ToAddr, input.TitleContents, input.Contents, input.RetryMin, input.RetryMax, input.Sucess, input.Suspend, input.DateSendMin, input.DateSendMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareSendQueue>, List<ShareSendQueueExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareSendQueues.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareSendQueueExcelDownloadTokenCacheItem { Token = token },
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