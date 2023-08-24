using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobWorkIdentities
{
    public class CompanyJobWorkIdentityCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public Guid WorkIdentityCode { get; set; }
        [StringLength(CompanyJobWorkIdentityConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobWorkIdentityConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobWorkIdentityConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}