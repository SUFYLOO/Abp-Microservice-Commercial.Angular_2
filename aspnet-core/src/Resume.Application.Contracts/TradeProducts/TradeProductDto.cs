using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Resume.TradeProducts
{
    public class TradeProductDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; }
        public string? Contents { get; set; }
        public string ProductCategoryCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPricePromotions { get; set; }
        public string UnitCode { get; set; }
        public int QuantityStock { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantitySafetyStock { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? OrderStateCode { get; set; }
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}