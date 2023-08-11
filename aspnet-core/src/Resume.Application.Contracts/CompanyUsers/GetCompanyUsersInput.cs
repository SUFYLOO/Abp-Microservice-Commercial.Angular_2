using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyUsers
{
    public class GetCompanyUsersInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? UserMainId { get; set; }
        public string? JobName { get; set; }
        public string? OfficePhone { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        public bool? MatchingReceive { get; set; }

        public GetCompanyUsersInput()
        {

        }
    }
}