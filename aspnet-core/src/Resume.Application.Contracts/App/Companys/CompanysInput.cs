using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobPays;
using Resume.CompanyJobs;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace Resume.App.Companys
{
    public class CompanyMainListInput
    {

    }
    public class CompanyMainInput : StdInput
    {
    }
    public class DeleteCompanyMainInput : StdInput
    {
    }
    public class CompanyUserListInput
    {
        //public string CompanyMainId { get; set; }
    }

    public class CompanyUserInput : StdInput
    {
    }

    public class SaveCompanyUserInput : CompanyUserDto
    {
        public string Name { get; set; } = "";
        public string AccountCode { get; set; } = "";
        public string Email { get; set; } = "";
        public string MobilePhone { get; set; } = "";
        public string IdentityNo { get; set; } = "";
        public string Password { get; set; } = "";

        public string AnonymousName { get; set; }= "";
        //public int SystemUserRoleKeys { get; set; }
        public bool AllowSearch { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Guid>? ListRoleId { get; set; }
        public List<Guid>? ListOrgId { get; set; }
    }

    public class DeleteCompanyUserInput : StdInput
    {

    }
    public class CompanyJobInput : StdInput
    {
    }
    public class SaveCompanyJobInput : CompanyJobDto
    {
        public bool RefreshItem { get; set; } = false;
    }
    public class CompanyJobPayInput : StdInput
    { 

    }

    public class CompanyInvitationsListInput
    {
        public string CompanyMainId { get; set; }
    }
    public class CompanyInvitationsInput : StdInput
    {
    }
    public class DeleteCompanyInvitationsInput : StdInput
    {
    }

    public class GenerateLinkCompanyInvitationsInput : StdInput
    {

    }

    public class SendCompanyInvitationsInput : StdInput
    {
    }

    public class UserResumeSnapshotsListInput
    {
 
    }


    public class UpdateCompanyMainInput : CompanyMainDto
    {
        [Required]
        public string IndustryCategory { get; set; }
        [Required]
        public int CapitalAmount { get; set; }
        [Required]
        public Guid? CompanyUserId { get; set; }
        [Required]
        public string? OfficePhone { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Principal { get; set; }
    }

    public class UpdateCompanyMainCompanyProfileInput : StdInput
    {
        [Required]
        public string? CompanyProfile { get; set; }
    }

    public class UpdateCompanyMainBusinessPhilosophyInput : StdInput
    {
        [Required]
        public string BusinessPhilosophy { get; set; }
    }

    public class UpdateCompanyMainOperatingItemsInput : StdInput
    {
        [Required]
        public string OperatingItems { get; set; }
    }

    public class UpdateCompanyMainWelfareSystemInput : StdInput
    {
        [Required]
        public string WelfareSystem { get; set; }
    }

    public class SaveCompanyJobContentInput : CompanyJobContentDto
    {
        //public enum SaveIntent
        public bool RefreshItem { get; set; } = false;
        [Required]
        new public String JobTypeCode { get; set; }
        [Required]
        new public String Name { get; set; }
        [Required]
        public string  JobType { get; set; }
        [Required]
        public string  WorkHours{ get; set; }
        [Required]
        public int SalaryMin { get; set; }
        [Required]
        public int SalaryMax { get; set; }
        public List<DisabilityCategoryDto> ListDisabilityCategory { get; set; }
    }

    public class DisabilityCategoryDto
    {
        public string DisabilityCategoryCode { get; set; }
        public string DisabilityLevelCode { get; set; }
        public bool DisabilityCertifiedDocumentsNeed { get; set; }

    }

    public class SaveCompanyJobConditionInput : CompanyJobConditionDto
    {
        public bool RefreshItem { get; set; } = false;
        [Required]
        new public string EducationLevel { get; set; }
    }

    public class SaveCompanyJobApplicationMethodInput : CompanyJobApplicationMethodDto
    {
        public bool RefreshItem { get; set; } = false;
    }

    public class CompanyJobContentInput : StdInput
    {
        public List<DisabilityCategoryDto> ListDisabilityCategory { get; set; }
    }

    public class CompanyJobConditionInput : StdInput
    {

    }
    public class CompanyJobApplicationMethodInput : StdInput
    {

    }

    public class UpdateCompanyJobDateInput : StdInput
    {
        public Guid? CompanyJobId { get; set; }
        //public string CompanyJobCode { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
    }

    public class SaveCompanyJobPayInput : CompanyJobPayDto
    {
        public bool RefreshItem { get; set; } = false;
    }

    public class CompanyJobListInput : StdInput
    {
        [Required]
        public bool JobOpen { get; set; } = true;
        public string KeyWords { get; set; } = "";
        public string SortName { get; set; } = "";
        public Guid? CompanyJobId { get; set; }
    }

    public class UpdateCompanyJobOpenInput : StdInput
    {
        [Required]
        public bool JobOpen { get; set; }
    }

    public class UpdateCompanyJobInput : StdInput
    {
     
    }
}