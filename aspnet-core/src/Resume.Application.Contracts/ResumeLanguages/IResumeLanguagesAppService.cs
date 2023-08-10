using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeLanguages
{
    public interface IResumeLanguagesAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeLanguageDto>> GetListAsync(GetResumeLanguagesInput input);

        Task<ResumeLanguageDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeLanguageDto> CreateAsync(ResumeLanguageCreateDto input);

        Task<ResumeLanguageDto> UpdateAsync(Guid id, ResumeLanguageUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeLanguageExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}