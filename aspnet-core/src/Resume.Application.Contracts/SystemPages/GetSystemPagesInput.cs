using Volo.Abp.Application.Dtos;
using System;

namespace Resume.SystemPages
{
    public class GetSystemPagesInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? TypeCode { get; set; }
        public string? FilePath { get; set; }
        public string? FileName { get; set; }
        public string? FileTitle { get; set; }
        public string? SystemUserRoleKeys { get; set; }
        public string? ParentCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetSystemPagesInput()
        {

        }
    }
}