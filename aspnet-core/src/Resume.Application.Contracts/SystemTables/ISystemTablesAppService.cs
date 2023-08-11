using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.SystemTables
{
    public interface ISystemTablesAppService : IApplicationService
    {
        Task<PagedResultDto<SystemTableDto>> GetListAsync(GetSystemTablesInput input);

        Task<SystemTableDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<SystemTableDto> CreateAsync(SystemTableCreateDto input);

        Task<SystemTableDto> UpdateAsync(Guid id, SystemTableUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemTableExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}