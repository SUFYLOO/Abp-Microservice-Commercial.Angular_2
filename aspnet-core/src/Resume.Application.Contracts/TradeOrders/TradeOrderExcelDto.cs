using System;

namespace Resume.TradeOrders
{
    public class TradeOrderExcelDto
    {
        public Guid KeyId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime? DateNeed { get; set; }
        public DateTime? DateDelivery { get; set; }
        public string? DeliveryMethodCode { get; set; }
        public string? DeliveryZipCode { get; set; }
        public string? DeliveryCityCode { get; set; }
        public string? DeliveryAreaCode { get; set; }
        public string? DeliveryAddress { get; set; }
        public decimal DeliveryFee { get; set; }
        public string? UserName { get; set; }
        public string OrderStateCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}