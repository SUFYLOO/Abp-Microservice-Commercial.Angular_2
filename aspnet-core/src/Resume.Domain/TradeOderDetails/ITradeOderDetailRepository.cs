using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.TradeOderDetails
{
    public interface ITradeOderDetailRepository : IRepository<TradeOderDetail, Guid>
    {
        Task<List<TradeOderDetail>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}