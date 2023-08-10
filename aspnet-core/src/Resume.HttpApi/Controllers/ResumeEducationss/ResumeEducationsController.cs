using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeEducationss;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeEducationss
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeEducations")]
    [Route("api/app/resume-educationss")]

    public class ResumeEducationsController : AbpController, IResumeEducationssAppService
    {
        private readonly IResumeEducationssAppService _resumeEducationssAppService;

        public ResumeEducationsController(IResumeEducationssAppService resumeEducationssAppService)
        {
            _resumeEducationssAppService = resumeEducationssAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeEducationsDto>> GetListAsync(GetResumeEducationssInput input)
        {
            return _resumeEducationssAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeEducationsDto> GetAsync(Guid id)
        {
            return _resumeEducationssAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeEducationsDto> CreateAsync(ResumeEducationsCreateDto input)
        {
            return _resumeEducationssAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeEducationsDto> UpdateAsync(Guid id, ResumeEducationsUpdateDto input)
        {
            return _resumeEducationssAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeEducationssAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeEducationsExcelDownloadDto input)
        {
            return _resumeEducationssAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeEducationssAppService.GetDownloadTokenAsync();
        }
    }
}