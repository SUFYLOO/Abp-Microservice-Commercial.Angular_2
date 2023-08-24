using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyJobDrvingLicenses
{
    public class GetCompanyJobDrvingLicensesInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public string? DrvingLicenseCode { get; set; }
        public bool? HaveDrvingLicense { get; set; }
        public bool? HaveCar { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetCompanyJobDrvingLicensesInput()
        {

        }
    }
}