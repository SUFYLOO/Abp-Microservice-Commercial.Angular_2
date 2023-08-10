using System;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicenseExcelDto
    {
        public Guid ResumeMainId { get; set; }
        public string DrvingLicenseCode { get; set; }
        public bool HaveDrvingLicense { get; set; }
        public bool HaveCar { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}