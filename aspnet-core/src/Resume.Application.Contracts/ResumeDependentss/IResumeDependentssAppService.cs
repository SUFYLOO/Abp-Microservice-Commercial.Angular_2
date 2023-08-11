using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeDependentss
{
    public interface IResumeDependentssAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeDependentsDto>> GetListAsync(GetResumeDependentssInput input);

        Task<ResumeDependentsDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeDependentsDto> CreateAsync(ResumeDependentsCreateDto input);

        Task<ResumeDependentsDto> UpdateAsync(Guid id, ResumeDependentsUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeDependentsExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}