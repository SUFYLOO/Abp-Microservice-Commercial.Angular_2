using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserVerifys
{
    public class UserVerifyCreateDto
    {
        [Required]
        [StringLength(UserVerifyConsts.VerifyIdMaxLength)]
        public string VerifyId { get; set; }
        [Required]
        [StringLength(UserVerifyConsts.VerifyCodeMaxLength)]
        public string VerifyCode { get; set; }
        [StringLength(UserVerifyConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(UserVerifyConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(UserVerifyConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}