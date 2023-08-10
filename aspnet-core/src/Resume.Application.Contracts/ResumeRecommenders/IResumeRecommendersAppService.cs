using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeRecommenders
{
    public interface IResumeRecommendersAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeRecommenderDto>> GetListAsync(GetResumeRecommendersInput input);

        Task<ResumeRecommenderDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeRecommenderDto> CreateAsync(ResumeRecommenderCreateDto input);

        Task<ResumeRecommenderDto> UpdateAsync(Guid id, ResumeRecommenderUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeRecommenderExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}