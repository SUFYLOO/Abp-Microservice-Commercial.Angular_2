using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodeUpdateDto : IHasConcurrencyStamp
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [Required]
        [StringLength(CompanyInvitationsCodeConsts.CompanyInvitationIdMaxLength)]
        public string CompanyInvitationId { get; set; }
        [Required]
        [StringLength(CompanyInvitationsCodeConsts.VerifyIdMaxLength)]
        public string VerifyId { get; set; }
        [Required]
        [StringLength(CompanyInvitationsCodeConsts.VerifyCodeMaxLength)]
        public string VerifyCode { get; set; }
        [StringLength(CompanyInvitationsCodeConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        [StringLength(CompanyInvitationsCodeConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(CompanyInvitationsCodeConsts.StatusMaxLength)]
        public string Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}