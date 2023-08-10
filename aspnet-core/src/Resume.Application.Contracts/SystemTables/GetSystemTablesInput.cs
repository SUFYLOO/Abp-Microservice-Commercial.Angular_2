using Volo.Abp.Application.Dtos;
using System;

namespace Resume.SystemTables
{
    public class GetSystemTablesInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public bool? AllowInsert { get; set; }
        public bool? AllowUpdate { get; set; }
        public bool? AllowDelete { get; set; }
        public bool? AllowSelect { get; set; }
        public bool? AllowExport { get; set; }
        public bool? AllowImport { get; set; }
        public bool? AllowPage { get; set; }
        public bool? AllowSort { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetSystemTablesInput()
        {

        }
    }
}