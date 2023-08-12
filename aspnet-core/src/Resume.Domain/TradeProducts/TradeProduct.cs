using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.TradeProducts
{
    public class TradeProduct : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Contents { get; set; }

        [NotNull]
        public virtual string ProductCategoryCode { get; set; }

        public virtual decimal UnitPrice { get; set; }

        public virtual decimal UnitPricePromotions { get; set; }

        [NotNull]
        public virtual string UnitCode { get; set; }

        public virtual int QuantityStock { get; set; }

        public virtual int QuantityOrdered { get; set; }

        public virtual int QuantitySafetyStock { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? OrderStateCode { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public TradeProduct()
        {

        }

        public TradeProduct(Guid id, string name, string contents, string productCategoryCode, decimal unitPrice, decimal unitPricePromotions, string unitCode, int quantityStock, int quantityOrdered, int quantitySafetyStock, string orderStateCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), TradeProductConsts.NameMaxLength, 0);
            Check.Length(contents, nameof(contents), TradeProductConsts.ContentsMaxLength, 0);
            Check.NotNull(productCategoryCode, nameof(productCategoryCode));
            Check.Length(productCategoryCode, nameof(productCategoryCode), TradeProductConsts.ProductCategoryCodeMaxLength, 0);
            Check.NotNull(unitCode, nameof(unitCode));
            Check.Length(unitCode, nameof(unitCode), TradeProductConsts.UnitCodeMaxLength, 0);
            Check.Length(orderStateCode, nameof(orderStateCode), TradeProductConsts.OrderStateCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeProductConsts.ExtendedInformationMaxLength, 0);
            Check.Length(status, nameof(status), TradeProductConsts.StatusMaxLength, 0);
            Name = name;
            Contents = contents;
            ProductCategoryCode = productCategoryCode;
            UnitPrice = unitPrice;
            UnitPricePromotions = unitPricePromotions;
            UnitCode = unitCode;
            QuantityStock = quantityStock;
            QuantityOrdered = quantityOrdered;
            QuantitySafetyStock = quantitySafetyStock;
            OrderStateCode = orderStateCode;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
        }

    }
}