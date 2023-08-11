using Volo.Abp.Application.Dtos;
using System;

namespace Resume.SystemColumns
{
    public class SystemColumnExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? SystemTableId { get; set; }
        public string? Name { get; set; }
        public bool? IsKey { get; set; }
        public bool? IsSensitive { get; set; }
        public bool? NeedMask { get; set; }
        public string? DefaultValue { get; set; }
        public bool? CheckCode { get; set; }
        public string? Related { get; set; }
        public bool? AllowUpdate { get; set; }
        public bool? AllowNull { get; set; }
        public bool? AllowEmpty { get; set; }
        public bool? AllowExport { get; set; }
        public bool? AllowSort { get; set; }
        public string? ColumnTypeCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public SystemColumnExcelDownloadDto()
        {

        }
    }
}