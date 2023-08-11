using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ShareLanguages
{
    public interface IShareLanguagesAppService : IApplicationService
    {
        Task<PagedResultDto<ShareLanguageDto>> GetListAsync(GetShareLanguagesInput input);

        Task<ShareLanguageDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ShareLanguageDto> CreateAsync(ShareLanguageCreateDto input);

        Task<ShareLanguageDto> UpdateAsync(Guid id, ShareLanguageUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareLanguageExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}