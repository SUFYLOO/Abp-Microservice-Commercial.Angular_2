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

namespace Resume.TradeOderDetails
{
    public class EfCoreTradeOderDetailRepository : EfCoreRepository<ResumeDbContext, TradeOderDetail, Guid>, ITradeOderDetailRepository
    {
        public EfCoreTradeOderDetailRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<TradeOderDetail>> GetListAsync(
            string filterText = null,
            Guid? tradeOrderId = null,
            Guid? tradeProductId = null,
            decimal? unitPriceMin = null,
            decimal? unitPriceMax = null,
            int? quantityMin = null,
            int? quantityMax = null,
            string orderDetailStateCode = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, tradeOrderId, tradeProductId, unitPriceMin, unitPriceMax, quantityMin, quantityMax, orderDetailStateCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TradeOderDetailConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? tradeOrderId = null,
            Guid? tradeProductId = null,
            decimal? unitPriceMin = null,
            decimal? unitPriceMax = null,
            int? quantityMin = null,
            int? quantityMax = null,
            string orderDetailStateCode = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, tradeOrderId, tradeProductId, unitPriceMin, unitPriceMax, quantityMin, quantityMax, orderDetailStateCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TradeOderDetail> ApplyFilter(
            IQueryable<TradeOderDetail> query,
            string filterText,
            Guid? tradeOrderId = null,
            Guid? tradeProductId = null,
            decimal? unitPriceMin = null,
            decimal? unitPriceMax = null,
            int? quantityMin = null,
            int? quantityMax = null,
            string orderDetailStateCode = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.OrderDetailStateCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(tradeOrderId.HasValue, e => e.TradeOrderId == tradeOrderId)
                    .WhereIf(tradeProductId.HasValue, e => e.TradeProductId == tradeProductId)
                    .WhereIf(unitPriceMin.HasValue, e => e.UnitPrice >= unitPriceMin.Value)
                    .WhereIf(unitPriceMax.HasValue, e => e.UnitPrice <= unitPriceMax.Value)
                    .WhereIf(quantityMin.HasValue, e => e.Quantity >= quantityMin.Value)
                    .WhereIf(quantityMax.HasValue, e => e.Quantity <= quantityMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(orderDetailStateCode), e => e.OrderDetailStateCode.Contains(orderDetailStateCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(extendedInformation), e => e.ExtendedInformation.Contains(extendedInformation))
                    .WhereIf(dateAMin.HasValue, e => e.DateA >= dateAMin.Value)
                    .WhereIf(dateAMax.HasValue, e => e.DateA <= dateAMax.Value)
                    .WhereIf(dateDMin.HasValue, e => e.DateD >= dateDMin.Value)
                    .WhereIf(dateDMax.HasValue, e => e.DateD <= dateDMax.Value)
                    .WhereIf(sortMin.HasValue, e => e.Sort >= sortMin.Value)
                    .WhereIf(sortMax.HasValue, e => e.Sort <= sortMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.Contains(note))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}