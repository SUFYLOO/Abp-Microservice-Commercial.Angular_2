using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserTokens
{
    public class UserTokenUpdateDto
    {
        public Guid UserMainId { get; set; }
        [Required]
        public string TokenOld { get; set; }
        [Required]
        public string TokenNew { get; set; }
        [StringLength(UserTokenConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(UserTokenConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(UserTokenConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}