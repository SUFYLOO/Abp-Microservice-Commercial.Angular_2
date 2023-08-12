using System;

namespace Resume.CompanyJobs
{
    public class CompanyJobExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public string Name { get; set; }
        public string JobTypeCode { get; set; }
        public bool JobOpen { get; set; }
        public string MailTplId { get; set; }
        public string SMSTplId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}