using System;
using Volo.Abp.Application.Dtos;

namespace Resume.UserTokens
{
    public class UserTokenDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserMainId { get; set; }
        public string TokenOld { get; set; }
        public string TokenNew { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}