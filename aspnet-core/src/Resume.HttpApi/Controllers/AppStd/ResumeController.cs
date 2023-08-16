using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Resume.Shared;
using Resume.App.Users;
using Resume.App;
using Resume.App.Resumes;
using Resume.App.Shares;
using System.Collections.Generic;
using Resume.Permissions;
using Microsoft.AspNetCore.Authorization;
using Resume.App.Companys;
using Microsoft.AspNetCore.Http;

namespace Resume.App.Controllers.AppStd.Resumes
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Resume")]
    [Route("api-std/app/resumes")]
    [Authorize(ResumePermissions.ResumeMains.Default)]
    public class ResumeController : AbpController
    {
        private readonly IResumesAppService _resumesAppService;

        public ResumeController(IResumesAppService resumesAppService)
        {
            _resumesAppService = resumesAppService;
        }

        [HttpPost]
        [Route("GetResume")]
        [ProducesResponseType(typeof(ResumeDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeSnapshotsList")]
        [ProducesResponseType(typeof(ResumeSnapshotsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeSnapshotsListAsync(ResumeSnapshotsListInput input)
        {
            var Result = await _resumesAppService.GetResumeSnapshotsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeSnapshots")]
        [ProducesResponseType(typeof(ResumeSnapshotsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeSnapshotsAsync(ResumeSnapshotsInput input)
        {
            var Result = await _resumesAppService.GetResumeSnapshotsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeSnapshotsListKeyWords")]
        [ProducesResponseType(typeof(UpdateResumeMainNameDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeSnapshotsListAsync(ResumeSnapshotsListKeyWordsInput input)
        {
            var Result = await _resumesAppService.GetResumeSnapshotsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("UpdateResumeMainName")]
        [ProducesResponseType(typeof(UpdateResumeMainNameDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> UpdateResumeMainNameAsync(UpdateResumeMainNameInput input)
        {
            var Result = await _resumesAppService.UpdateResumeMainNameAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("UpdateResumeMainAutobiography")]
        [ProducesResponseType(typeof(UpdateResumeMainNameDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> UpdateResumeMainAutobiographyAsync(UpdateResumeMainAutobiographyInput input)
        {
            var Result = await _resumesAppService.UpdateResumeMainAutobiographyAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeSnapshots")]
        [ProducesResponseType(typeof(SaveResumeSnapshotsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeSnapshotsAsync(SaveResumeSnapshotInput input)
        {
            var Result = await _resumesAppService.SaveResumeSnapshotsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeMain")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeMainsDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeSwitch")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeSwitchAsync(SaveResumeSwitchInput input)
        {
            var Result = await _resumesAppService.SaveResumeSwitchAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeMainMain")]
        [ProducesResponseType(typeof(ResumeMainMainDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeMainMainAsync(SaveResumeMainMainInput input)
        {
            var Result = await _resumesAppService.SaveResumeMainMainAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeMainSort")]
        [ProducesResponseType(typeof(ResumeMainSortDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeMainSortAsync(SaveResumeMainSortInput input)
        {
            var Result = await _resumesAppService.SaveResumeMainSortAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;
            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("CopyResume")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> CopyResumeAsync(CopyResumeInput input)
        {
            var Result = await _resumesAppService.CopyResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;
            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeCommunication")]
        [ProducesResponseType(typeof(ResumeCommunicationsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeCommunicationsDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;
            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeDrvingLicense")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeDrvingLicensesDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeDrvingLicenseList")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(SaveResumeDrvingLicensesListInput input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeDrvingLicenseClassification")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeDrvingLicensesDto>>> SaveResumeAsync(List<ResumeDrvingLicensesClassificationDto> input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        [HttpPost]
        [Route("InsertResumeDrvingLicenseInit")]
        [ProducesResponseType(typeof(InsertResumeDrvingLicenseInitDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> InsertResumeDrvingLicenseInitAsync(InsertResumeDrvingLicenseInitInput input)
        {
            var Result = await _resumesAppService.InsertResumeDrvingLicenseInitAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeRecommender")]
        [ProducesResponseType(typeof(ResumeRecommendersDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeRecommendersDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeLanguage")]
        [ProducesResponseType(typeof(ResumeLanguagesDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeLanguagesDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeSkill")]
        [ProducesResponseType(typeof(ResumeSkillsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeSkillsDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeDependents")]
        [ProducesResponseType(typeof(ResumeDependentssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeDependentssDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeEducations")]
        [ProducesResponseType(typeof(ResumeEducationssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeEducationssDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeExperiences")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeExperiencessDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeWorks")]
        [ProducesResponseType(typeof(ResumeWorkssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveResumeAsync(ResumeWorkssDto input)
        {
            var Result = await _resumesAppService.SaveResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("DeleteResume")]
        [ProducesResponseType(typeof(DeleteDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> DeleteResumeAsync(DeleteResumeInput input)
        {
            var Result = await _resumesAppService.DeleteResumeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeMainsList")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeMainsListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeMainsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeMains")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeMainsAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeMainsAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeCommunicationsList")]
        [ProducesResponseType(typeof(ResumeCommunicationsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeCommunicationsListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeCommunicationsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeCommunicationsClassificationList")]
        [ProducesResponseType(typeof(ResumeCommunicationsClassificationDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeCommunicationsClassificationListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeCommunicationsClassificationListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeDrvingLicensesList")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeDrvingLicensesListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeDrvingLicensesListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeDrvingLicensesClassificationList")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesClassificationDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeDrvingLicensesClassificationListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeDrvingLicensesClassificationListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeRecommendersList")]
        [ProducesResponseType(typeof(ResumeRecommendersDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeRecommendersListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeRecommendersListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeLanguagesList")]
        [ProducesResponseType(typeof(ResumeLanguagesDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeLanguagesListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeLanguagesListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeLanguagesClassificationList")]
        [ProducesResponseType(typeof(ResumeLanguagesClassificationDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeLanguagesClassificationListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeLanguagesClassificationListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeSkillsList")]
        [ProducesResponseType(typeof(ResumeSkillsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeSkillsListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeSkillsListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeDependentssList")]
        [ProducesResponseType(typeof(ResumeDependentssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeDependentssListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeDependentssListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeEducationssList")]
        [ProducesResponseType(typeof(ResumeEducationssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeEducationssListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeEducationssListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeExperiencessList")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeExperiencessListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeExperiencessListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetResumeWorkssList")]
        [ProducesResponseType(typeof(ResumeWorkssDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetResumeWorkssListAsync(ResumeInput input)
        {
            var Result = await _resumesAppService.GetResumeWorkssListAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveResumeMains")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]

        public virtual Task<ResumeMainsDto> SaveResumeMainsAsync(SaveResumeMainInput input)
        {
            return _resumesAppService.SaveResumeMainsAsync(input);
        }
    }
}