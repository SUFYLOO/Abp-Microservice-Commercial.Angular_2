using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBindCreateDto
    {
        public Guid UserMainId { get; set; }
        public Guid CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public Guid? CompanyInvitationsId { get; set; }
        [StringLength(UserCompanyBindConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(UserCompanyBindConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(UserCompanyBindConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}