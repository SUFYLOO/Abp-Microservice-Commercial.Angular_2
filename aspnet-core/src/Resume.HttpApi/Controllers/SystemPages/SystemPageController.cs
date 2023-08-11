using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.SystemPages;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.SystemPages
{
    [RemoteService]
    [Area("app")]
    [ControllerName("SystemPage")]
    [Route("api/app/system-pages")]

    public class SystemPageController : AbpController, ISystemPagesAppService
    {
        private readonly ISystemPagesAppService _systemPagesAppService;

        public SystemPageController(ISystemPagesAppService systemPagesAppService)
        {
            _systemPagesAppService = systemPagesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SystemPageDto>> GetListAsync(GetSystemPagesInput input)
        {
            return _systemPagesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SystemPageDto> GetAsync(Guid id)
        {
            return _systemPagesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SystemPageDto> CreateAsync(SystemPageCreateDto input)
        {
            return _systemPagesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SystemPageDto> UpdateAsync(Guid id, SystemPageUpdateDto input)
        {
            return _systemPagesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _systemPagesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemPageExcelDownloadDto input)
        {
            return _systemPagesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _systemPagesAppService.GetDownloadTokenAsync();
        }
    }
}