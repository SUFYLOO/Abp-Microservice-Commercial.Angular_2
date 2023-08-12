using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.TradeProducts
{
    public class TradeProductUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(TradeProductConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(TradeProductConsts.ContentsMaxLength)]
        public string? Contents { get; set; }
        [Required]
        [StringLength(TradeProductConsts.ProductCategoryCodeMaxLength)]
        public string ProductCategoryCode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPricePromotions { get; set; }
        [Required]
        [StringLength(TradeProductConsts.UnitCodeMaxLength)]
        public string UnitCode { get; set; }
        public int QuantityStock { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantitySafetyStock { get; set; }
        [StringLength(TradeProductConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(TradeProductConsts.OrderStateCodeMaxLength)]
        public string? OrderStateCode { get; set; }
        [StringLength(TradeProductConsts.StatusMaxLength)]
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}