using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.SystemUserNotifys;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.SystemUserNotifys
{
    [RemoteService]
    [Area("app")]
    [ControllerName("SystemUserNotify")]
    [Route("api/app/system-user-notifys")]

    public class SystemUserNotifyController : AbpController, ISystemUserNotifysAppService
    {
        private readonly ISystemUserNotifysAppService _systemUserNotifysAppService;

        public SystemUserNotifyController(ISystemUserNotifysAppService systemUserNotifysAppService)
        {
            _systemUserNotifysAppService = systemUserNotifysAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SystemUserNotifyDto>> GetListAsync(GetSystemUserNotifysInput input)
        {
            return _systemUserNotifysAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SystemUserNotifyDto> GetAsync(Guid id)
        {
            return _systemUserNotifysAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SystemUserNotifyDto> CreateAsync(SystemUserNotifyCreateDto input)
        {
            return _systemUserNotifysAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SystemUserNotifyDto> UpdateAsync(Guid id, SystemUserNotifyUpdateDto input)
        {
            return _systemUserNotifysAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _systemUserNotifysAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemUserNotifyExcelDownloadDto input)
        {
            return _systemUserNotifysAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _systemUserNotifysAppService.GetDownloadTokenAsync();
        }
    }
}