using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevelCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.EducationLevelCodeMaxLength)]
        public string? EducationLevelCode { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}