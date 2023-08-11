using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Resume.Permissions;
using Resume.TradeProducts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.TradeProducts
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.TradeProducts.Default)]
    public class TradeProductsAppService : ApplicationService, ITradeProductsAppService
    {
        private readonly IDistributedCache<TradeProductExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ITradeProductRepository _tradeProductRepository;
        private readonly TradeProductManager _tradeProductManager;

        public TradeProductsAppService(ITradeProductRepository tradeProductRepository, TradeProductManager tradeProductManager, IDistributedCache<TradeProductExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _tradeProductRepository = tradeProductRepository;
            _tradeProductManager = tradeProductManager;
        }

        public virtual async Task<PagedResultDto<TradeProductDto>> GetListAsync(GetTradeProductsInput input)
        {
            var totalCount = await _tradeProductRepository.GetCountAsync(input.FilterText, input.Name, input.Contents, input.ProductCategoryCode, input.UnitPriceMin, input.UnitPriceMax, input.UnitPricePromotionsMin, input.UnitPricePromotionsMax, input.UnitCode, input.QuantityStockMin, input.QuantityStockMax, input.QuantityOrderedMin, input.QuantityOrderedMax, input.QuantitySafetyStockMin, input.QuantitySafetyStockMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.OrderStateCode, input.Status);
            var items = await _tradeProductRepository.GetListAsync(input.FilterText, input.Name, input.Contents, input.ProductCategoryCode, input.UnitPriceMin, input.UnitPriceMax, input.UnitPricePromotionsMin, input.UnitPricePromotionsMax, input.UnitCode, input.QuantityStockMin, input.QuantityStockMax, input.QuantityOrderedMin, input.QuantityOrderedMax, input.QuantitySafetyStockMin, input.QuantitySafetyStockMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.OrderStateCode, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TradeProductDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TradeProduct>, List<TradeProductDto>>(items)
            };
        }

        public virtual async Task<TradeProductDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<TradeProduct, TradeProductDto>(await _tradeProductRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.TradeProducts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _tradeProductRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.TradeProducts.Create)]
        public virtual async Task<TradeProductDto> CreateAsync(TradeProductCreateDto input)
        {

            var tradeProduct = await _tradeProductManager.CreateAsync(
            input.Name, input.Contents, input.ProductCategoryCode, input.UnitPrice, input.UnitPricePromotions, input.UnitCode, input.QuantityStock, input.QuantityOrdered, input.QuantitySafetyStock, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.OrderStateCode, input.Status
            );

            return ObjectMapper.Map<TradeProduct, TradeProductDto>(tradeProduct);
        }

        [Authorize(ResumePermissions.TradeProducts.Edit)]
        public virtual async Task<TradeProductDto> UpdateAsync(Guid id, TradeProductUpdateDto input)
        {

            var tradeProduct = await _tradeProductManager.UpdateAsync(
            id,
            input.Name, input.Contents, input.ProductCategoryCode, input.UnitPrice, input.UnitPricePromotions, input.UnitCode, input.QuantityStock, input.QuantityOrdered, input.QuantitySafetyStock, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.OrderStateCode, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<TradeProduct, TradeProductDto>(tradeProduct);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeProductExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tradeProductRepository.GetListAsync(input.FilterText, input.Name, input.Contents, input.ProductCategoryCode, input.UnitPriceMin, input.UnitPriceMax, input.UnitPricePromotionsMin, input.UnitPricePromotionsMax, input.UnitCode, input.QuantityStockMin, input.QuantityStockMax, input.QuantityOrderedMin, input.QuantityOrderedMax, input.QuantitySafetyStockMin, input.QuantitySafetyStockMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.OrderStateCode, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TradeProduct>, List<TradeProductExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "TradeProducts.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new TradeProductExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}