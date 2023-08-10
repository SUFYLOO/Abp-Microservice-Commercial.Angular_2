using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.SystemDisplayMessages;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.SystemDisplayMessages
{
    [RemoteService]
    [Area("app")]
    [ControllerName("SystemDisplayMessage")]
    [Route("api/app/system-display-messages")]

    public class SystemDisplayMessageController : AbpController, ISystemDisplayMessagesAppService
    {
        private readonly ISystemDisplayMessagesAppService _systemDisplayMessagesAppService;

        public SystemDisplayMessageController(ISystemDisplayMessagesAppService systemDisplayMessagesAppService)
        {
            _systemDisplayMessagesAppService = systemDisplayMessagesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SystemDisplayMessageDto>> GetListAsync(GetSystemDisplayMessagesInput input)
        {
            return _systemDisplayMessagesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SystemDisplayMessageDto> GetAsync(Guid id)
        {
            return _systemDisplayMessagesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SystemDisplayMessageDto> CreateAsync(SystemDisplayMessageCreateDto input)
        {
            return _systemDisplayMessagesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SystemDisplayMessageDto> UpdateAsync(Guid id, SystemDisplayMessageUpdateDto input)
        {
            return _systemDisplayMessagesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _systemDisplayMessagesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemDisplayMessageExcelDownloadDto input)
        {
            return _systemDisplayMessagesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _systemDisplayMessagesAppService.GetDownloadTokenAsync();
        }
    }
}