using Resume.CompanyJobApplicationMethods;
using Resume.CompanyJobConditions;
using Resume.CompanyJobContents;
using Resume.CompanyJobPays;
using Resume.CompanyMains;
using Resume.CompanyUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string CompanyMainCode { get; set; }
    }

    public class CompanyUserInput : StdInput
    {
    }

    public class SaveCompanyUserInput : CompanyUserDto
    {
        public RegisterInput Register { get; set; }
        public List<Guid?> OrganizationUnitsId { get; set; }
        public List<Guid?> RolesId { get; set; }
        public SaveIntentType SaveIntent { get; set; }
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
    public class CompanyJobListInput
    {
        public string CompanyMainCode { get; set; }
    }
    public class CompanyJobInput : StdInput
    {
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

    public class InsertCompanyMainInput : CompanyMainDto
    {

    }

    public class UpdateCompanyMainInput : CompanyMainDto
    {

    }

    public class UpdateCompanyMainCompanyProfileInput
    {
        [Required]
        public Guid CompanyMainId { get; set; }
        [Required]
        public string CompanyProfile { get; set; }
    }

    public class UpdateCompanyMainBusinessPhilosophyInput
    {
        [Required]
        public Guid CompanyMainId { get; set; }
        public string BusinessPhilosophy { get; set; }
    }

    public class UpdateCompanyMainOperatingItemsInput
    {
        [Required]
        public Guid CompanyMainId { get; set; }
        public string OperatingItems { get; set; }
    }

    public class UpdateCompanyMainWelfareSystemInput
    {
        [Required]
        public Guid CompanyMainId { get; set; }
        public string WelfareSystem { get; set; }
    }

    public class SaveCompanyJobContentInput : CompanyJobContentDto
    {
        [Required]
        new public Guid Id { get; set; }
        public Guid CompanyJobContentId { get; set; }
        [Required]
        new public string Name { get; set; }
        [Required]
        new public string JobTypeCode { get; set; }
        [Required]
        new public string WorkPlace { get; set; }
        [Required]
        new public string WorkHours { get; set; }
        [Required]
        new public string SalaryPayTypeCode { get; set; }
    }

    public class SaveCompanyJobConditionInput : CompanyJobConditionDto
    {
        [Required]
        public Guid Id { get; set; }
        public Guid CompanyJobConditionId { get; set; }
        [Required]
        new public string EducationLevel { get; set; }
    }

    public class SaveCompanyJobApplicationMethodInput : CompanyJobApplicationMethodDto
    {
        [Required]
        new public Guid Id { get; set; }
        public Guid CompanyJobApplicationMethodId { get; set; }
        [Required]
        new public string OrgDept { get; set; }
        [Required]
        new public string OrgContactPerson { get; set; }
        [Required]
        new public string OrgContactMail { get; set; }
        [Required]
        new public bool ToRespond { get; set; }

    }

    public class CompanyJobContentInput : StdInput
    {
        public Guid? CompanyJobContentId { get; set; }
    }
    public class CompanyJobConditionInput : StdInput
    {
        public string CompanyJobConditionId { get; set; }
    }
    public class CompanyJobApplicationMethodInput : StdInput
    {
        public string CompanyJobApplicationMethodId { get; set; }
    }

    public class UpdateCompanyJobDateInput : StdInput
    {
        public Guid? CompanyJobId { get; set; }
        //public string CompanyJobCode { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
    }

    public class SaveCompanyJobPayInput : CompanyJobPayDto
    {
        public Guid? Id { get; set; }
        public Guid? CompanyJobPayId { get; set; }
    }

    public class CompanyJobsInput : StdInput
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
        public Guid CompanyMainId { get; set; }
        [Required]
        public bool JobOpen { get; set; }
    }

    public class CompanyJobOpenInput : StdInput
    {
        public bool JobOpen { get; set; }
    }
}