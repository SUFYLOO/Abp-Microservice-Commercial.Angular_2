using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareMessageTpls
{
    public interface IShareMessageTplsAppService : IApplicationService
    {
        Task<PagedResultDto<ShareMessageTplDto>> GetListAsync(GetShareMessageTplsInput input);

        Task<ShareMessageTplDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareMessageTplDto> CreateAsync(ShareMessageTplCreateDto input);

        Task<ShareMessageTplDto> UpdateAsync(Guid id, ShareMessageTplUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareMessageTplExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}