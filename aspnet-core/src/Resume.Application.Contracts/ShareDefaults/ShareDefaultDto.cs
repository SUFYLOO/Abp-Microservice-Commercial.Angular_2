using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ShareDefaults
{
    public class ShareDefaultDto : FullAuditedEntityDto<Guid>
    {
        public string GroupCode { get; set; }
        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string Name { get; set; }
        public string FieldKey { get; set; }
        public string? FieldValue { get; set; }
        public string ColumnTypeCode { get; set; }
        public string FormTypeCode { get; set; }
        public bool SystemUse { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}