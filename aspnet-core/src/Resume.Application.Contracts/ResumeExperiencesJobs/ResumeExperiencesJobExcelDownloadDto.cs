using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? ResumeMainId { get; set; }
        public Guid? ResumeExperiencesId { get; set; }
        public string? JobType { get; set; }
        public int? YearMin { get; set; }
        public int? YearMax { get; set; }
        public int? MonthMin { get; set; }
        public int? MonthMax { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public ResumeExperiencesJobExcelDownloadDto()
        {

        }
    }
}