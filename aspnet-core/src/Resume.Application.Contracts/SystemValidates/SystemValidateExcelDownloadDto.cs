using Volo.Abp.Application.Dtos;
using System;

namespace Resume.SystemValidates
{
    public class SystemValidateExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? Param { get; set; }
        public DateTime? DateOpenMin { get; set; }
        public DateTime? DateOpenMax { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public SystemValidateExcelDownloadDto()
        {

        }
    }
}