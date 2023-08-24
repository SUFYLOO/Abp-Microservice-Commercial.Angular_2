using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeSkills
{
    public class ResumeSkillUpdateDto
    {
        public Guid ResumeMainId { get; set; }
        [StringLength(ResumeSkillConsts.ComputerExpertiseMaxLength)]
        public string? ComputerExpertise { get; set; }
        [StringLength(ResumeSkillConsts.ComputerExpertiseEtcMaxLength)]
        public string? ComputerExpertiseEtc { get; set; }
        [Required]
        public int ChineseTypingSpeed { get; set; }
        [Required]
        [StringLength(ResumeSkillConsts.ChineseTypingCodeMaxLength)]
        public string ChineseTypingCode { get; set; }
        [Required]
        public int EnglishTypingSpeed { get; set; }
        [StringLength(ResumeSkillConsts.ProfessionalLicenseMaxLength)]
        public string? ProfessionalLicense { get; set; }
        [StringLength(ResumeSkillConsts.ProfessionalLicenseEtcMaxLength)]
        public string? ProfessionalLicenseEtc { get; set; }
        [StringLength(ResumeSkillConsts.WorkSkillsMaxLength)]
        public string? WorkSkills { get; set; }
        [StringLength(ResumeSkillConsts.WorkSkillsEtcMaxLength)]
        public string? WorkSkillsEtc { get; set; }
        [StringLength(ResumeSkillConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeSkillConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeSkillConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}