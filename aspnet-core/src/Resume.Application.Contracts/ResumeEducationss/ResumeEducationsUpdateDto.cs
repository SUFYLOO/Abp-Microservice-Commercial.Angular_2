using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationsUpdateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.EducationLevelCodeMaxLength)]
        public string EducationLevelCode { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.SchoolCodeMaxLength)]
        public string SchoolCode { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.SchoolNameMaxLength)]
        public string SchoolName { get; set; }
        [Required]
        public bool Night { get; set; }
        [Required]
        public bool Working { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.MajorDepartmentNameMaxLength)]
        public string MajorDepartmentName { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.MajorDepartmentCategoryMaxLength)]
        public string MajorDepartmentCategory { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.MinorDepartmentNameMaxLength)]
        public string MinorDepartmentName { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.MinorDepartmentCategoryMaxLength)]
        public string MinorDepartmentCategory { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.GraduationCodeMaxLength)]
        public string GraduationCode { get; set; }
        [Required]
        public bool Domestic { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.CountryCodeMaxLength)]
        public string CountryCode { get; set; }
        [StringLength(ResumeEducationsConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeEducationsConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeEducationsConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}