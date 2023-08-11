using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencesDto : FullAuditedEntityDto<Guid>
    {
        public Guid ResumeMainId { get; set; }
        public string Name { get; set; }
        public string WorkNatureCode { get; set; }
        public bool HideCompanyName { get; set; }
        public string IndustryCategoryCode { get; set; }
        public string JobName { get; set; }
        public string? JobType { get; set; }
        public bool Working { get; set; }
        public string? WorkPlaceCode { get; set; }
        public bool HideWorkSalary { get; set; }
        public string SalaryPayTypeCode { get; set; }
        public string CurrencyTypeCode { get; set; }
        public decimal Salary1 { get; set; }
        public decimal Salary2 { get; set; }
        public string CompanyScaleCode { get; set; }
        public string CompanyManagementNumberCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }

    }
}