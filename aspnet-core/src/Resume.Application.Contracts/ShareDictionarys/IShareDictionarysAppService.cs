using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareDictionarys
{
    public interface IShareDictionarysAppService : IApplicationService
    {
        Task<PagedResultDto<ShareDictionaryDto>> GetListAsync(GetShareDictionarysInput input);

        Task<ShareDictionaryDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareDictionaryDto> CreateAsync(ShareDictionaryCreateDto input);

        Task<ShareDictionaryDto> UpdateAsync(Guid id, ShareDictionaryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareDictionaryExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}