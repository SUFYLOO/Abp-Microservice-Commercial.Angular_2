using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobConditions
{
    public class CompanyJobConditionUpdateDto
    {
        [Required]
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [Required]
        [StringLength(CompanyJobConditionConsts.WorkExperienceYearCodeMaxLength)]
        public string WorkExperienceYearCode { get; set; }
        [StringLength(CompanyJobConditionConsts.EducationLevelMaxLength)]
        public string? EducationLevel { get; set; }
        [StringLength(CompanyJobConditionConsts.MajorDepartmentCategoryMaxLength)]
        public string? MajorDepartmentCategory { get; set; }
        [StringLength(CompanyJobConditionConsts.LanguageCategoryMaxLength)]
        public string? LanguageCategory { get; set; }
        [StringLength(CompanyJobConditionConsts.ComputerExpertiseMaxLength)]
        public string? ComputerExpertise { get; set; }
        [StringLength(CompanyJobConditionConsts.ProfessionalLicenseMaxLength)]
        public string? ProfessionalLicense { get; set; }
        [StringLength(CompanyJobConditionConsts.DrvingLicenseMaxLength)]
        public string? DrvingLicense { get; set; }
        [StringLength(CompanyJobConditionConsts.EtcConditionMaxLength)]
        public string? EtcCondition { get; set; }
        [StringLength(CompanyJobConditionConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobConditionConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobConditionConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}