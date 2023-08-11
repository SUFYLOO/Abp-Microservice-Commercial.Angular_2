using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeMains;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeMains
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeMain")]
    [Route("api/app/resume-mains")]

    public class ResumeMainController : AbpController, IResumeMainsAppService
    {
        private readonly IResumeMainsAppService _resumeMainsAppService;

        public ResumeMainController(IResumeMainsAppService resumeMainsAppService)
        {
            _resumeMainsAppService = resumeMainsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeMainDto>> GetListAsync(GetResumeMainsInput input)
        {
            return _resumeMainsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeMainDto> GetAsync(Guid id)
        {
            return _resumeMainsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeMainDto> CreateAsync(ResumeMainCreateDto input)
        {
            return _resumeMainsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeMainDto> UpdateAsync(Guid id, ResumeMainUpdateDto input)
        {
            return _resumeMainsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeMainsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeMainExcelDownloadDto input)
        {
            return _resumeMainsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeMainsAppService.GetDownloadTokenAsync();
        }
    }
}