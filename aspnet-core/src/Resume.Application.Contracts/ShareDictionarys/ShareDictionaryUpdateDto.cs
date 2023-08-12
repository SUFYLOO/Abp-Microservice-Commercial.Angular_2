using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareDictionarys
{
    public class ShareDictionaryUpdateDto
    {
        public Guid ShareLanguageId { get; set; }
        public Guid ShareTagId { get; set; }
        [StringLength(ShareDictionaryConsts.Key1MaxLength)]
        public string? Key1 { get; set; }
        [StringLength(ShareDictionaryConsts.Key2MaxLength)]
        public string? Key2 { get; set; }
        [StringLength(ShareDictionaryConsts.Key3MaxLength)]
        public string? Key3 { get; set; }
        [Required]
        [StringLength(ShareDictionaryConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(ShareDictionaryConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ShareDictionaryConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ShareDictionaryConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}