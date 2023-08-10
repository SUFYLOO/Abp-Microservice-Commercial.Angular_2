using System;
using Volo.Abp.Application.Dtos;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotifyDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserMainId { get; set; }
        public string? KeyId { get; set; }
        public string? KeyName { get; set; }
        public string NotifyTypeCode { get; set; }
        public string AppName { get; set; }
        public string AppCode { get; set; }
        public string TitleContents { get; set; }
        public string Contents { get; set; }
        public bool IsRead { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }

    }
}