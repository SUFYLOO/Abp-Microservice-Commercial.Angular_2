using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ShareSendQueues
{
    public class ShareSendQueueExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string? SendTypeCode { get; set; }
        public string? FromAddr { get; set; }
        public string? ToAddr { get; set; }
        public string? TitleContents { get; set; }
        public string? Contents { get; set; }
        public int? RetryMin { get; set; }
        public int? RetryMax { get; set; }
        public bool? Sucess { get; set; }
        public bool? Suspend { get; set; }
        public DateTime? DateSendMin { get; set; }
        public DateTime? DateSendMax { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public ShareSendQueueExcelDownloadDto()
        {

        }
    }
}