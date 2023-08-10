using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareDefaults
{
    public interface IShareDefaultsAppService : IApplicationService
    {
        Task<PagedResultDto<ShareDefaultDto>> GetListAsync(GetShareDefaultsInput input);

        Task<ShareDefaultDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareDefaultDto> CreateAsync(ShareDefaultCreateDto input);

        Task<ShareDefaultDto> UpdateAsync(Guid id, ShareDefaultUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareDefaultExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}