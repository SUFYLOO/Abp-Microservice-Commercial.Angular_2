using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.SystemValidates
{
    public interface ISystemValidatesAppService : IApplicationService
    {
        Task<PagedResultDto<SystemValidateDto>> GetListAsync(GetSystemValidatesInput input);

        Task<SystemValidateDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<SystemValidateDto> CreateAsync(SystemValidateCreateDto input);

        Task<SystemValidateDto> UpdateAsync(Guid id, SystemValidateUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemValidateExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}