using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicenseUpdateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength)]
        public string DrvingLicenseCode { get; set; }
        [Required]
        public bool HaveDrvingLicense { get; set; }
        [Required]
        public bool HaveCar { get; set; }
        [StringLength(ResumeDrvingLicenseConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeDrvingLicenseConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeDrvingLicenseConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}