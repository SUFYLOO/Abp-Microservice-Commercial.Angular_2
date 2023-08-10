using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommenderExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? ResumeMainId { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? JobName { get; set; }
        public string? MobilePhone { get; set; }
        public string? OfficePhone { get; set; }
        public string? Email { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public ResumeRecommenderExcelDownloadDto()
        {

        }
    }
}