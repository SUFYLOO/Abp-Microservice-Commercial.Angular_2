using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeExperiencesJobs
{
    public interface IResumeExperiencesJobsAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeExperiencesJobDto>> GetListAsync(GetResumeExperiencesJobsInput input);

        Task<ResumeExperiencesJobDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeExperiencesJobDto> CreateAsync(ResumeExperiencesJobCreateDto input);

        Task<ResumeExperiencesJobDto> UpdateAsync(Guid id, ResumeExperiencesJobUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeExperiencesJobExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}