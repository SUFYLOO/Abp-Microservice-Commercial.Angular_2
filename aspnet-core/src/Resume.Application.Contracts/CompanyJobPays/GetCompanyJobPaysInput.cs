using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyJobPays
{
    public class GetCompanyJobPaysInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public string? JobPayTypeCode { get; set; }
        public DateTime? DateRealMin { get; set; }
        public DateTime? DateRealMax { get; set; }
        public bool? IsCancel { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetCompanyJobPaysInput()
        {

        }
    }
}