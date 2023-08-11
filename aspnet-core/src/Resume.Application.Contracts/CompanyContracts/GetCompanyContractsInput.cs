using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyContracts
{
    public class GetCompanyContractsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public string? PlanCode { get; set; }
        public int? PointsTotalMin { get; set; }
        public int? PointsTotalMax { get; set; }
        public int? PointsPayMin { get; set; }
        public int? PointsPayMax { get; set; }
        public int? PointsGiftMin { get; set; }
        public int? PointsGiftMax { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetCompanyContractsInput()
        {

        }
    }
}