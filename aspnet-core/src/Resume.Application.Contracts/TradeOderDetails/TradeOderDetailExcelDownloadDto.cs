using Volo.Abp.Application.Dtos;
using System;

namespace Resume.TradeOderDetails
{
    public class TradeOderDetailExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? TradeOrderId { get; set; }
        public Guid? TradeProductId { get; set; }
        public decimal? UnitPriceMin { get; set; }
        public decimal? UnitPriceMax { get; set; }
        public int? QuantityMin { get; set; }
        public int? QuantityMax { get; set; }
        public string? OrderDetailStateCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public TradeOderDetailExcelDownloadDto()
        {

        }
    }
}