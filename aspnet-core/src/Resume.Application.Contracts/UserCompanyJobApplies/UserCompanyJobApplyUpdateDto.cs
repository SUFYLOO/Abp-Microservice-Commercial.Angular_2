using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobApplyUpdateDto : IHasConcurrencyStamp
    {
        public Guid UserMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [StringLength(UserCompanyJobApplyConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        [StringLength(UserCompanyJobApplyConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(UserCompanyJobApplyConsts.StatusMaxLength)]
        public string Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}