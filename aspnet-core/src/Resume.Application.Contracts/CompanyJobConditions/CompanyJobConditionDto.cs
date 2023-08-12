using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyJobConditions
{
    public class CompanyJobConditionDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string WorkExperienceYearCode { get; set; }
        public string? EducationLevel { get; set; }
        public string? MajorDepartmentCategory { get; set; }
        public string? LanguageCategory { get; set; }
        public string? ComputerExpertise { get; set; }
        public string? ProfessionalLicense { get; set; }
        public string? DrvingLicense { get; set; }
        public string? EtcCondition { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}