using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyJobConditions
{
    public class CompanyJobConditionExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public string? WorkExperienceYearCode { get; set; }
        public string? EducationLevel { get; set; }
        public string? MajorDepartmentCategory { get; set; }
        public string? LanguageCategory { get; set; }
        public string? ComputerExpertise { get; set; }
        public string? ProfessionalLicense { get; set; }
        public string? DrvingLicense { get; set; }
        public string? EtcCondition { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public CompanyJobConditionExcelDownloadDto()
        {

        }
    }
}