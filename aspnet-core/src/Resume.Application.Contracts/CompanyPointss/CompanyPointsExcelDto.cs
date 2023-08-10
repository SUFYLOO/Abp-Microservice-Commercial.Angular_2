using System;

namespace Resume.CompanyPointss
{
    public class CompanyPointsExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public string? CompanyPointsTypeCode { get; set; }
        public int Points { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}