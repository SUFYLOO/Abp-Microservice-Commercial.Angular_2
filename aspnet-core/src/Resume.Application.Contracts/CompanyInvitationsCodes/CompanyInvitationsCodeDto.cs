using System;
using Volo.Abp.Application.Dtos;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodeDto : FullAuditedEntityDto<Guid>
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string CompanyInvitationId { get; set; }
        public string VerifyId { get; set; }
        public string VerifyCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}