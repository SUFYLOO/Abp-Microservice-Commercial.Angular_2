using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyPointss
{
    public class GetCompanyPointssInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public string? CompanyPointsTypeCode { get; set; }
        public int? PointsMin { get; set; }
        public int? PointsMax { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetCompanyPointssInput()
        {

        }
    }
}