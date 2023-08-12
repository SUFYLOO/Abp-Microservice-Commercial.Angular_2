using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.TradeOderDetails
{
    public class TradeOderDetailUpdateDto : IHasConcurrencyStamp
    {
        public Guid TradeOrderId { get; set; }
        public Guid TradeProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [Required]
        [StringLength(TradeOderDetailConsts.OrderDetailStateCodeMaxLength)]
        public string OrderDetailStateCode { get; set; }
        [StringLength(TradeOderDetailConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(TradeOderDetailConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(TradeOderDetailConsts.StatusMaxLength)]
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}