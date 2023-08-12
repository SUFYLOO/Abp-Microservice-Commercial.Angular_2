using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencesUpdateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.WorkNatureCodeMaxLength)]
        public string WorkNatureCode { get; set; }
        [Required]
        public bool HideCompanyName { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.IndustryCategoryCodeMaxLength)]
        public string IndustryCategoryCode { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.JobNameMaxLength)]
        public string JobName { get; set; }
        [StringLength(ResumeExperiencesConsts.JobTypeMaxLength)]
        public string? JobType { get; set; }
        [Required]
        public bool Working { get; set; }
        [StringLength(ResumeExperiencesConsts.WorkPlaceCodeMaxLength)]
        public string? WorkPlaceCode { get; set; }
        public bool HideWorkSalary { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.SalaryPayTypeCodeMaxLength)]
        public string SalaryPayTypeCode { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.CurrencyTypeCodeMaxLength)]
        public string CurrencyTypeCode { get; set; }
        public decimal Salary1 { get; set; }
        public decimal Salary2 { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.CompanyScaleCodeMaxLength)]
        public string CompanyScaleCode { get; set; }
        [Required]
        [StringLength(ResumeExperiencesConsts.CompanyManagementNumberCodeMaxLength)]
        public string CompanyManagementNumberCode { get; set; }
        [StringLength(ResumeExperiencesConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeExperiencesConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeExperiencesConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}