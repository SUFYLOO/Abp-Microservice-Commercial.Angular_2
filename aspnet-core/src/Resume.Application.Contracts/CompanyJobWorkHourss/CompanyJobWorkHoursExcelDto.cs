using System;

namespace Resume.CompanyJobWorkHourss
{
    public class CompanyJobWorkHoursExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string WorkHoursCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}