using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareSendQueues
{
    public interface IShareSendQueuesAppService : IApplicationService
    {
        Task<PagedResultDto<ShareSendQueueDto>> GetListAsync(GetShareSendQueuesInput input);

        Task<ShareSendQueueDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareSendQueueDto> CreateAsync(ShareSendQueueCreateDto input);

        Task<ShareSendQueueDto> UpdateAsync(Guid id, ShareSendQueueUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareSendQueueExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}