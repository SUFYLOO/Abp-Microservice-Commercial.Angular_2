using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationsDto : FullAuditedEntityDto<Guid>
    {
        public Guid ResumeMainId { get; set; }
        public string EducationLevelCode { get; set; }
        public string SchoolCode { get; set; }
        public string SchoolName { get; set; }
        public bool Night { get; set; }
        public bool Working { get; set; }
        public string MajorDepartmentName { get; set; }
        public string MajorDepartmentCategory { get; set; }
        public string MinorDepartmentName { get; set; }
        public string MinorDepartmentCategory { get; set; }
        public string GraduationCode { get; set; }
        public bool Domestic { get; set; }
        public string CountryCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}