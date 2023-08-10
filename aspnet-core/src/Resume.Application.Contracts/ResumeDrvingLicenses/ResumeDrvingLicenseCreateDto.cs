using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicenseCreateDto
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
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ResumeDrvingLicenseConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ResumeDrvingLicenseConsts.StatusMaxLength)]
        public string Status { get; set; }
    }
}