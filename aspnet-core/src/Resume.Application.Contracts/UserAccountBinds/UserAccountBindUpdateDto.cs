using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserAccountBinds
{
    public class UserAccountBindUpdateDto
    {
        public Guid UserMainId { get; set; }
        [Required]
        [StringLength(UserAccountBindConsts.ThirdPartyTypeCodeMaxLength)]
        public string ThirdPartyTypeCode { get; set; }
        [Required]
        [StringLength(UserAccountBindConsts.ThirdPartyAccountIdMaxLength)]
        public string ThirdPartyAccountId { get; set; }
        [StringLength(UserAccountBindConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(UserAccountBindConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(UserAccountBindConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}