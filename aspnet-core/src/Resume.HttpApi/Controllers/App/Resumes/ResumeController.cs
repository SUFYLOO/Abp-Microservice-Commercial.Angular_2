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
using Microsoft.AspNetCore.Http;

namespace Resume.App.Controllers.App.Resumes
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Resume")]
    [Route("api/app/resumes")]
    [Authorize(ResumePermissions.ResumeMains.Default)]
    public class ResumeController : AbpController, IResumesAppService
    {
        private readonly IResumesAppService _resumesAppService;

        public ResumeController(IResumesAppService resumesAppService)
        {
            _resumesAppService = resumesAppService;
        }

        [HttpPost]
        [Route("GetResume")]
        [ProducesResponseType(typeof(ResumeDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeDto>> GetResumeAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeAsync(input);
        }

        [HttpPost]
        [Route("GetResumeSnapshotsList")]
        [ProducesResponseType(typeof(ResumeSnapshotsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeSnapshotsDto>>> GetResumeSnapshotsListAsync(ResumeSnapshotsListInput input)
        {
            return _resumesAppService.GetResumeSnapshotsListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeSnapshots")]
        [ProducesResponseType(typeof(ResumeSnapshotsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeSnapshotsDto>> GetResumeSnapshotsAsync(ResumeSnapshotsInput input)
        {
            return _resumesAppService.GetResumeSnapshotsAsync(input);
        }

        [HttpPost]
        [Route("GetResumeSnapshotsListKeyWords")]
        [ProducesResponseType(typeof(ResumeSnapshotsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeSnapshotsDto>>> GetResumeSnapshotsListAsync(ResumeSnapshotsListKeyWordsInput input)
        {
            return _resumesAppService.GetResumeSnapshotsListAsync(input);
        }

        [HttpPost]
        [Route("UpdateResumeMainName")]
        [ProducesResponseType(typeof(UpdateResumeMainNameDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<UpdateResumeMainNameDto>> UpdateResumeMainNameAsync(UpdateResumeMainNameInput input)
        {
            return _resumesAppService.UpdateResumeMainNameAsync(input);
        }

        [HttpPost]
        [Route("UpdateResumeMainAutobiography")]
        [ProducesResponseType(typeof(UpdateResumeMainNameDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<UpdateResumeMainNameDto>> UpdateResumeMainAutobiographyAsync(UpdateResumeMainAutobiographyInput input)
        {
            return _resumesAppService.UpdateResumeMainAutobiographyAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeSnapshots")]
        [ProducesResponseType(typeof(SaveResumeSnapshotsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<SaveResumeSnapshotsDto>> SaveResumeSnapshotsAsync(SaveResumeSnapshotInput input)
        {
            return _resumesAppService.SaveResumeSnapshotsAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeMain")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeMainsDto>> SaveResumeAsync(ResumeMainsDto input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeSwitch")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeMainsDto>> SaveResumeSwitchAsync(SaveResumeSwitchInput input)
        {
            return _resumesAppService.SaveResumeSwitchAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeMainMain")]
        [ProducesResponseType(typeof(ResumeMainMainDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeMainMainDto>> SaveResumeMainMainAsync(SaveResumeMainMainInput input)
        {
            return _resumesAppService.SaveResumeMainMainAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeMainSort")]
        [ProducesResponseType(typeof(ResumeMainSortDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeMainSortDto>> SaveResumeMainSortAsync(SaveResumeMainSortInput input)
        {
            return _resumesAppService.SaveResumeMainSortAsync(input);
        }

        [HttpPost]
        [Route("CopyResume")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeMainsDto>> CopyResumeAsync(CopyResumeInput input)
        {
            return _resumesAppService.CopyResumeAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeCommunication")]
        [ProducesResponseType(typeof(ResumeCommunicationsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeCommunicationsDto>> SaveResumeAsync(ResumeCommunicationsDto input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeDrvingLicense")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeDrvingLicensesDto>> SaveResumeAsync(ResumeDrvingLicensesDto input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeDrvingLicenseList")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeDrvingLicensesDto>>> SaveResumeAsync(SaveResumeDrvingLicensesListInput input)
        {
            return _resumesAppService.SaveResumeAsync(input);
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
        
        public virtual Task<ResultDto<InsertResumeDrvingLicenseInitDto>> InsertResumeDrvingLicenseInitAsync(InsertResumeDrvingLicenseInitInput input)
        {
            return _resumesAppService.InsertResumeDrvingLicenseInitAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeRecommender")]
        [ProducesResponseType(typeof(ResumeRecommendersDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeRecommendersDto>> SaveResumeAsync(ResumeRecommendersDto input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeLanguage")]
        [ProducesResponseType(typeof(ResumeLanguagesDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeLanguagesDto>> SaveResumeAsync(ResumeLanguagesDto input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        //[HttpPost]
        //[Route("SaveResumeSkill")]
        //[ProducesResponseType(typeof(ResumeSkillsDto), StatusCodes.Status200OK)]
        
        //public virtual Task<ResultDto<ResumeSkillsDto>> SaveResumeAsync(ResumeSkillsDto input)
        //{
        //    return _resumesAppService.SaveResumeAsync(input);
        //}

        [HttpPost]
        [Route("SaveResumeDependents")]
        [ProducesResponseType(typeof(ResumeDependentssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeDependentssDto>> SaveResumeAsync(ResumeDependentssDto input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeEducations")]
        [ProducesResponseType(typeof(ResumeEducationssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResumeEducationssDto> SaveResumeEducationsAsync(SaveResumeEducationsInput input)
        {
            return _resumesAppService.SaveResumeEducationsAsync(input);
        }

        //[HttpPost]
        //[Route("SaveResumeExperiences")]
        //[ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]
        
        //public virtual Task<ResumeExperiencessDto> SaveResumeExperiencesAsync(SaveResumeExperiencesInput input)
        //{
        //    return _resumesAppService.SaveResumeExperiencesAsync(input);
        //}

        [HttpPost]
        [Route("SaveResumeWorks")]
        [ProducesResponseType(typeof(ResumeWorkssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<ResumeWorkssDto>> SaveResumeAsync(ResumeWorkssDto input)
        {
            return _resumesAppService.SaveResumeAsync(input);
        }

        [HttpPost]
        [Route("DeleteResume")]
        [ProducesResponseType(typeof(DeleteDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<DeleteDto>> DeleteResumeAsync(DeleteResumeInput input)
        {
            return _resumesAppService.DeleteResumeAsync(input);
        }

        [HttpPost]
        [Route("GetResumeMainList")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<List<ResumeMainsDto>> GetResumeMainListAsync(ResumeMainInput input)
        {
            return _resumesAppService.GetResumeMainListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeMains")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResumeMainsDto> GetResumeMainsAsync(GetResumeMainInput input)
        {
            return _resumesAppService.GetResumeMainsAsync(input);
        }

        [HttpPost]
        [Route("GetResumeCommunicationsList")]
        [ProducesResponseType(typeof(ResumeCommunicationsDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeCommunicationsDto>>> GetResumeCommunicationsListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeCommunicationsListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeCommunicationsClassificationList")]
        [ProducesResponseType(typeof(ResumeCommunicationsClassificationDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeCommunicationsClassificationDto>>> GetResumeCommunicationsClassificationListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeCommunicationsClassificationListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeDrvingLicensesList")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeDrvingLicensesDto>>> GetResumeDrvingLicensesListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeDrvingLicensesListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeDrvingLicensesClassificationList")]
        [ProducesResponseType(typeof(ResumeDrvingLicensesClassificationDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeDrvingLicensesClassificationDto>>> GetResumeDrvingLicensesClassificationListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeDrvingLicensesClassificationListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeRecommendersList")]
        [ProducesResponseType(typeof(ResumeRecommendersDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeRecommendersDto>>> GetResumeRecommendersListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeRecommendersListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeLanguagesList")]
        [ProducesResponseType(typeof(ResumeLanguagesDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeLanguagesDto>>> GetResumeLanguagesListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeLanguagesListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeLanguagesClassificationList")]
        [ProducesResponseType(typeof(ResumeLanguagesClassificationDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeLanguagesClassificationDto>>> GetResumeLanguagesClassificationListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeLanguagesClassificationListAsync(input);
        }

        //[HttpPost]
        //[Route("GetResumeSkillsList")]
        //[ProducesResponseType(typeof(ResumeSkillsDto), StatusCodes.Status200OK)]
        
        //public virtual Task<ResultDto<List<ResumeSkillsDto>>> GetResumeSkillsListAsync(ResumeInput input)
        //{
        //    return _resumesAppService.GetResumeSkillsListAsync(input);
        //}

        [HttpPost]
        [Route("GetResumeDependentsList")]
        [ProducesResponseType(typeof(ResumeDependentssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeDependentssDto>>> GetResumeDependentssListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeDependentssListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeEducationssList")]
        [ProducesResponseType(typeof(ResumeEducationssDto), StatusCodes.Status200OK)]

        public virtual Task<List<ResumeEducationssDto>> GetResumeEducationsListAsync(ResumeEducationsInput input)
        {
            return _resumesAppService.GetResumeEducationsListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeExperiencessList")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeExperiencessDto>>> GetResumeExperiencessListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeExperiencessListAsync(input);
        }

        [HttpPost]
        [Route("GetResumeWorkssList")]
        [ProducesResponseType(typeof(ResumeWorkssDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<List<ResumeWorkssDto>>> GetResumeWorkssListAsync(ResumeInput input)
        {
            return _resumesAppService.GetResumeWorkssListAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeMains")]
        [ProducesResponseType(typeof(ResumeMainsDto), StatusCodes.Status200OK)]

        public virtual Task<ResumeMainsDto> SaveResumeMainsAsync(SaveResumeMainInput input)
        {
            return _resumesAppService.SaveResumeMainsAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeEducationsCheck")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> SaveResumeEducationsCheckAsync(SaveResumeEducationsInput input)
        {
            return _resumesAppService.SaveResumeEducationsCheckAsync(input);
        }

        [HttpPost]
        [Route("DeleteResumeEducations")]
        [ProducesResponseType(typeof(ResumeEducationssDto), StatusCodes.Status200OK)]

        public virtual Task<ResumeEducationssDto> DeleteResumeEducationsAsync(ResumeEducationsInput input)
        {
            return _resumesAppService.DeleteResumeEducationsAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeExperiences")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<ResumeExperiencessDto> SaveResumeExperiencesAsync(SaveResumeExperiencesInput input)
        {
            return _resumesAppService.SaveResumeExperiencesAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeExperiencesCheck")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> SaveResumeExperiencesCheckAsync(SaveResumeExperiencesInput input)
        {
            return _resumesAppService.SaveResumeExperiencesCheckAsync(input);
        }

        [HttpPost]
        [Route("DeleteResumeExperiences")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<ResumeExperiencessDto> DeleteResumeExperiencesAsync(ResumeExperiencesInput input)
        {
            return _resumesAppService.DeleteResumeExperiencesAsync(input);
        }

        [HttpPost]
        [Route("UpdateResumeMainsAutobiography1")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<ResumeMainsDto> UpdateResumeMainsAutobiography1Async(UpdateResumeMainsAutobiographyInput input)
        {
            return _resumesAppService.UpdateResumeMainsAutobiography1Async(input);
        }

        [HttpPost]
        [Route("UpdateResumeMainsAutobiography1Check")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<ResultDto> UpdateResumeMainsAutobiography1CheckAsync(UpdateResumeMainsAutobiographyInput input)
        {
            return _resumesAppService.UpdateResumeMainsAutobiography1CheckAsync(input);
        }

        [HttpPost]
        [Route("GetResumeExperiencesList")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<List<ResumeExperiencessDto>> GetResumeExperiencesListAsync(ResumeExperiencesInput input)
        {
            return _resumesAppService.GetResumeExperiencesListAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeSkill")]
        [ProducesResponseType(typeof(ResumeSkillsDto), StatusCodes.Status200OK)]
        public virtual Task<ResumeSkillsDto> SaveResumeSkillAsync(SaveResumeSkillInput input)
        {
            return _resumesAppService.SaveResumeSkillAsync(input);
        }

        [HttpPost]
        [Route("SaveResumeSkillCheck")]
        [ProducesResponseType(typeof(ResultDto), StatusCodes.Status200OK)]
        public virtual Task<ResultDto> SaveResumeSkillCheckAsync(SaveResumeSkillInput input)
        {
            return _resumesAppService.SaveResumeSkillCheckAsync(input);
        }


        [HttpPost]
        [Route("GetResumeSkills")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<ResumeSkillsDto> GetResumeSkillsAsync(ResumeSkillInput input)
        {
            return _resumesAppService.GetResumeSkillsAsync(input);
        }

        [HttpPost]
        [Route("GetResumeSkillList")]
        [ProducesResponseType(typeof(ResumeExperiencessDto), StatusCodes.Status200OK)]

        public virtual Task<List<ResumeSkillsDto>> GetResumeSkillListAsync(ResumeSkillInput input)
        {
            return _resumesAppService.GetResumeSkillListAsync(input);
        }
    }
}