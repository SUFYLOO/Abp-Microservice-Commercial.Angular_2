using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.SystemUserRoles
{
    public interface ISystemUserRolesAppService : IApplicationService
    {
        Task<PagedResultDto<SystemUserRoleDto>> GetListAsync(GetSystemUserRolesInput input);

        Task<SystemUserRoleDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<SystemUserRoleDto> CreateAsync(SystemUserRoleCreateDto input);

        Task<SystemUserRoleDto> UpdateAsync(Guid id, SystemUserRoleUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemUserRoleExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}