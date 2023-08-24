using Resume.App.Shares;
using Resume.App.Users;
using Resume.ResumeCommunications;
using Resume.ResumeDependentss;
using Resume.ResumeDrvingLicenses;
using Resume.ResumeEducationss;
using Resume.ResumeExperiencess;
using Resume.ResumeLanguages;
using Resume.ResumeMains;
using Resume.ResumeRecommenders;
using Resume.ResumeSkills;
using Resume.ResumeSnapshots;
using Resume.ResumeWorkss;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using System.Xml.Linq;

namespace Resume.App.Resumes
{
    public class UpdateResumeMainNameDto
    {
        public bool Pass { get; set; } = false;
    }

    public class ResumeSnapshotsDto : ResumeSnapshotDto
    {
        public string CompanyMainName { get; set; } = "";
        public string CompanyJobName { get; set; } = "";
        public ResumeDto Resume { get; set; }
    }

    public class SaveResumeSnapshotsDto
    {
        public bool Pass { get; set; } = false;
    }

    // 履歷主檔
    public class ResumeMainsDto : ResumeMainDto
    {
        //public string SexName { get; set; } = "";
        //public string BloodName { get; set; } = "";
        public string MarriageName { get; set; } = "";
        // public string PlaceOfBirthName { get; set; } = "";
        public string MilitaryName { get; set; } = "";
        public string DisabilityCategoryName { get; set; } = "";
        //public string NationalityName { get; set; } = "";
        public string SpecialIdentityName { get; set; } = "";
        public List<ShareUploadsDto> ListShareUpload { get; set; }
    }

    public class ResumeCommunicationsDto : ResumeCommunicationDto
    {
        public string CommunicationCategoryName { get; set; } = "";
    }

    public class ResumeMainMainDto
    {
        public Dictionary<Guid, bool> dcResumeMain { get; set; } = new Dictionary<Guid, bool>();
    }

    public class ResumeMainSortDto
    {
        public Dictionary<Guid, int> dcResumeMain { get; set; } = new Dictionary<Guid, int>();
    }

    public class ResumeCommunicationsClassificationDto : NameCodeStandardDto
    {
        public List<ResumeCommunicationsDto> ListResumeCommunications { get; set; }
    }

    // 駕照及交通工具
    public class ResumeDrvingLicensesDto : ResumeDrvingLicenseDto
    {

        // 駕照名稱
        public string DrvingLicenseName { get; set; } = "";

    }

    public class ResumeDrvingLicensesClassificationDto : NameCodeStandardDto
    {
        public List<ResumeDrvingLicensesDto> ListResumeDrvingLicenses { get; set; }
    }

    public class InsertResumeDrvingLicenseInitDto
    {
        public List<ResumeDrvingLicensesDto> ListResumeDrvingLicenses { get; set; }
    }

    // 推薦人
    public class ResumeRecommendersDto : ResumeRecommenderDto
    {

    }

    // 語言能力
    public class ResumeLanguagesDto : ResumeLanguageDto
    {

        // 語言名稱
        public string LanguageCategoryName { get; set; } = "";

        // 說
        public string LevelSayName { get; set; } = "";

        // 聽
        public string LevelListenName { get; set; } = "";

        // 讀
        public string LevelReadName { get; set; } = "";

        // 寫
        public string LevelWriteName { get; set; } = "";
    }

    public class ResumeLanguagesClassificationDto : NameCodeStandardDto
    {
        public List<ResumeLanguagesDto> ListResumeLanguages { get; set; }
    }

    // 技能專長
    public class ResumeSkillsDto : ResumeSkillDto
    {
        // 中打輸入法名稱
        //public string ChineseTypingName { get; set; } = "";
        public string ComputerSkillsname { get; set; } = "";
        public string ProfessionalLicenseName { get; set; } = "";
        public string WorkSkillsName { get; set; } = "";
    }

    // 眷屬
    public class ResumeDependentssDto : ResumeDependentsDto
    {
        // 眷屬關係
        public string KinshipName { get; set; }

    }

    // 學歷資料
    public class ResumeEducationssDto : ResumeEducationsDto
    { 
     public string EducationLevelName { get; set; }
    public string SchoolName { get; set; }
    public string DepartmentCategoryName { get; set; }
    public string DepartmentCategoryName2 { get; set; }
    public string GraduationName { get; set; }
    public string CountryName { get; set; }
    }

    // 工作經歷
    public class ResumeExperiencessDto : ResumeExperiencesDto
    {
        public string WorkNatureName { get; set; }
        public string IndustryCategoryName { get; set; }
        public string WorkPlaceName { get; set; }
        public string SalaryPayTypeName { get; set; }
        public string JobTypeName { get; set; }
        public string CurrencyTypeName { get; set; }
        public string CompanyScaleName { get; set; }
        public string CompanyManagementNumberName { get; set; }
    }

    public class ResumeExperiencesJobType
    {
        public string JobTypeCode { get; set; } = "";
        public string JobTypeName { get; set; } = "";
        public int Year { get; set; } = 0;
        public int Month { get; set; } = 0;
    }

    // 附件
    public class ResumeWorkssDto : ResumeWorksDto
    {

        // 附檔
        public List<ShareUploadsDto> ListShareUpload { get; set; }

    }

    // 全局資料
    public class ResumeDto
    {
        public UserMainsDto UserMains { get; set; } = new UserMainsDto();
        public ResumeMainsDto ResumeMains { get; set; } = new ResumeMainsDto();
        public List<ResumeCommunicationsDto> ListResumeCommunications { get; set; }
        public List<ResumeCommunicationsClassificationDto> ListResumeCommunicationsClassification { get; set; }
        public List<ResumeDrvingLicensesDto> ListResumeDrvingLicenses { get; set; }
        public List<ResumeDrvingLicensesClassificationDto> ListResumeDrvingLicensesClassification { get; set; }
        public List<ResumeRecommendersDto> ListResumeRecommenders { get; set; }
        public List<ResumeLanguagesDto> ListResumeLanguages { get; set; }
        public List<ResumeLanguagesClassificationDto> ListResumeLanguagesClassification { get; set; }
        public List<ResumeSkillsDto> ListResumeSkills { get; set; }
        public List<ResumeDependentssDto> ListResumeDependentss { get; set; }
        public List<ResumeEducationssDto> ListResumeEducationss { get; set; }
        public List<ResumeExperiencessDto> ListResumeExperiencess { get; set; }
        public List<ResumeWorkssDto> ListResumeWorkss { get; set; }
    }
    public class SaveResumeMainDto : ResumeMainDto
    {

    }
}