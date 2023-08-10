using Volo.Abp.Application.Dtos;
using System;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotifyExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? UserMainId { get; set; }
        public string? KeyId { get; set; }
        public string? KeyName { get; set; }
        public string? NotifyTypeCode { get; set; }
        public string? AppName { get; set; }
        public string? AppCode { get; set; }
        public string? TitleContents { get; set; }
        public string? Contents { get; set; }
        public bool? IsRead { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public SystemUserNotifyExcelDownloadDto()
        {

        }
    }
}