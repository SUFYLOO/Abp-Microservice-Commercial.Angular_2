using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeWorkss;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeWorkss
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeWorks")]
    [Route("api/app/resume-workss")]

    public class ResumeWorksController : AbpController, IResumeWorkssAppService
    {
        private readonly IResumeWorkssAppService _resumeWorkssAppService;

        public ResumeWorksController(IResumeWorkssAppService resumeWorkssAppService)
        {
            _resumeWorkssAppService = resumeWorkssAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeWorksDto>> GetListAsync(GetResumeWorkssInput input)
        {
            return _resumeWorkssAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeWorksDto> GetAsync(Guid id)
        {
            return _resumeWorkssAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeWorksDto> CreateAsync(ResumeWorksCreateDto input)
        {
            return _resumeWorkssAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeWorksDto> UpdateAsync(Guid id, ResumeWorksUpdateDto input)
        {
            return _resumeWorkssAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeWorkssAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeWorksExcelDownloadDto input)
        {
            return _resumeWorkssAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeWorkssAppService.GetDownloadTokenAsync();
        }
    }
}