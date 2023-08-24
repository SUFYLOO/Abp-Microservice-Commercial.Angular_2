using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareExtendeds
{
    public interface IShareExtendedsAppService : IApplicationService
    {
        Task<PagedResultDto<ShareExtendedDto>> GetListAsync(GetShareExtendedsInput input);

        Task<ShareExtendedDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareExtendedDto> CreateAsync(ShareExtendedCreateDto input);

        Task<ShareExtendedDto> UpdateAsync(Guid id, ShareExtendedUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareExtendedExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}