using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeMains
{
    public class ResumeMainUpdateDto
    {
        public Guid UserMainId { get; set; }
        [Required]
        [StringLength(ResumeMainConsts.ResumeNameMaxLength)]
        public string ResumeName { get; set; }
        [StringLength(ResumeMainConsts.MarriageCodeMaxLength)]
        public string? MarriageCode { get; set; }
        [StringLength(ResumeMainConsts.MilitaryCodeMaxLength)]
        public string? MilitaryCode { get; set; }
        [StringLength(ResumeMainConsts.DisabilityCategoryCodeMaxLength)]
        public string? DisabilityCategoryCode { get; set; }
        [StringLength(ResumeMainConsts.SpecialIdentityCodeMaxLength)]
        public string? SpecialIdentityCode { get; set; }
        [Required]
        public bool Main { get; set; }
        public string? Autobiography1 { get; set; }
        public string? Autobiography2 { get; set; }
        [StringLength(ResumeMainConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeMainConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeMainConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}