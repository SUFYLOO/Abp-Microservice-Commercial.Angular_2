using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyJobs
{
    public class CompanyJobExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public string? Name { get; set; }
        public string? JobTypeCode { get; set; }
        public bool? JobOpen { get; set; }
        public string? MailTplId { get; set; }
        public string? SMSTplId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public CompanyJobExcelDownloadDto()
        {

        }
    }
}