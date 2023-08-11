using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.SystemPages
{
    public interface ISystemPagesAppService : IApplicationService
    {
        Task<PagedResultDto<SystemPageDto>> GetListAsync(GetSystemPagesInput input);

        Task<SystemPageDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<SystemPageDto> CreateAsync(SystemPageCreateDto input);

        Task<SystemPageDto> UpdateAsync(Guid id, SystemPageUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemPageExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}