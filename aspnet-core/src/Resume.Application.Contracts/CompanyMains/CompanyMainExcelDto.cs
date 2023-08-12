using System;

namespace Resume.CompanyMains
{
    public class CompanyMainExcelDto
    {
        public string Name { get; set; }
        public string? Compilation { get; set; }
        public string? OfficePhone { get; set; }
        public string? FaxPhone { get; set; }
        public string? Address { get; set; }
        public string? Principal { get; set; }
        public bool AllowSearch { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public string? Note { get; set; }
        public int? Sort { get; set; }
        public string? Status { get; set; }
        public string IndustryCategory { get; set; }
        public string? CompanyUrl { get; set; }
        public int CapitalAmount { get; set; }
        public bool HideCapitalAmount { get; set; }
        public string CompanyScaleCode { get; set; }
        public bool HidePrincipal { get; set; }
        public Guid? CompanyUserId { get; set; }
        public string? CompanyProfile { get; set; }
        public string? BusinessPhilosophy { get; set; }
        public string? OperatingItems { get; set; }
        public string? WelfareSystem { get; set; }
        public bool Matching { get; set; }
        public bool ContractPass { get; set; }
    }
}