using System;

namespace Resume.CompanyJobConditions
{
    public class CompanyJobConditionExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string WorkExperienceYearCode { get; set; }
        public string? EducationLevel { get; set; }
        public string? MajorDepartmentCategory { get; set; }
        public string? LanguageCondition { get; set; }
        public string? ComputerExpertiseEtc { get; set; }
        public string? ProfessionalLicense { get; set; }
        public string? ProfessionalLicenseEtc { get; set; }
        public string? WorkSkills { get; set; }
        public string? WorkSkillsEtc { get; set; }
        public string? DrvingLicense { get; set; }
        public string? EtcCondition { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}