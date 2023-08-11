using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.SystemColumns;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.SystemColumns
{
    [RemoteService]
    [Area("app")]
    [ControllerName("SystemColumn")]
    [Route("api/app/system-columns")]

    public class SystemColumnController : AbpController, ISystemColumnsAppService
    {
        private readonly ISystemColumnsAppService _systemColumnsAppService;

        public SystemColumnController(ISystemColumnsAppService systemColumnsAppService)
        {
            _systemColumnsAppService = systemColumnsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SystemColumnDto>> GetListAsync(GetSystemColumnsInput input)
        {
            return _systemColumnsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SystemColumnDto> GetAsync(Guid id)
        {
            return _systemColumnsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SystemColumnDto> CreateAsync(SystemColumnCreateDto input)
        {
            return _systemColumnsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SystemColumnDto> UpdateAsync(Guid id, SystemColumnUpdateDto input)
        {
            return _systemColumnsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _systemColumnsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemColumnExcelDownloadDto input)
        {
            return _systemColumnsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _systemColumnsAppService.GetDownloadTokenAsync();
        }
    }
}