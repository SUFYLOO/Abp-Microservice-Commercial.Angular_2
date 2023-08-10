using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyMains
{
    public class CompanyMainExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Compilation { get; set; }
        public string? OfficePhone { get; set; }
        public string? FaxPhone { get; set; }
        public string? Address { get; set; }
        public string? Principal { get; set; }
        public bool? AllowSearch { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public string? Note { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Status { get; set; }
        public string? IndustryCategory { get; set; }
        public string? CompanyUrl { get; set; }
        public int? CapitalAmountMin { get; set; }
        public int? CapitalAmountMax { get; set; }
        public bool? HideCapitalAmount { get; set; }
        public string? CompanyScaleCode { get; set; }
        public bool? HidePrincipal { get; set; }
        public Guid? CompanyUserId { get; set; }
        public string? CompanyProfile { get; set; }
        public string? BusinessPhilosophy { get; set; }
        public string? OperatingItems { get; set; }
        public string? WelfareSystem { get; set; }
        public bool? Matching { get; set; }
        public bool? ContractPass { get; set; }

        public CompanyMainExcelDownloadDto()
        {

        }
    }
}