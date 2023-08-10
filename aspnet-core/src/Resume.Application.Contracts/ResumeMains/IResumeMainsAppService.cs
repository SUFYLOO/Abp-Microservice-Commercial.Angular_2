using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeMains
{
    public interface IResumeMainsAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeMainDto>> GetListAsync(GetResumeMainsInput input);

        Task<ResumeMainDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeMainDto> CreateAsync(ResumeMainCreateDto input);

        Task<ResumeMainDto> UpdateAsync(Guid id, ResumeMainUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeMainExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}