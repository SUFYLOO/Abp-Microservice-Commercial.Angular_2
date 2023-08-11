using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.TradeOrders
{
    public class TradeOrderCreateDto
    {
        public Guid KeyId { get; set; }
        [Required]
        [StringLength(TradeOrderConsts.OrderNumberMaxLength)]
        public string OrderNumber { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime? DateNeed { get; set; }
        public DateTime? DateDelivery { get; set; }
        [StringLength(TradeOrderConsts.DeliveryMethodCodeMaxLength)]
        public string? DeliveryMethodCode { get; set; }
        [StringLength(TradeOrderConsts.DeliveryZipCodeMaxLength)]
        public string? DeliveryZipCode { get; set; }
        [StringLength(TradeOrderConsts.DeliveryCityCodeMaxLength)]
        public string? DeliveryCityCode { get; set; }
        [StringLength(TradeOrderConsts.DeliveryAreaCodeMaxLength)]
        public string? DeliveryAreaCode { get; set; }
        [StringLength(TradeOrderConsts.DeliveryAddressMaxLength)]
        public string? DeliveryAddress { get; set; }
        public decimal DeliveryFee { get; set; }
        [StringLength(TradeOrderConsts.UserNameMaxLength)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(TradeOrderConsts.OrderStateCodeMaxLength)]
        public string OrderStateCode { get; set; }
        [StringLength(TradeOrderConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        [StringLength(TradeOrderConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(TradeOrderConsts.StatusMaxLength)]
        public string Status { get; set; }
    }
}