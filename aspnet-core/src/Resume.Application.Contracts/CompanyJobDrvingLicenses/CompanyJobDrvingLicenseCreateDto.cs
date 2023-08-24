using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicenseCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [Required]
        [StringLength(CompanyJobDrvingLicenseConsts.DrvingLicenseCodeMaxLength)]
        public string DrvingLicenseCode { get; set; }
        public bool HaveDrvingLicense { get; set; }
        public bool HaveCar { get; set; }
        [StringLength(CompanyJobDrvingLicenseConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobDrvingLicenseConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobDrvingLicenseConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}