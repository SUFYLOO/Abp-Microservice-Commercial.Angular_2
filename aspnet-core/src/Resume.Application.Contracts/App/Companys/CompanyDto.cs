using Resume.App.Resumes;
using Resume.CompanyInvitationss;
using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using Resume.ResumeSnapshots;
using Resume.ShareSendQueues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using static Resume.Permissions.ResumePermissions;

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
        public List<string> Roles { get; set; } = new List<string>();
        public List<string> Orgs { get; set; } = new List<string>();
    }


    public class DeleteCompanyUserDto
    {
        public bool Pass { get; set; } = false;
    }

    public class CompanyJobsDto : CompanyJobDto
    {

    }

    public class DeleteCompanyJobDto
    {
        public bool Pass { get; set; } = false;
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

    public class ResumeSnapshotDto:StdInput
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

    public class SaveCompanyJobContentDto : CompanyJobContentDto
    {
        public SaveIntentType SaveIntent { get; set; } = SaveIntentType.Insert;
    }
    public class SaveCompanyJobConditionDto : CompanyJobConditionDto
    {

    }
    public class SaveCompanyJobApplicationMethodDto : CompanyJobApplicationMethodUpdateDto
    {

    }
    public class CompanyJobContentsDto : CompanyJobContentDto
    {

    }
    public class CompanyJobConditionsDto : CompanyJobConditionDto
    {

    }

    public class CompanyJobApplicationMethodsDto : CompanyJobApplicationMethodDto
    {

    }

    public class UpdateCompanyJobDateDto : CompanyJobDto
    {

    }

    public class SaveCompanyJobPayDto : CompanyJobPayDto 
    {

    }
    
    public class CompanysJobDto : CompanyJobDto
    {

    }

    public class UpdateCompanyJobOpenDto
    {
        public string JobOpen { get; set; }
    }
    public class CompanyJobOpenDto: CompanyJobDto
    {

    }
}

