using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeSkills
{
    public class ResumeSkillExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? ResumeMainId { get; set; }
        public string? ComputerSkills { get; set; }
        public string? ComputerSkillsEtc { get; set; }
        public int? ChineseTypingSpeedMin { get; set; }
        public int? ChineseTypingSpeedMax { get; set; }
        public string? ChineseTypingCode { get; set; }
        public int? EnglishTypingSpeedMin { get; set; }
        public int? EnglishTypingSpeedMax { get; set; }
        public string? ProfessionalLicense { get; set; }
        public string? ProfessionalLicenseEtc { get; set; }
        public string? WorkSkills { get; set; }
        public string? WorkSkillsEtc { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public ResumeSkillExcelDownloadDto()
        {

        }
    }
}