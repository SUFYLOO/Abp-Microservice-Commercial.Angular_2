using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareCodes
{
    public interface IShareCodesAppService : IApplicationService
    {
        Task<PagedResultDto<ShareCodeDto>> GetListAsync(GetShareCodesInput input);

        Task<ShareCodeDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareCodeDto> CreateAsync(ShareCodeCreateDto input);

        Task<ShareCodeDto> UpdateAsync(Guid id, ShareCodeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareCodeExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}