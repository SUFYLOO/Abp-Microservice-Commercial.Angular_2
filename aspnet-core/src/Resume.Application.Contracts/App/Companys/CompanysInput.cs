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
        public string CompanyMainId { get; set; }
    }

    public class CompanyUserInput : StdInput
    {
    }

    public class SaveCompanyUserInput : CompanyUserDto
    {
        public RegisterBaseInput Register { get; set; }
    }

    public class UpdateCompanyUserInput : CompanyUserDto
    {
        public string Name { get; set; }
        public string AnonymousName { get; set; }
        public string LoginAccountCode { get; set; }
        public string LoginMobilePhone { get; set; }
        public string LoginEmail { get; set; }
        public string LoginIdentityNo { get; set; }
        public string Password { get; set; }
        public int SystemUserRoleKeys { get; set; }
        public bool AllowSearch { get; set; }
        public DateTime BirthDate { get; set; }

        public List<Guid?> OrganizationUnitsId { get; set; }
        public List<Guid?> RolesId { get; set; }
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
    public class DeleteCompanyJobInput : StdInput
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
    }

    public class UpdateCompanyMainCompanyProfileInput : StdInput
    {
        public string? CompanyProfile { get; set; }

    }

    public class UpdateCompanyMainBusinessPhilosophyInput : StdInput
    {
        public string BusinessPhilosophy { get; set; }
    }

    public class UpdateCompanyMainOperatingItemsInput : StdInput
    {
        public string OperatingItems { get; set; }
    }

    public class UpdateCompanyMainWelfareSystemInput : StdInput
    {
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
        //public Guid CompanyJobApplicationMethodId { get; set; }
        //[Required]
        //new public string OrgDept { get; set; }
        //[Required]
        //new public string OrgContactPerson { get; set; }
        //[Required]
        //new public string OrgContactMail { get; set; }
        //[Required]
        //new public bool ToRespond { get; set; }
    }

    public class CompanyJobContentInput : StdInput
    {

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
}