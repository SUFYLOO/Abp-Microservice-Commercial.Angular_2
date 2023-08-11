using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareLanguages
{
    public class ShareLanguageCreateDto
    {
        [Required]
        [StringLength(ShareLanguageConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(ShareLanguageConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ShareLanguageConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ShareLanguageConsts.StatusMaxLength)]
        public string Status { get; set; }
    }
}