using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeEducationss
{
    public interface IResumeEducationssAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeEducationsDto>> GetListAsync(GetResumeEducationssInput input);

        Task<ResumeEducationsDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeEducationsDto> CreateAsync(ResumeEducationsCreateDto input);

        Task<ResumeEducationsDto> UpdateAsync(Guid id, ResumeEducationsUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeEducationsExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}