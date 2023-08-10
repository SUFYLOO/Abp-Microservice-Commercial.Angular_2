using System;
using Volo.Abp.Application.Dtos;

namespace Resume.ShareLanguages
{
    public class ShareLanguageDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }

    }
}