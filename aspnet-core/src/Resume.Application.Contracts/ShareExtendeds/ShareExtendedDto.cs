using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ShareExtendeds
{
    public class ShareExtendedDto : FullAuditedEntityDto<Guid>
    {
        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string? Key4 { get; set; }
        public string? Key5 { get; set; }
        public Guid? KeyId { get; set; }
        public string? FieldValue { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}