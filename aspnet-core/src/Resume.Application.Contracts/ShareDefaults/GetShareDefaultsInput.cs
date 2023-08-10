using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ShareDefaults
{
    public class GetShareDefaultsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? GroupCode { get; set; }
        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string? Name { get; set; }
        public string? FieldKey { get; set; }
        public string? FieldValue { get; set; }
        public string? ColumnTypeCode { get; set; }
        public string? FormTypeCode { get; set; }
        public bool? SystemUse { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetShareDefaultsInput()
        {

        }
    }
}