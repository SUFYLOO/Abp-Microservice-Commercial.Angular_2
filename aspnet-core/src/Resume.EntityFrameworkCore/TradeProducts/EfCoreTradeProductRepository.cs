using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Resume.EntityFrameworkCore;

namespace Resume.TradeProducts
{
    public class EfCoreTradeProductRepository : EfCoreRepository<ResumeDbContext, TradeProduct, Guid>, ITradeProductRepository
    {
        public EfCoreTradeProductRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<TradeProduct>> GetListAsync(
            string filterText = null,
            string name = null,
            string contents = null,
            string productCategoryCode = null,
            decimal? unitPriceMin = null,
            decimal? unitPriceMax = null,
            decimal? unitPricePromotionsMin = null,
            decimal? unitPricePromotionsMax = null,
            string unitCode = null,
            int? quantityStockMin = null,
            int? quantityStockMax = null,
            int? quantityOrderedMin = null,
            int? quantityOrderedMax = null,
            int? quantitySafetyStockMin = null,
            int? quantitySafetyStockMax = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string orderStateCode = null,
            string status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, contents, productCategoryCode, unitPriceMin, unitPriceMax, unitPricePromotionsMin, unitPricePromotionsMax, unitCode, quantityStockMin, quantityStockMax, quantityOrderedMin, quantityOrderedMax, quantitySafetyStockMin, quantitySafetyStockMax, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, orderStateCode, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TradeProductConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string contents = null,
            string productCategoryCode = null,
            decimal? unitPriceMin = null,
            decimal? unitPriceMax = null,
            decimal? unitPricePromotionsMin = null,
            decimal? unitPricePromotionsMax = null,
            string unitCode = null,
            int? quantityStockMin = null,
            int? quantityStockMax = null,
            int? quantityOrderedMin = null,
            int? quantityOrderedMax = null,
            int? quantitySafetyStockMin = null,
            int? quantitySafetyStockMax = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string orderStateCode = null,
            string status = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, contents, productCategoryCode, unitPriceMin, unitPriceMax, unitPricePromotionsMin, unitPricePromotionsMax, unitCode, quantityStockMin, quantityStockMax, quantityOrderedMin, quantityOrderedMax, quantitySafetyStockMin, quantitySafetyStockMax, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, orderStateCode, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TradeProduct> ApplyFilter(
            IQueryable<TradeProduct> query,
            string filterText,
            string name = null,
            string contents = null,
            string productCategoryCode = null,
            decimal? unitPriceMin = null,
            decimal? unitPriceMax = null,
            decimal? unitPricePromotionsMin = null,
            decimal? unitPricePromotionsMax = null,
            string unitCode = null,
            int? quantityStockMin = null,
            int? quantityStockMax = null,
            int? quantityOrderedMin = null,
            int? quantityOrderedMax = null,
            int? quantitySafetyStockMin = null,
            int? quantitySafetyStockMax = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string orderStateCode = null,
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Contents.Contains(filterText) || e.ProductCategoryCode.Contains(filterText) || e.UnitCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.OrderStateCode.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(contents), e => e.Contents.Contains(contents))
                    .WhereIf(!string.IsNullOrWhiteSpace(productCategoryCode), e => e.ProductCategoryCode.Contains(productCategoryCode))
                    .WhereIf(unitPriceMin.HasValue, e => e.UnitPrice >= unitPriceMin.Value)
                    .WhereIf(unitPriceMax.HasValue, e => e.UnitPrice <= unitPriceMax.Value)
                    .WhereIf(unitPricePromotionsMin.HasValue, e => e.UnitPricePromotions >= unitPricePromotionsMin.Value)
                    .WhereIf(unitPricePromotionsMax.HasValue, e => e.UnitPricePromotions <= unitPricePromotionsMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(unitCode), e => e.UnitCode.Contains(unitCode))
                    .WhereIf(quantityStockMin.HasValue, e => e.QuantityStock >= quantityStockMin.Value)
                    .WhereIf(quantityStockMax.HasValue, e => e.QuantityStock <= quantityStockMax.Value)
                    .WhereIf(quantityOrderedMin.HasValue, e => e.QuantityOrdered >= quantityOrderedMin.Value)
                    .WhereIf(quantityOrderedMax.HasValue, e => e.QuantityOrdered <= quantityOrderedMax.Value)
                    .WhereIf(quantitySafetyStockMin.HasValue, e => e.QuantitySafetyStock >= quantitySafetyStockMin.Value)
                    .WhereIf(quantitySafetyStockMax.HasValue, e => e.QuantitySafetyStock <= quantitySafetyStockMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(extendedInformation), e => e.ExtendedInformation.Contains(extendedInformation))
                    .WhereIf(dateAMin.HasValue, e => e.DateA >= dateAMin.Value)
                    .WhereIf(dateAMax.HasValue, e => e.DateA <= dateAMax.Value)
                    .WhereIf(dateDMin.HasValue, e => e.DateD >= dateDMin.Value)
                    .WhereIf(dateDMax.HasValue, e => e.DateD <= dateDMax.Value)
                    .WhereIf(sortMin.HasValue, e => e.Sort >= sortMin.Value)
                    .WhereIf(sortMax.HasValue, e => e.Sort <= sortMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(orderStateCode), e => e.OrderStateCode.Contains(orderStateCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}