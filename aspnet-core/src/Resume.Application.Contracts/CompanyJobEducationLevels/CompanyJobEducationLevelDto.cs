using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevelDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string EducationLevelCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}