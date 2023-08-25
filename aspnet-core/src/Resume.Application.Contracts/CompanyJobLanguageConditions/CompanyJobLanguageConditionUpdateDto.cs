using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobLanguageConditions
{
    public class CompanyJobLanguageConditionUpdateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [Required]
        [StringLength(CompanyJobLanguageConditionConsts.LanguageCategoryCodeMaxLength)]
        public string LanguageCategoryCode { get; set; }
        [Required]
        [StringLength(CompanyJobLanguageConditionConsts.LevelSayCodeMaxLength)]
        public string LevelSayCode { get; set; }
        [Required]
        [StringLength(CompanyJobLanguageConditionConsts.LevelListenCodeMaxLength)]
        public string LevelListenCode { get; set; }
        [Required]
        [StringLength(CompanyJobLanguageConditionConsts.LevelReadCodeMaxLength)]
        public string LevelReadCode { get; set; }
        [Required]
        [StringLength(CompanyJobLanguageConditionConsts.LevelWriteCodeMaxLength)]
        public string LevelWriteCode { get; set; }
        [StringLength(CompanyJobLanguageConditionConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobLanguageConditionConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobLanguageConditionConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}