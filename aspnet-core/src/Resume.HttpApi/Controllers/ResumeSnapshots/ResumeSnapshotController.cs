using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeSnapshots;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeSnapshots
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeSnapshot")]
    [Route("api/app/resume-snapshots")]

    public class ResumeSnapshotController : AbpController, IResumeSnapshotsAppService
    {
        private readonly IResumeSnapshotsAppService _resumeSnapshotsAppService;

        public ResumeSnapshotController(IResumeSnapshotsAppService resumeSnapshotsAppService)
        {
            _resumeSnapshotsAppService = resumeSnapshotsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeSnapshotDto>> GetListAsync(GetResumeSnapshotsInput input)
        {
            return _resumeSnapshotsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeSnapshotDto> GetAsync(Guid id)
        {
            return _resumeSnapshotsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeSnapshotDto> CreateAsync(ResumeSnapshotCreateDto input)
        {
            return _resumeSnapshotsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeSnapshotDto> UpdateAsync(Guid id, ResumeSnapshotUpdateDto input)
        {
            return _resumeSnapshotsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeSnapshotsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeSnapshotExcelDownloadDto input)
        {
            return _resumeSnapshotsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeSnapshotsAppService.GetDownloadTokenAsync();
        }
    }
}