using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ShareSendQueues
{
    public class ShareSendQueueDto : FullAuditedEntityDto<Guid>
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
        public string SendTypeCode { get; set; }
        public string? FromAddr { get; set; }
        public string ToAddr { get; set; }
        public string? TitleContents { get; set; }
        public string Contents { get; set; }
        public int Retry { get; set; }
        public bool Sucess { get; set; }
        public bool Suspend { get; set; }
        public DateTime DateSend { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}