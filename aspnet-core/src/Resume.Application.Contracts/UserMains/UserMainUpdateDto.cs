using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserMains
{
    public class UserMainUpdateDto
    {
        public Guid UserId { get; set; }
        [Required]
        [StringLength(UserMainConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(UserMainConsts.AnonymousNameMaxLength)]
        public string? AnonymousName { get; set; }
        [Required]
        [StringLength(UserMainConsts.LoginAccountCodeMaxLength)]
        public string LoginAccountCode { get; set; }
        [StringLength(UserMainConsts.LoginMobilePhoneUpdateMaxLength)]
        public string? LoginMobilePhoneUpdate { get; set; }
        [StringLength(UserMainConsts.LoginMobilePhoneMaxLength)]
        public string? LoginMobilePhone { get; set; }
        [StringLength(UserMainConsts.LoginEmailUpdateMaxLength)]
        public string? LoginEmailUpdate { get; set; }
        [StringLength(UserMainConsts.LoginEmailMaxLength)]
        public string? LoginEmail { get; set; }
        [StringLength(UserMainConsts.LoginIdentityNoMaxLength)]
        public string? LoginIdentityNo { get; set; }
        [Required]
        [StringLength(UserMainConsts.PasswordMaxLength)]
        public string Password { get; set; }
        [Required]
        public int SystemUserRoleKeys { get; set; }
        [Required]
        public bool AllowSearch { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [StringLength(UserMainConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(UserMainConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(UserMainConsts.StatusMaxLength)]
        public string Status { get; set; }
        public bool Matching { get; set; }

    }
}