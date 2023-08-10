using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.SystemUserRoles;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.SystemUserRoles
{
    [RemoteService]
    [Area("app")]
    [ControllerName("SystemUserRole")]
    [Route("api/app/system-user-roles")]

    public class SystemUserRoleController : AbpController, ISystemUserRolesAppService
    {
        private readonly ISystemUserRolesAppService _systemUserRolesAppService;

        public SystemUserRoleController(ISystemUserRolesAppService systemUserRolesAppService)
        {
            _systemUserRolesAppService = systemUserRolesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<SystemUserRoleDto>> GetListAsync(GetSystemUserRolesInput input)
        {
            return _systemUserRolesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<SystemUserRoleDto> GetAsync(Guid id)
        {
            return _systemUserRolesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<SystemUserRoleDto> CreateAsync(SystemUserRoleCreateDto input)
        {
            return _systemUserRolesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<SystemUserRoleDto> UpdateAsync(Guid id, SystemUserRoleUpdateDto input)
        {
            return _systemUserRolesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _systemUserRolesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemUserRoleExcelDownloadDto input)
        {
            return _systemUserRolesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _systemUserRolesAppService.GetDownloadTokenAsync();
        }
    }
}