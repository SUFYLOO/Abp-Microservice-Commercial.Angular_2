using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeCommunications
{
    public interface IResumeCommunicationsAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeCommunicationDto>> GetListAsync(GetResumeCommunicationsInput input);

        Task<ResumeCommunicationDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeCommunicationDto> CreateAsync(ResumeCommunicationCreateDto input);

        Task<ResumeCommunicationDto> UpdateAsync(Guid id, ResumeCommunicationUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeCommunicationExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}