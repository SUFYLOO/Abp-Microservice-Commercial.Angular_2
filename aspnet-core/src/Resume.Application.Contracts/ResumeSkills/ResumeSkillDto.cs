using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ResumeSkills
{
    public class ResumeSkillDto : FullAuditedEntityDto<Guid>
    {
        public Guid ResumeMainId { get; set; }
        public string? ComputerSkills { get; set; }
        public string? ComputerSkillsEtc { get; set; }
        public int ChineseTypingSpeed { get; set; }
        public string ChineseTypingCode { get; set; }
        public int EnglishTypingSpeed { get; set; }
        public string? ProfessionalLicense { get; set; }
        public string? ProfessionalLicenseEtc { get; set; }
        public string? WorkSkills { get; set; }
        public string? WorkSkillsEtc { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}