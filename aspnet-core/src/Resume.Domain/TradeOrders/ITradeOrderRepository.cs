using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.TradeOrders
{
    public interface ITradeOrderRepository : IRepository<TradeOrder, Guid>
    {
        Task<List<TradeOrder>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}