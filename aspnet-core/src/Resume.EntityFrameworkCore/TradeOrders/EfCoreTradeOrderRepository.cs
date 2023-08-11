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

namespace Resume.TradeOrders
{
    public class EfCoreTradeOrderRepository : EfCoreRepository<ResumeDbContext, TradeOrder, Guid>, ITradeOrderRepository
    {
        public EfCoreTradeOrderRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<TradeOrder>> GetListAsync(
            string filterText = null,
            Guid? keyId = null,
            string orderNumber = null,
            DateTime? dateOrderMin = null,
            DateTime? dateOrderMax = null,
            DateTime? dateNeedMin = null,
            DateTime? dateNeedMax = null,
            DateTime? dateDeliveryMin = null,
            DateTime? dateDeliveryMax = null,
            string deliveryMethodCode = null,
            string deliveryZipCode = null,
            string deliveryCityCode = null,
            string deliveryAreaCode = null,
            string deliveryAddress = null,
            decimal? deliveryFeeMin = null,
            decimal? deliveryFeeMax = null,
            string userName = null,
            string orderStateCode = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, keyId, orderNumber, dateOrderMin, dateOrderMax, dateNeedMin, dateNeedMax, dateDeliveryMin, dateDeliveryMax, deliveryMethodCode, deliveryZipCode, deliveryCityCode, deliveryAreaCode, deliveryAddress, deliveryFeeMin, deliveryFeeMax, userName, orderStateCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TradeOrderConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? keyId = null,
            string orderNumber = null,
            DateTime? dateOrderMin = null,
            DateTime? dateOrderMax = null,
            DateTime? dateNeedMin = null,
            DateTime? dateNeedMax = null,
            DateTime? dateDeliveryMin = null,
            DateTime? dateDeliveryMax = null,
            string deliveryMethodCode = null,
            string deliveryZipCode = null,
            string deliveryCityCode = null,
            string deliveryAreaCode = null,
            string deliveryAddress = null,
            decimal? deliveryFeeMin = null,
            decimal? deliveryFeeMax = null,
            string userName = null,
            string orderStateCode = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, keyId, orderNumber, dateOrderMin, dateOrderMax, dateNeedMin, dateNeedMax, dateDeliveryMin, dateDeliveryMax, deliveryMethodCode, deliveryZipCode, deliveryCityCode, deliveryAreaCode, deliveryAddress, deliveryFeeMin, deliveryFeeMax, userName, orderStateCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TradeOrder> ApplyFilter(
            IQueryable<TradeOrder> query,
            string filterText,
            Guid? keyId = null,
            string orderNumber = null,
            DateTime? dateOrderMin = null,
            DateTime? dateOrderMax = null,
            DateTime? dateNeedMin = null,
            DateTime? dateNeedMax = null,
            DateTime? dateDeliveryMin = null,
            DateTime? dateDeliveryMax = null,
            string deliveryMethodCode = null,
            string deliveryZipCode = null,
            string deliveryCityCode = null,
            string deliveryAreaCode = null,
            string deliveryAddress = null,
            decimal? deliveryFeeMin = null,
            decimal? deliveryFeeMax = null,
            string userName = null,
            string orderStateCode = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.OrderNumber.Contains(filterText) || e.DeliveryMethodCode.Contains(filterText) || e.DeliveryZipCode.Contains(filterText) || e.DeliveryCityCode.Contains(filterText) || e.DeliveryAreaCode.Contains(filterText) || e.DeliveryAddress.Contains(filterText) || e.UserName.Contains(filterText) || e.OrderStateCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(keyId.HasValue, e => e.KeyId == keyId)
                    .WhereIf(!string.IsNullOrWhiteSpace(orderNumber), e => e.OrderNumber.Contains(orderNumber))
                    .WhereIf(dateOrderMin.HasValue, e => e.DateOrder >= dateOrderMin.Value)
                    .WhereIf(dateOrderMax.HasValue, e => e.DateOrder <= dateOrderMax.Value)
                    .WhereIf(dateNeedMin.HasValue, e => e.DateNeed >= dateNeedMin.Value)
                    .WhereIf(dateNeedMax.HasValue, e => e.DateNeed <= dateNeedMax.Value)
                    .WhereIf(dateDeliveryMin.HasValue, e => e.DateDelivery >= dateDeliveryMin.Value)
                    .WhereIf(dateDeliveryMax.HasValue, e => e.DateDelivery <= dateDeliveryMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(deliveryMethodCode), e => e.DeliveryMethodCode.Contains(deliveryMethodCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(deliveryZipCode), e => e.DeliveryZipCode.Contains(deliveryZipCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(deliveryCityCode), e => e.DeliveryCityCode.Contains(deliveryCityCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(deliveryAreaCode), e => e.DeliveryAreaCode.Contains(deliveryAreaCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(deliveryAddress), e => e.DeliveryAddress.Contains(deliveryAddress))
                    .WhereIf(deliveryFeeMin.HasValue, e => e.DeliveryFee >= deliveryFeeMin.Value)
                    .WhereIf(deliveryFeeMax.HasValue, e => e.DeliveryFee <= deliveryFeeMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(userName), e => e.UserName.Contains(userName))
                    .WhereIf(!string.IsNullOrWhiteSpace(orderStateCode), e => e.OrderStateCode.Contains(orderStateCode))
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