using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguageExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? ResumeMainId { get; set; }
        public string? LanguageCategoryCode { get; set; }
        public string? LevelSayCode { get; set; }
        public string? LevelListenCode { get; set; }
        public string? LevelReadCode { get; set; }
        public string? LevelWriteCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public ResumeLanguageExcelDownloadDto()
        {

        }
    }
}