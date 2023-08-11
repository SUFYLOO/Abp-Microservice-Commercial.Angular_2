using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeSkills
{
    public interface IResumeSkillsAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeSkillDto>> GetListAsync(GetResumeSkillsInput input);

        Task<ResumeSkillDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeSkillDto> CreateAsync(ResumeSkillCreateDto input);

        Task<ResumeSkillDto> UpdateAsync(Guid id, ResumeSkillUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeSkillExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}