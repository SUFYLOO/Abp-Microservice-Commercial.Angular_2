using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommenderCreateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeRecommenderConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(ResumeRecommenderConsts.CompanyNameMaxLength)]
        public string? CompanyName { get; set; }
        [StringLength(ResumeRecommenderConsts.JobNameMaxLength)]
        public string? JobName { get; set; }
        [StringLength(ResumeRecommenderConsts.MobilePhoneMaxLength)]
        public string? MobilePhone { get; set; }
        [StringLength(ResumeRecommenderConsts.OfficePhoneMaxLength)]
        public string? OfficePhone { get; set; }
        [StringLength(ResumeRecommenderConsts.EmailMaxLength)]
        public string? Email { get; set; }
        [StringLength(ResumeRecommenderConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeRecommenderConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeRecommenderConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}