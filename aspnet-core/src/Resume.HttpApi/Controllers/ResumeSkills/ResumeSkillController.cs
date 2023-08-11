using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeSkills;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeSkills
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeSkill")]
    [Route("api/app/resume-skills")]

    public class ResumeSkillController : AbpController, IResumeSkillsAppService
    {
        private readonly IResumeSkillsAppService _resumeSkillsAppService;

        public ResumeSkillController(IResumeSkillsAppService resumeSkillsAppService)
        {
            _resumeSkillsAppService = resumeSkillsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeSkillDto>> GetListAsync(GetResumeSkillsInput input)
        {
            return _resumeSkillsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeSkillDto> GetAsync(Guid id)
        {
            return _resumeSkillsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeSkillDto> CreateAsync(ResumeSkillCreateDto input)
        {
            return _resumeSkillsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeSkillDto> UpdateAsync(Guid id, ResumeSkillUpdateDto input)
        {
            return _resumeSkillsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeSkillsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeSkillExcelDownloadDto input)
        {
            return _resumeSkillsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeSkillsAppService.GetDownloadTokenAsync();
        }
    }
}