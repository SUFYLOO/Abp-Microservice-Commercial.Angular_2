using Volo.Abp.Application.Dtos;
using System;

namespace Resume.TradeOrders
{
    public class GetTradeOrdersInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? KeyId { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? DateOrderMin { get; set; }
        public DateTime? DateOrderMax { get; set; }
        public DateTime? DateNeedMin { get; set; }
        public DateTime? DateNeedMax { get; set; }
        public DateTime? DateDeliveryMin { get; set; }
        public DateTime? DateDeliveryMax { get; set; }
        public string? DeliveryMethodCode { get; set; }
        public string? DeliveryZipCode { get; set; }
        public string? DeliveryCityCode { get; set; }
        public string? DeliveryAreaCode { get; set; }
        public string? DeliveryAddress { get; set; }
        public decimal? DeliveryFeeMin { get; set; }
        public decimal? DeliveryFeeMax { get; set; }
        public string? UserName { get; set; }
        public string? OrderStateCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetTradeOrdersInput()
        {

        }
    }
}