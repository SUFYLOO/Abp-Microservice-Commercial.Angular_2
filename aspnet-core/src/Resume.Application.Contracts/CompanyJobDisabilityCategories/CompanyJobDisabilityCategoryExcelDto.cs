using System;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoryExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string DisabilityCategoryCode { get; set; }
        public string DisabilityLevelCode { get; set; }
        public bool DisabilityCertifiedDocumentsNeed { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}