using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;
using Volo.Abp.Account;
using Resume.App.Users;
using Volo.Abp.Domain;
using System.Collections.Generic;

namespace Resume.App.Resumes
{
    public interface IResumesAppService : IApplicationService
    {
        Task<ResultDto<ResumeDto>> GetResumeAsync(ResumeInput input);
        
        
        Task<ResultDto<List<ResumeCommunicationsDto>>> GetResumeCommunicationsListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeCommunicationsClassificationDto>>> GetResumeCommunicationsClassificationListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeDrvingLicensesDto>>> GetResumeDrvingLicensesListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeDrvingLicensesClassificationDto>>> GetResumeDrvingLicensesClassificationListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeRecommendersDto>>> GetResumeRecommendersListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeLanguagesDto>>> GetResumeLanguagesListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeLanguagesClassificationDto>>> GetResumeLanguagesClassificationListAsync(ResumeInput input);
       // Task<ResultDto<List<ResumeSkillsDto>>> GetResumeSkillsListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeDependentssDto>>> GetResumeDependentssListAsync(ResumeInput input);
       // Task<ResultDto<List<ResumeEducationssDto>>> GetResumeEducationssListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeExperiencessDto>>> GetResumeExperiencessListAsync(ResumeInput input);
        Task<ResultDto<List<ResumeWorkssDto>>> GetResumeWorkssListAsync(ResumeInput input);

        Task<ResultDto<UpdateResumeMainNameDto>> UpdateResumeMainNameAsync(UpdateResumeMainNameInput input);
        Task<ResultDto<UpdateResumeMainNameDto>> UpdateResumeMainAutobiographyAsync(UpdateResumeMainAutobiographyInput input);
        Task<ResultDto<SaveResumeSnapshotsDto>> SaveResumeSnapshotsAsync(SaveResumeSnapshotInput input);
        Task<ResultDto<ResumeMainsDto>> SaveResumeAsync(ResumeMainsDto input);
        Task<ResultDto<ResumeMainsDto>> SaveResumeSwitchAsync(SaveResumeSwitchInput input);
        Task<ResultDto<ResumeMainMainDto>> SaveResumeMainMainAsync(SaveResumeMainMainInput input);
        Task<ResultDto<ResumeMainSortDto>> SaveResumeMainSortAsync(SaveResumeMainSortInput input);
        Task<ResultDto<ResumeMainsDto>> CopyResumeAsync(CopyResumeInput input);
        Task<ResultDto<ResumeCommunicationsDto>> SaveResumeAsync(ResumeCommunicationsDto input);
        Task<ResultDto<ResumeDrvingLicensesDto>> SaveResumeAsync(ResumeDrvingLicensesDto input);
        Task<ResultDto<List<ResumeDrvingLicensesDto>>> SaveResumeAsync(SaveResumeDrvingLicensesListInput input);
        Task<ResultDto<List<ResumeDrvingLicensesDto>>> SaveResumeAsync(List<ResumeDrvingLicensesClassificationDto> input);
        Task<ResultDto<ResumeRecommendersDto>> SaveResumeAsync(ResumeRecommendersDto input);
        Task<ResultDto<ResumeLanguagesDto>> SaveResumeAsync(ResumeLanguagesDto input);
        //Task<ResultDto<ResumeSkillsDto>> SaveResumeAsync(ResumeSkillsDto input);
        Task<ResultDto<ResumeDependentssDto>> SaveResumeAsync(ResumeDependentssDto input);
        
        Task<ResultDto<ResumeWorkssDto>> SaveResumeAsync(ResumeWorkssDto input);
        Task<ResultDto<DeleteDto>> DeleteResumeAsync(DeleteResumeInput input);

        Task<ResultDto<InsertResumeDrvingLicenseInitDto>> InsertResumeDrvingLicenseInitAsync(InsertResumeDrvingLicenseInitInput input);
        Task<ResultDto<List<ResumeSnapshotsDto>>> GetResumeSnapshotsListAsync(ResumeSnapshotsListInput input);
        Task<ResultDto<ResumeSnapshotsDto>> GetResumeSnapshotsAsync(ResumeSnapshotsInput input);
        Task<ResultDto<List<ResumeSnapshotsDto>>> GetResumeSnapshotsListAsync(ResumeSnapshotsListKeyWordsInput input);


        Task<ResumeMainsDto> GetResumeMainsAsync(GetResumeMainInput input);
        Task<List<ResumeMainsDto>> GetResumeMainListAsync(ResumeMainInput input);
        Task<ResumeMainsDto> SaveResumeMainsAsync(SaveResumeMainInput input);
        Task<ResumeMainsDto> UpdateResumeMainsAutobiography1Async(UpdateResumeMainsAutobiographyInput input);
        Task<ResultDto> UpdateResumeMainsAutobiography1CheckAsync(UpdateResumeMainsAutobiographyInput input);

        Task<ResumeEducationssDto> SaveResumeEducationsAsync (SaveResumeEducationsInput input);
        Task<ResultDto> SaveResumeEducationsCheckAsync(SaveResumeEducationsInput input);
        Task<List<ResumeEducationssDto>> GetResumeEducationsListAsync(ResumeEducationsInput input);
        Task<ResumeEducationssDto> DeleteResumeEducationsAsync(ResumeEducationsInput input);
        
        Task<ResumeExperiencessDto> SaveResumeExperiencesAsync(SaveResumeExperiencesInput input);
        Task<ResultDto> SaveResumeExperiencesCheckAsync(SaveResumeExperiencesInput input);
        Task<ResumeExperiencessDto> DeleteResumeExperiencesAsync(ResumeExperiencesInput input);
        Task<List<ResumeExperiencessDto>> GetResumeExperiencesListAsync(ResumeExperiencesInput input);

        Task<ResumeSkillsDto> SaveResumeSkillAsync(SaveResumeSkillInput input);
        Task<ResultDto> SaveResumeSkillCheckAsync(SaveResumeSkillInput input);
        Task<List<ResumeSkillsDto>> GetResumeSkillListAsync(ResumeSkillInput input);
        Task<ResumeSkillsDto> GetResumeSkillsAsync(ResumeSkillInput input);
        //Task<ResumeSkillsDto> DeleteResumeSkillAsync(ResumeSkillInput input);
    }
}
