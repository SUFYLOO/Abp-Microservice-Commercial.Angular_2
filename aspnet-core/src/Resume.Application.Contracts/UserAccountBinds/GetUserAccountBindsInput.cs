using Volo.Abp.Application.Dtos;
using System;

namespace Resume.UserAccountBinds
{
    public class GetUserAccountBindsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? UserMainId { get; set; }
        public string? ThirdPartyTypeCode { get; set; }
        public string? ThirdPartyAccountId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetUserAccountBindsInput()
        {

        }
    }
}