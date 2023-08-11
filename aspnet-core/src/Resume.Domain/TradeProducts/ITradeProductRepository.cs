using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.TradeProducts
{
    public interface ITradeProductRepository : IRepository<TradeProduct, Guid>
    {
        Task<List<TradeProduct>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}