using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ResumeDependentss
{
    public class ResumeDependentsDto : FullAuditedEntityDto<Guid>
    {
        public Guid ResumeMainId { get; set; }
        public string Name { get; set; }
        public string? IdentityNo { get; set; }
        public string KinshipCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public string? MobilePhone { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}