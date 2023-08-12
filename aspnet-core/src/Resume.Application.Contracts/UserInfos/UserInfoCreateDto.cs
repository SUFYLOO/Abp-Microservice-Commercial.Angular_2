using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserInfos
{
    public class UserInfoCreateDto
    {
        public Guid UserMainId { get; set; }
        [Required]
        [StringLength(UserInfoConsts.NameCMaxLength)]
        public string NameC { get; set; }
        [StringLength(UserInfoConsts.NameEMaxLength)]
        public string? NameE { get; set; }
        [StringLength(UserInfoConsts.IdentityNoMaxLength)]
        public string? IdentityNo { get; set; }
        public DateTime? BirthDate { get; set; }
        [StringLength(UserInfoConsts.SexCodeMaxLength)]
        public string? SexCode { get; set; }
        [StringLength(UserInfoConsts.BloodCodeMaxLength)]
        public string? BloodCode { get; set; }
        [StringLength(UserInfoConsts.PlaceOfBirthCodeMaxLength)]
        public string? PlaceOfBirthCode { get; set; }
        [StringLength(UserInfoConsts.PassportNoMaxLength)]
        public string? PassportNo { get; set; }
        [StringLength(UserInfoConsts.NationalityCodeMaxLength)]
        public string? NationalityCode { get; set; }
        [StringLength(UserInfoConsts.ResidenceNoMaxLength)]
        public string? ResidenceNo { get; set; }
        [StringLength(UserInfoConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(UserInfoConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(UserInfoConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}