using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeExperiencesJobs;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeExperiencesJobs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeExperiencesJob")]
    [Route("api/app/resume-experiences-jobs")]

    public class ResumeExperiencesJobController : AbpController, IResumeExperiencesJobsAppService
    {
        private readonly IResumeExperiencesJobsAppService _resumeExperiencesJobsAppService;

        public ResumeExperiencesJobController(IResumeExperiencesJobsAppService resumeExperiencesJobsAppService)
        {
            _resumeExperiencesJobsAppService = resumeExperiencesJobsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeExperiencesJobDto>> GetListAsync(GetResumeExperiencesJobsInput input)
        {
            return _resumeExperiencesJobsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeExperiencesJobDto> GetAsync(Guid id)
        {
            return _resumeExperiencesJobsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeExperiencesJobDto> CreateAsync(ResumeExperiencesJobCreateDto input)
        {
            return _resumeExperiencesJobsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeExperiencesJobDto> UpdateAsync(Guid id, ResumeExperiencesJobUpdateDto input)
        {
            return _resumeExperiencesJobsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeExperiencesJobsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeExperiencesJobExcelDownloadDto input)
        {
            return _resumeExperiencesJobsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeExperiencesJobsAppService.GetDownloadTokenAsync();
        }
    }
}