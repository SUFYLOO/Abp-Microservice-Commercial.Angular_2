using System;
using Volo.Abp.Application.Dtos;

namespace Resume.SystemPages
{
    public class SystemPageDto : FullAuditedEntityDto<Guid>
    {
        public string TypeCode { get; set; }
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public string? FileTitle { get; set; }
        public string SystemUserRoleKeys { get; set; }
        public string ParentCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}