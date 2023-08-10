using System;
using Volo.Abp.Application.Dtos;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessageDto : FullAuditedEntityDto<Guid>
    {
        public string DisplayTypeCode { get; set; }
        public string TitleContents { get; set; }
        public string Contents { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }

    }
}