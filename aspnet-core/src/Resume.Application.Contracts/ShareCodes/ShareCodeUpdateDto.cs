using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareCodes
{
    public class ShareCodeUpdateDto
    {
        [Required]
        [StringLength(ShareCodeConsts.GroupCodeMaxLength)]
        public string GroupCode { get; set; }
        [Required]
        [StringLength(ShareCodeConsts.Key1MaxLength)]
        public string Key1 { get; set; }
        [Required]
        [StringLength(ShareCodeConsts.Key2MaxLength)]
        public string Key2 { get; set; }
        [Required]
        [StringLength(ShareCodeConsts.Key3MaxLength)]
        public string Key3 { get; set; }
        [Required]
        [StringLength(ShareCodeConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(ShareCodeConsts.Column1MaxLength)]
        public string? Column1 { get; set; }
        [StringLength(ShareCodeConsts.Column2MaxLength)]
        public string? Column2 { get; set; }
        [StringLength(ShareCodeConsts.Column3MaxLength)]
        public string? Column3 { get; set; }
        [Required]
        public bool SystemUse { get; set; }
        [StringLength(ShareCodeConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ShareCodeConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ShareCodeConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}