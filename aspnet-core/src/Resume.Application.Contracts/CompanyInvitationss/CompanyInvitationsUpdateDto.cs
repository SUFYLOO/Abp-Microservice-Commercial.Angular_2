using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyInvitationss
{
    public class CompanyInvitationsUpdateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        [Required]
        public bool OpenAllJob { get; set; }
        public Guid? UserMainId { get; set; }
        [StringLength(CompanyInvitationsConsts.UserMainNameMaxLength)]
        public string? UserMainName { get; set; }
        [StringLength(CompanyInvitationsConsts.UserMainLoginMobilePhoneMaxLength)]
        public string? UserMainLoginMobilePhone { get; set; }
        [StringLength(CompanyInvitationsConsts.UserMainLoginEmailMaxLength)]
        public string? UserMainLoginEmail { get; set; }
        [StringLength(CompanyInvitationsConsts.UserMainLoginIdentityNoMaxLength)]
        public string? UserMainLoginIdentityNo { get; set; }
        [Required]
        [StringLength(CompanyInvitationsConsts.SendTypeCodeMaxLength)]
        public string SendTypeCode { get; set; }
        [Required]
        [StringLength(CompanyInvitationsConsts.SendStatusCodeMaxLength)]
        public string SendStatusCode { get; set; }
        [Required]
        [StringLength(CompanyInvitationsConsts.ResumeFlowStageCodeMaxLength)]
        public string ResumeFlowStageCode { get; set; }
        [Required]
        public bool IsRead { get; set; }
        public Guid? UserCompanyBindId { get; set; }
        public Guid? ResumeSnapshotId { get; set; }
        [StringLength(CompanyInvitationsConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyInvitationsConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyInvitationsConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}