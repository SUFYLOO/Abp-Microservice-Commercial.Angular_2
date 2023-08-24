using System;

namespace Resume.CompanyJobWorkIdentities
{
    public class CompanyJobWorkIdentityExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string WorkIdentityCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}