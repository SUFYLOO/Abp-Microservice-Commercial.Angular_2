using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareSendQueues;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareSendQueues
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareSendQueue")]
    [Route("api/app/share-send-queues")]

    public class ShareSendQueueController : AbpController, IShareSendQueuesAppService
    {
        private readonly IShareSendQueuesAppService _shareSendQueuesAppService;

        public ShareSendQueueController(IShareSendQueuesAppService shareSendQueuesAppService)
        {
            _shareSendQueuesAppService = shareSendQueuesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareSendQueueDto>> GetListAsync(GetShareSendQueuesInput input)
        {
            return _shareSendQueuesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareSendQueueDto> GetAsync(Guid id)
        {
            return _shareSendQueuesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareSendQueueDto> CreateAsync(ShareSendQueueCreateDto input)
        {
            return _shareSendQueuesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareSendQueueDto> UpdateAsync(Guid id, ShareSendQueueUpdateDto input)
        {
            return _shareSendQueuesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareSendQueuesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareSendQueueExcelDownloadDto input)
        {
            return _shareSendQueuesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareSendQueuesAppService.GetDownloadTokenAsync();
        }
    }
}