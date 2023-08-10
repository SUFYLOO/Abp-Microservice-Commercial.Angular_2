using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.SystemValidates;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.SystemValidates
{
    [RemoteService]
    [Area("app")]
    [ControllerName("SystemValidate")]
    [Route("api/app/system-validates")]

    public class SystemValidateController : AbpController, ISystemValidatesAppService
    {
        private readonly ISystemValidatesAppService _systemValidatesAppService;

        public SystemValidateController(ISystemValidatesAppService systemValidatesAppService)
        {
            _systemValidatesAppService = systemValidatesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SystemValidateDto>> GetListAsync(GetSystemValidatesInput input)
        {
            return _systemValidatesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SystemValidateDto> GetAsync(Guid id)
        {
            return _systemValidatesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SystemValidateDto> CreateAsync(SystemValidateCreateDto input)
        {
            return _systemValidatesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SystemValidateDto> UpdateAsync(Guid id, SystemValidateUpdateDto input)
        {
            return _systemValidatesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _systemValidatesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemValidateExcelDownloadDto input)
        {
            return _systemValidatesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _systemValidatesAppService.GetDownloadTokenAsync();
        }
    }
}