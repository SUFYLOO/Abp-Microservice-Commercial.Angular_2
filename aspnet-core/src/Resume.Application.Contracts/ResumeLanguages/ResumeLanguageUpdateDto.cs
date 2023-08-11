using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguageUpdateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeLanguageConsts.LanguageCategoryCodeMaxLength)]
        public string LanguageCategoryCode { get; set; }
        [Required]
        [StringLength(ResumeLanguageConsts.LevelSayCodeMaxLength)]
        public string LevelSayCode { get; set; }
        [Required]
        [StringLength(ResumeLanguageConsts.LevelListenCodeMaxLength)]
        public string LevelListenCode { get; set; }
        [Required]
        [StringLength(ResumeLanguageConsts.LevelReadCodeMaxLength)]
        public string LevelReadCode { get; set; }
        [Required]
        [StringLength(ResumeLanguageConsts.LevelWriteCodeMaxLength)]
        public string LevelWriteCode { get; set; }
        [StringLength(ResumeLanguageConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ResumeLanguageConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ResumeLanguageConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}