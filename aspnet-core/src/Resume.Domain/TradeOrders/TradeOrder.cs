using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.TradeOrders
{
    public class TradeOrder : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid KeyId { get; set; }

        [NotNull]
        public virtual string OrderNumber { get; set; }

        public virtual DateTime DateOrder { get; set; }

        public virtual DateTime? DateNeed { get; set; }

        public virtual DateTime? DateDelivery { get; set; }

        [CanBeNull]
        public virtual string? DeliveryMethodCode { get; set; }

        [CanBeNull]
        public virtual string? DeliveryZipCode { get; set; }

        [CanBeNull]
        public virtual string? DeliveryCityCode { get; set; }

        [CanBeNull]
        public virtual string? DeliveryAreaCode { get; set; }

        [CanBeNull]
        public virtual string? DeliveryAddress { get; set; }

        public virtual decimal DeliveryFee { get; set; }

        [CanBeNull]
        public virtual string? UserName { get; set; }

        [NotNull]
        public virtual string OrderStateCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public TradeOrder()
        {

        }

        public TradeOrder(Guid id, Guid keyId, string orderNumber, DateTime dateOrder, string deliveryMethodCode, string deliveryZipCode, string deliveryCityCode, string deliveryAreaCode, string deliveryAddress, decimal deliveryFee, string userName, string orderStateCode, DateTime? dateNeed = null, DateTime? dateDelivery = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(orderNumber, nameof(orderNumber));
            Check.Length(orderNumber, nameof(orderNumber), TradeOrderConsts.OrderNumberMaxLength, 0);
            Check.Length(deliveryMethodCode, nameof(deliveryMethodCode), TradeOrderConsts.DeliveryMethodCodeMaxLength, 0);
            Check.Length(deliveryZipCode, nameof(deliveryZipCode), TradeOrderConsts.DeliveryZipCodeMaxLength, 0);
            Check.Length(deliveryCityCode, nameof(deliveryCityCode), TradeOrderConsts.DeliveryCityCodeMaxLength, 0);
            Check.Length(deliveryAreaCode, nameof(deliveryAreaCode), TradeOrderConsts.DeliveryAreaCodeMaxLength, 0);
            Check.Length(deliveryAddress, nameof(deliveryAddress), TradeOrderConsts.DeliveryAddressMaxLength, 0);
            Check.Length(userName, nameof(userName), TradeOrderConsts.UserNameMaxLength, 0);
            Check.NotNull(orderStateCode, nameof(orderStateCode));
            Check.Length(orderStateCode, nameof(orderStateCode), TradeOrderConsts.OrderStateCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeOrderConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), TradeOrderConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), TradeOrderConsts.StatusMaxLength, 0);
            KeyId = keyId;
            OrderNumber = orderNumber;
            DateOrder = dateOrder;
            DeliveryMethodCode = deliveryMethodCode;
            DeliveryZipCode = deliveryZipCode;
            DeliveryCityCode = deliveryCityCode;
            DeliveryAreaCode = deliveryAreaCode;
            DeliveryAddress = deliveryAddress;
            DeliveryFee = deliveryFee;
            UserName = userName;
            OrderStateCode = orderStateCode;
            DateNeed = dateNeed;
            DateDelivery = dateDelivery;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}