using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobDto : FullAuditedEntityDto<Guid>
    {
        public Guid ResumeMainId { get; set; }
        public Guid ResumeExperiencesId { get; set; }
        public string JobType { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}