using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBindUpdateDto
    {
        public Guid UserMainId { get; set; }
        public Guid CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public Guid? CompanyInvitationsId { get; set; }
        [StringLength(UserCompanyBindConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(UserCompanyBindConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(UserCompanyBindConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}