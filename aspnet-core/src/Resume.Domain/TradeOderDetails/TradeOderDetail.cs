using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.TradeOderDetails
{
    public class TradeOderDetail : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid TradeOrderId { get; set; }

        public virtual Guid TradeProductId { get; set; }

        public virtual decimal UnitPrice { get; set; }

        public virtual int Quantity { get; set; }

        [NotNull]
        public virtual string OrderDetailStateCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public TradeOderDetail()
        {

        }

        public TradeOderDetail(Guid id, Guid tradeOrderId, Guid tradeProductId, decimal unitPrice, int quantity, string orderDetailStateCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(orderDetailStateCode, nameof(orderDetailStateCode));
            Check.Length(orderDetailStateCode, nameof(orderDetailStateCode), TradeOderDetailConsts.OrderDetailStateCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeOderDetailConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), TradeOderDetailConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), TradeOderDetailConsts.StatusMaxLength, 0);
            TradeOrderId = tradeOrderId;
            TradeProductId = tradeProductId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            OrderDetailStateCode = orderDetailStateCode;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}