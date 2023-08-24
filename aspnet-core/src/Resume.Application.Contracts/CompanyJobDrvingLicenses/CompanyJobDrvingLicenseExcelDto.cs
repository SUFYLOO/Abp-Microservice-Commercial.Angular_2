using System;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicenseExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string? DrvingLicenseCode { get; set; }
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