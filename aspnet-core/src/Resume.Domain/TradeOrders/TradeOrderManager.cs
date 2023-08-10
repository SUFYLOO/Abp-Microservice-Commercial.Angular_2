using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.TradeOrders
{
    public class TradeOrderManager : DomainService
    {
        private readonly ITradeOrderRepository _tradeOrderRepository;

        public TradeOrderManager(ITradeOrderRepository tradeOrderRepository)
        {
            _tradeOrderRepository = tradeOrderRepository;
        }

        public async Task<TradeOrder> CreateAsync(
        Guid keyId, string orderNumber, DateTime dateOrder, string deliveryMethodCode, string deliveryZipCode, string deliveryCityCode, string deliveryAreaCode, string deliveryAddress, decimal deliveryFee, string userName, string orderStateCode, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, DateTime? dateNeed = null, DateTime? dateDelivery = null)
        {
            Check.NotNullOrWhiteSpace(orderNumber, nameof(orderNumber));
            Check.Length(orderNumber, nameof(orderNumber), TradeOrderConsts.OrderNumberMaxLength);
            Check.NotNull(dateOrder, nameof(dateOrder));
            Check.Length(deliveryMethodCode, nameof(deliveryMethodCode), TradeOrderConsts.DeliveryMethodCodeMaxLength);
            Check.Length(deliveryZipCode, nameof(deliveryZipCode), TradeOrderConsts.DeliveryZipCodeMaxLength);
            Check.Length(deliveryCityCode, nameof(deliveryCityCode), TradeOrderConsts.DeliveryCityCodeMaxLength);
            Check.Length(deliveryAreaCode, nameof(deliveryAreaCode), TradeOrderConsts.DeliveryAreaCodeMaxLength);
            Check.Length(deliveryAddress, nameof(deliveryAddress), TradeOrderConsts.DeliveryAddressMaxLength);
            Check.Length(userName, nameof(userName), TradeOrderConsts.UserNameMaxLength);
            Check.NotNullOrWhiteSpace(orderStateCode, nameof(orderStateCode));
            Check.Length(orderStateCode, nameof(orderStateCode), TradeOrderConsts.OrderStateCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeOrderConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), TradeOrderConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), TradeOrderConsts.StatusMaxLength);

            var tradeOrder = new TradeOrder(
             GuidGenerator.Create(),
             keyId, orderNumber, dateOrder, deliveryMethodCode, deliveryZipCode, deliveryCityCode, deliveryAreaCode, deliveryAddress, deliveryFee, userName, orderStateCode, extendedInformation, dateA, dateD, sort, note, status, dateNeed, dateDelivery
             );

            return await _tradeOrderRepository.InsertAsync(tradeOrder);
        }

        public async Task<TradeOrder> UpdateAsync(
            Guid id,
            Guid keyId, string orderNumber, DateTime dateOrder, string deliveryMethodCode, string deliveryZipCode, string deliveryCityCode, string deliveryAreaCode, string deliveryAddress, decimal deliveryFee, string userName, string orderStateCode, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, DateTime? dateNeed = null, DateTime? dateDelivery = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(orderNumber, nameof(orderNumber));
            Check.Length(orderNumber, nameof(orderNumber), TradeOrderConsts.OrderNumberMaxLength);
            Check.NotNull(dateOrder, nameof(dateOrder));
            Check.Length(deliveryMethodCode, nameof(deliveryMethodCode), TradeOrderConsts.DeliveryMethodCodeMaxLength);
            Check.Length(deliveryZipCode, nameof(deliveryZipCode), TradeOrderConsts.DeliveryZipCodeMaxLength);
            Check.Length(deliveryCityCode, nameof(deliveryCityCode), TradeOrderConsts.DeliveryCityCodeMaxLength);
            Check.Length(deliveryAreaCode, nameof(deliveryAreaCode), TradeOrderConsts.DeliveryAreaCodeMaxLength);
            Check.Length(deliveryAddress, nameof(deliveryAddress), TradeOrderConsts.DeliveryAddressMaxLength);
            Check.Length(userName, nameof(userName), TradeOrderConsts.UserNameMaxLength);
            Check.NotNullOrWhiteSpace(orderStateCode, nameof(orderStateCode));
            Check.Length(orderStateCode, nameof(orderStateCode), TradeOrderConsts.OrderStateCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeOrderConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), TradeOrderConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), TradeOrderConsts.StatusMaxLength);

            var tradeOrder = await _tradeOrderRepository.GetAsync(id);

            tradeOrder.KeyId = keyId;
            tradeOrder.OrderNumber = orderNumber;
            tradeOrder.DateOrder = dateOrder;
            tradeOrder.DeliveryMethodCode = deliveryMethodCode;
            tradeOrder.DeliveryZipCode = deliveryZipCode;
            tradeOrder.DeliveryCityCode = deliveryCityCode;
            tradeOrder.DeliveryAreaCode = deliveryAreaCode;
            tradeOrder.DeliveryAddress = deliveryAddress;
            tradeOrder.DeliveryFee = deliveryFee;
            tradeOrder.UserName = userName;
            tradeOrder.OrderStateCode = orderStateCode;
            tradeOrder.ExtendedInformation = extendedInformation;
            tradeOrder.DateA = dateA;
            tradeOrder.DateD = dateD;
            tradeOrder.Sort = sort;
            tradeOrder.Note = note;
            tradeOrder.Status = status;
            tradeOrder.DateNeed = dateNeed;
            tradeOrder.DateDelivery = dateDelivery;

            tradeOrder.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _tradeOrderRepository.UpdateAsync(tradeOrder);
        }

    }
}