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

    // �i���D��
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

    // �r�ӤΥ�q�u��
    public class ResumeDrvingLicensesDto : ResumeDrvingLicenseDto
    {

        // �r�ӦW��
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

    // ���ˤH
    public class ResumeRecommendersDto : ResumeRecommenderDto
    {

    }

    // �y����O
    public class ResumeLanguagesDto : ResumeLanguageDto
    {

        // �y���W��
        public string LanguageCategoryName { get; set; } = "";

        // ��
        public string LevelSayName { get; set; } = "";

        // ť
        public string LevelListenName { get; set; } = "";

        // Ū
        public string LevelReadName { get; set; } = "";

        // �g
        public string LevelWriteName { get; set; } = "";
    }

    public class ResumeLanguagesClassificationDto : NameCodeStandardDto
    {
        public List<ResumeLanguagesDto> ListResumeLanguages { get; set; }
    }

    // �ޯ�M��
    public class ResumeSkillsDto : ResumeSkillDto
    {
        // ������J�k�W��
        //public string ChineseTypingName { get; set; } = "";
        public string ComputerSkillsname { get; set; } = "";
        public string ProfessionalLicenseName { get; set; } = "";
        public string WorkSkillsName { get; set; } = "";
    }

    // ����
    public class ResumeDependentssDto : ResumeDependentsDto
    {
        // �������Y
        public string KinshipName { get; set; }

    }

    // �Ǿ����
    public class ResumeEducationssDto : ResumeEducationsDto
    { 
     public string EducationLevelName { get; set; }
    public string SchoolName { get; set; }
    public string DepartmentCategoryName { get; set; }
    public string DepartmentCategoryName2 { get; set; }
    public string GraduationName { get; set; }
    public string CountryName { get; set; }
    }

    // �u�@�g��
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

    // ����
    public class ResumeWorkssDto : ResumeWorksDto
    {

        // ����
        public List<ShareUploadsDto> ListShareUpload { get; set; }

    }

    // �������
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