using System;

namespace Resume.ShareDictionarys
{
    public class ShareDictionaryExcelDto
    {
        public Guid ShareLanguageId { get; set; }
        public Guid ShareTagId { get; set; }
        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string Name { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}