using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.SystemUserNotifys
{
    public interface ISystemUserNotifysAppService : IApplicationService
    {
        Task<PagedResultDto<SystemUserNotifyDto>> GetListAsync(GetSystemUserNotifysInput input);

        Task<SystemUserNotifyDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<SystemUserNotifyDto> CreateAsync(SystemUserNotifyCreateDto input);

        Task<SystemUserNotifyDto> UpdateAsync(Guid id, SystemUserNotifyUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemUserNotifyExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}