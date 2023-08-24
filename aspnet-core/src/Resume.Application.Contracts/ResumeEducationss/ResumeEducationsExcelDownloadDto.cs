using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationsExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? ResumeMainId { get; set; }
        public string? EducationLevelCode { get; set; }
        public string? SchoolCode { get; set; }
        public string? SchoolName { get; set; }
        public bool? Night { get; set; }
        public bool? Working { get; set; }
        public string? MajorDepartmentName { get; set; }
        public string? MajorDepartmentCategory { get; set; }
        public string? MinorDepartmentName { get; set; }
        public string? MinorDepartmentCategory { get; set; }
        public string? GraduationCode { get; set; }
        public bool? Domestic { get; set; }
        public string? CountryCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public ResumeEducationsExcelDownloadDto()
        {

        }
    }
}