using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareUploads
{
    public interface IShareUploadsAppService : IApplicationService
    {
        Task<PagedResultDto<ShareUploadDto>> GetListAsync(GetShareUploadsInput input);

        Task<ShareUploadDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareUploadDto> CreateAsync(ShareUploadCreateDto input);

        Task<ShareUploadDto> UpdateAsync(Guid id, ShareUploadUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareUploadExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}