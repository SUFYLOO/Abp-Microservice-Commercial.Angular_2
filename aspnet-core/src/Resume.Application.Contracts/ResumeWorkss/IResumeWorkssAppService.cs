using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeWorkss
{
    public interface IResumeWorkssAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeWorksDto>> GetListAsync(GetResumeWorkssInput input);

        Task<ResumeWorksDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeWorksDto> CreateAsync(ResumeWorksCreateDto input);

        Task<ResumeWorksDto> UpdateAsync(Guid id, ResumeWorksUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeWorksExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}