using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeSnapshots
{
    public interface IResumeSnapshotsAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeSnapshotDto>> GetListAsync(GetResumeSnapshotsInput input);

        Task<ResumeSnapshotDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeSnapshotDto> CreateAsync(ResumeSnapshotCreateDto input);

        Task<ResumeSnapshotDto> UpdateAsync(Guid id, ResumeSnapshotUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeSnapshotExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}