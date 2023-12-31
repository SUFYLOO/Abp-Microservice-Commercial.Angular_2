using Resume.App.Resumes;
using Resume.CompanyInvitationss;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobDisabilityCategories;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using Resume.CompanyJobWorkHourss;
using Resume.CompanyJobWorkIdentities;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using Resume.ResumeSnapshots;
using Resume.ShareSendQueues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using static Resume.Permissions.ResumePermissions;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Resume.App.Companys
{

    public class CompanyMainsDto : CompanyMainDto
    {

    }

    public class DeleteCompanyMainDto
    {
        public bool Pass { get; set; } = false;
    }

    public class CompanyUsersDto : CompanyUserDto
    {
        public List<Guid>? ListRoleId { get; set; }
        public List<Guid>? ListOrgId { get; set; }
    }


    public class DeleteCompanyUserDto
    {
        public bool Pass { get; set; } = false;
    }

    public class CompanyJobsDto : CompanyJobDto
    {

    }

    public class CompanyInvitationssDto : CompanyInvitationsDto
    {
        public string Url { get; set; } = "";
        public List<ShareSendQueueDto> ListShareSendQueue { get; set; }

        public string CompanyMainName { get; set; } = "";
        public string CompanyJobName { get; set; } = "";
        public string SendTypeName { get; set; } = "";
        public string SendStatusName { get; set; } = "";
        public string ResumeFlowStageName { get; set; } = "";

    }

    public class DeleteCompanyInvitationsAsyncDto
    {
        public bool Pass { get; set; } = false;
    }

    public class GenerateLinkCompanyInvitationsDto
    {
        public string Url { get; set; } = "";
    }

    public class SendCompanyInvitationsAsyncDto
    {
        public bool Pass { get; set; } = false;
    }

    public class UserResumeSnapshotsListDto
    {
        public Guid UserMainId { get; set; }
        public string UserMainName { get; set; } = "";
        public string UserInfoNameC { get; set; } = "";
        public string UserInfoSex { get; set; } = "";
        public List<ResumeSnapshotDto> ListResumeSnapshot { get; set; } = new List<ResumeSnapshotDto>();

        //public List< ResumeDto> Resume { get; set; }
    }

    public class ResumeSnapshotDto : StdInput
    {
        public DateTime UpdateDate { get; set; }
    }

    public class UpdateCompanyMainDto : CompanyMainDto
    {

    }

    public class UpdateCompanyMainCompanyProfileDto
    {
        public Guid CompanyMainId;
        public string CompanyProfile { get; set; }
    }

    public class UpdateCompanyMainBusinessPhilosophyDto
    {
        public Guid CompanyMainId;
        public string BusinessPhilosophy { get; set; }
    }

    public class UpdateCompanyMainOperatingItemsDto
    {
        public Guid CompanyMainId;
        public string OperatingItems { get; set; }
    }
    public class UpdateCompanyMainWelfareSystemDto
    {
        public Guid CompanyMainId;
        public string WelfareSystem { get; set; }
    }

    public class CompanyJobContentsDto : CompanyJobContentDto
    {
        public string JobType { get; set; }
        public string SalaryPayTypeName { get; set; }
        public string WorkRemoteTypeName { get; set; }
        public string WorkDay { get; set; }
        public string HolidaySystemName { get; set; }
        public string WorkIdentityCodeName { get; set; }
        public string DisabilityCategoryName { get; set; }
    }
    public class CompanyJobConditionsDto : CompanyJobConditionDto
    {
        public string WorkExperienceYearName { get; set; }
        public string EducationLevelName { get; set; }
        public string DepartmentCategoryName { get; set; }
        public string LanguageCategoryName { get; set; }
        public string ComputerExpertiseName { get; set; }
        public string ProfessionalLicenseName { get; set; }
        public string DrvingLicenseName { get; set; }

    }

    public class CompanyJobApplicationMethodsDto : CompanyJobApplicationMethodDto
    {
        public string PersonallyName { get; set; }
    }

    public class UpdateCompanyJobDateDto : CompanyJobDto
    {

    }

    public class CompanyJobPaysDto : CompanyJobPayDto
    {

    }


    public class CompanyJobWorkHourssDto : CompanyJobWorkHoursDto
    {
        public SaveIntentType SaveIntent { get; set; }
    }

    public class CompanyJobWorkIdentitysDto : CompanyJobWorkIdentityDto
    {

    }

    public class CompanyJobDisabilityCategorysDto : CompanyJobDisabilityCategoryDto
    {

    }

}

