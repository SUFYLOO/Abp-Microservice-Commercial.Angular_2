using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.SystemColumns
{
    public interface ISystemColumnsAppService : IApplicationService
    {
        Task<PagedResultDto<SystemColumnDto>> GetListAsync(GetSystemColumnsInput input);

        Task<SystemColumnDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<SystemColumnDto> CreateAsync(SystemColumnCreateDto input);

        Task<SystemColumnDto> UpdateAsync(Guid id, SystemColumnUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemColumnExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}