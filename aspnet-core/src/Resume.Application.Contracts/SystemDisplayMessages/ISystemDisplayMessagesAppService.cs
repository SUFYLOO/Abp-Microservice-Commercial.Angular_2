using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.SystemDisplayMessages
{
    public interface ISystemDisplayMessagesAppService : IApplicationService
    {
        Task<PagedResultDto<SystemDisplayMessageDto>> GetListAsync(GetSystemDisplayMessagesInput input);

        Task<SystemDisplayMessageDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<SystemDisplayMessageDto> CreateAsync(SystemDisplayMessageCreateDto input);

        Task<SystemDisplayMessageDto> UpdateAsync(Guid id, SystemDisplayMessageUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemDisplayMessageExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}