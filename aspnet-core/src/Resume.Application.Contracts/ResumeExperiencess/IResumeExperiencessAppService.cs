using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeExperiencess
{
    public interface IResumeExperiencessAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeExperiencesDto>> GetListAsync(GetResumeExperiencessInput input);

        Task<ResumeExperiencesDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeExperiencesDto> CreateAsync(ResumeExperiencesCreateDto input);

        Task<ResumeExperiencesDto> UpdateAsync(Guid id, ResumeExperiencesUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeExperiencesExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}