using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicenseDto : FullAuditedEntityDto<Guid>
    {
        public Guid ResumeMainId { get; set; }
        public string DrvingLicenseCode { get; set; }
        public bool HaveDrvingLicense { get; set; }
        public bool HaveCar { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}