using Volo.Abp.Application.Dtos;
using System;

namespace Resume.TradeProducts
{
    public class TradeProductExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? Contents { get; set; }
        public string? ProductCategoryCode { get; set; }
        public decimal? UnitPriceMin { get; set; }
        public decimal? UnitPriceMax { get; set; }
        public decimal? UnitPricePromotionsMin { get; set; }
        public decimal? UnitPricePromotionsMax { get; set; }
        public string? UnitCode { get; set; }
        public int? QuantityStockMin { get; set; }
        public int? QuantityStockMax { get; set; }
        public int? QuantityOrderedMin { get; set; }
        public int? QuantityOrderedMax { get; set; }
        public int? QuantitySafetyStockMin { get; set; }
        public int? QuantitySafetyStockMax { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? OrderStateCode { get; set; }
        public string? Status { get; set; }

        public TradeProductExcelDownloadDto()
        {

        }
    }
}