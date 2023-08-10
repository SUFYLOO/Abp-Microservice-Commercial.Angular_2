using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.TradeProducts
{
    public class TradeProductManager : DomainService
    {
        private readonly ITradeProductRepository _tradeProductRepository;

        public TradeProductManager(ITradeProductRepository tradeProductRepository)
        {
            _tradeProductRepository = tradeProductRepository;
        }

        public async Task<TradeProduct> CreateAsync(
        string name, string contents, string productCategoryCode, decimal unitPrice, decimal unitPricePromotions, string unitCode, int quantityStock, int quantityOrdered, int quantitySafetyStock, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string orderStateCode, string status)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TradeProductConsts.NameMaxLength);
            Check.Length(contents, nameof(contents), TradeProductConsts.ContentsMaxLength);
            Check.NotNullOrWhiteSpace(productCategoryCode, nameof(productCategoryCode));
            Check.Length(productCategoryCode, nameof(productCategoryCode), TradeProductConsts.ProductCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(unitCode, nameof(unitCode));
            Check.Length(unitCode, nameof(unitCode), TradeProductConsts.UnitCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeProductConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(orderStateCode, nameof(orderStateCode), TradeProductConsts.OrderStateCodeMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), TradeProductConsts.StatusMaxLength);

            var tradeProduct = new TradeProduct(
             GuidGenerator.Create(),
             name, contents, productCategoryCode, unitPrice, unitPricePromotions, unitCode, quantityStock, quantityOrdered, quantitySafetyStock, extendedInformation, dateA, dateD, sort, orderStateCode, status
             );

            return await _tradeProductRepository.InsertAsync(tradeProduct);
        }

        public async Task<TradeProduct> UpdateAsync(
            Guid id,
            string name, string contents, string productCategoryCode, decimal unitPrice, decimal unitPricePromotions, string unitCode, int quantityStock, int quantityOrdered, int quantitySafetyStock, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string orderStateCode, string status, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), TradeProductConsts.NameMaxLength);
            Check.Length(contents, nameof(contents), TradeProductConsts.ContentsMaxLength);
            Check.NotNullOrWhiteSpace(productCategoryCode, nameof(productCategoryCode));
            Check.Length(productCategoryCode, nameof(productCategoryCode), TradeProductConsts.ProductCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(unitCode, nameof(unitCode));
            Check.Length(unitCode, nameof(unitCode), TradeProductConsts.UnitCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), TradeProductConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(orderStateCode, nameof(orderStateCode), TradeProductConsts.OrderStateCodeMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), TradeProductConsts.StatusMaxLength);

            var tradeProduct = await _tradeProductRepository.GetAsync(id);

            tradeProduct.Name = name;
            tradeProduct.Contents = contents;
            tradeProduct.ProductCategoryCode = productCategoryCode;
            tradeProduct.UnitPrice = unitPrice;
            tradeProduct.UnitPricePromotions = unitPricePromotions;
            tradeProduct.UnitCode = unitCode;
            tradeProduct.QuantityStock = quantityStock;
            tradeProduct.QuantityOrdered = quantityOrdered;
            tradeProduct.QuantitySafetyStock = quantitySafetyStock;
            tradeProduct.ExtendedInformation = extendedInformation;
            tradeProduct.DateA = dateA;
            tradeProduct.DateD = dateD;
            tradeProduct.Sort = sort;
            tradeProduct.OrderStateCode = orderStateCode;
            tradeProduct.Status = status;

            tradeProduct.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _tradeProductRepository.UpdateAsync(tradeProduct);
        }

    }
}