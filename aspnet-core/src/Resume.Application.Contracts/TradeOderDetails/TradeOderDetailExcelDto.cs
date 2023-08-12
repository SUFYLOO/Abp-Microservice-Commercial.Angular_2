using System;

namespace Resume.TradeOderDetails
{
    public class TradeOderDetailExcelDto
    {
        public Guid TradeOrderId { get; set; }
        public Guid TradeProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string OrderDetailStateCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}