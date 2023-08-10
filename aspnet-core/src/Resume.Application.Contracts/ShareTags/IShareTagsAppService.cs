using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareTags
{
    public interface IShareTagsAppService : IApplicationService
    {
        Task<PagedResultDto<ShareTagDto>> GetListAsync(GetShareTagsInput input);

        Task<ShareTagDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareTagDto> CreateAsync(ShareTagCreateDto input);

        Task<ShareTagDto> UpdateAsync(Guid id, ShareTagUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareTagExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}