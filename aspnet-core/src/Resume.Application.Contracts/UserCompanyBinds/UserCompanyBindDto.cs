using System;
using Volo.Abp.Application.Dtos;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBindDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserMainId { get; set; }
        public Guid CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public Guid? CompanyInvitationsId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}