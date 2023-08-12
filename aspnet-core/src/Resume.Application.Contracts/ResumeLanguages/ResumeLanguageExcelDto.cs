using System;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguageExcelDto
    {
        public Guid ResumeMainId { get; set; }
        public string LanguageCategoryCode { get; set; }
        public string LevelSayCode { get; set; }
        public string LevelListenCode { get; set; }
        public string LevelReadCode { get; set; }
        public string LevelWriteCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}