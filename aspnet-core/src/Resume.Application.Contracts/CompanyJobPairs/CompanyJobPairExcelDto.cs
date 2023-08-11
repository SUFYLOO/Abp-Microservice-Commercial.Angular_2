using System;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public string Name { get; set; }
        public string? PairCondition { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}