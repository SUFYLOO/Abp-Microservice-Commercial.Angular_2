using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeExperiencess;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeExperiencess
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeExperiences")]
    [Route("api/app/resume-experiencess")]

    public class ResumeExperiencesController : AbpController, IResumeExperiencessAppService
    {
        private readonly IResumeExperiencessAppService _resumeExperiencessAppService;

        public ResumeExperiencesController(IResumeExperiencessAppService resumeExperiencessAppService)
        {
            _resumeExperiencessAppService = resumeExperiencessAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeExperiencesDto>> GetListAsync(GetResumeExperiencessInput input)
        {
            return _resumeExperiencessAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeExperiencesDto> GetAsync(Guid id)
        {
            return _resumeExperiencessAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeExperiencesDto> CreateAsync(ResumeExperiencesCreateDto input)
        {
            return _resumeExperiencessAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeExperiencesDto> UpdateAsync(Guid id, ResumeExperiencesUpdateDto input)
        {
            return _resumeExperiencessAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeExperiencessAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeExperiencesExcelDownloadDto input)
        {
            return _resumeExperiencessAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeExperiencessAppService.GetDownloadTokenAsync();
        }
    }
}