using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ShareUploads
{
    public class ShareUploadExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string? UploadName { get; set; }
        public string? ServerName { get; set; }
        public string? Type { get; set; }
        public int? SizeMin { get; set; }
        public int? SizeMax { get; set; }
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

        public ShareUploadExcelDownloadDto()
        {

        }
    }
}