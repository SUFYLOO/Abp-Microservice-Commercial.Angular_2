using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobUpdateDto : IHasConcurrencyStamp
    {
        public Guid ResumeMainId { get; set; }
        public Guid ResumeExperiencesId { get; set; }
        [Required]
        [StringLength(ResumeExperiencesJobConsts.JobTypeMaxLength)]
        public string JobType { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        [StringLength(ResumeExperiencesJobConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeExperiencesJobConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeExperiencesJobConsts.StatusMaxLength)]
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}