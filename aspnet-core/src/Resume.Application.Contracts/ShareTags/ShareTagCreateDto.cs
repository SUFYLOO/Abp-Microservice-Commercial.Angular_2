using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareTags
{
    public class ShareTagCreateDto
    {
        [Required]
        [StringLength(ShareTagConsts.ColorCodeMaxLength)]
        public string ColorCode { get; set; }
        [Required]
        [StringLength(ShareTagConsts.Key1MaxLength)]
        public string Key1 { get; set; }
        [Required]
        [StringLength(ShareTagConsts.Key2MaxLength)]
        public string Key2 { get; set; }
        [Required]
        [StringLength(ShareTagConsts.Key3MaxLength)]
        public string Key3 { get; set; }
        [Required]
        [StringLength(ShareTagConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(ShareTagConsts.TagCategoryCodeMaxLength)]
        public string TagCategoryCode { get; set; }
        [StringLength(ShareTagConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ShareTagConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ShareTagConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}