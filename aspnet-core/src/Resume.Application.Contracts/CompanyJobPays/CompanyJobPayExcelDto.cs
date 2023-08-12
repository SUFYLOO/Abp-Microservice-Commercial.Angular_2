using System;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPayExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string JobPayTypeCode { get; set; }
        public DateTime? DateReal { get; set; }
        public bool IsCancel { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}