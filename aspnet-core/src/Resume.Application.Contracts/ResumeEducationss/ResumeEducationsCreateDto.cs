using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationsCreateDto
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
        [StringLength(ResumeEducationsConsts.MajorDepartmentCategoryCodeMaxLength)]
        public string MajorDepartmentCategoryCode { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.MinorDepartmentNameMaxLength)]
        public string MinorDepartmentName { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.MinorDepartmentCategoryCodeMaxLength)]
        public string MinorDepartmentCategoryCode { get; set; }
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
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ResumeEducationsConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ResumeEducationsConsts.StatusMaxLength)]
        public string Status { get; set; }
    }
}