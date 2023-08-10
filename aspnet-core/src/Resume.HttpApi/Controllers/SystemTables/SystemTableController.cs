using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.SystemTables;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.SystemTables
{
    [RemoteService]
    [Area("app")]
    [ControllerName("SystemTable")]
    [Route("api/app/system-tables")]

    public class SystemTableController : AbpController, ISystemTablesAppService
    {
        private readonly ISystemTablesAppService _systemTablesAppService;

        public SystemTableController(ISystemTablesAppService systemTablesAppService)
        {
            _systemTablesAppService = systemTablesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SystemTableDto>> GetListAsync(GetSystemTablesInput input)
        {
            return _systemTablesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SystemTableDto> GetAsync(Guid id)
        {
            return _systemTablesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SystemTableDto> CreateAsync(SystemTableCreateDto input)
        {
            return _systemTablesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SystemTableDto> UpdateAsync(Guid id, SystemTableUpdateDto input)
        {
            return _systemTablesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _systemTablesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemTableExcelDownloadDto input)
        {
            return _systemTablesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _systemTablesAppService.GetDownloadTokenAsync();
        }
    }
}