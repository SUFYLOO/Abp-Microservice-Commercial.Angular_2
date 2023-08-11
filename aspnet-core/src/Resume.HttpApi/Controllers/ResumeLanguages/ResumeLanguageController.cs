using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeLanguages;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeLanguages
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeLanguage")]
    [Route("api/app/resume-languages")]

    public class ResumeLanguageController : AbpController, IResumeLanguagesAppService
    {
        private readonly IResumeLanguagesAppService _resumeLanguagesAppService;

        public ResumeLanguageController(IResumeLanguagesAppService resumeLanguagesAppService)
        {
            _resumeLanguagesAppService = resumeLanguagesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeLanguageDto>> GetListAsync(GetResumeLanguagesInput input)
        {
            return _resumeLanguagesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeLanguageDto> GetAsync(Guid id)
        {
            return _resumeLanguagesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeLanguageDto> CreateAsync(ResumeLanguageCreateDto input)
        {
            return _resumeLanguagesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeLanguageDto> UpdateAsync(Guid id, ResumeLanguageUpdateDto input)
        {
            return _resumeLanguagesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeLanguagesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeLanguageExcelDownloadDto input)
        {
            return _resumeLanguagesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeLanguagesAppService.GetDownloadTokenAsync();
        }
    }
}