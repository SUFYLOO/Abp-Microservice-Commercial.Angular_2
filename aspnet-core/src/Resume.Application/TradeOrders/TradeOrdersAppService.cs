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
using Resume.TradeOrders;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.TradeOrders
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.TradeOrders.Default)]
    public class TradeOrdersAppService : ApplicationService, ITradeOrdersAppService
    {
        private readonly IDistributedCache<TradeOrderExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ITradeOrderRepository _tradeOrderRepository;
        private readonly TradeOrderManager _tradeOrderManager;

        public TradeOrdersAppService(ITradeOrderRepository tradeOrderRepository, TradeOrderManager tradeOrderManager, IDistributedCache<TradeOrderExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _tradeOrderRepository = tradeOrderRepository;
            _tradeOrderManager = tradeOrderManager;
        }

        public virtual async Task<PagedResultDto<TradeOrderDto>> GetListAsync(GetTradeOrdersInput input)
        {
            var totalCount = await _tradeOrderRepository.GetCountAsync(input.FilterText, input.KeyId, input.OrderNumber, input.DateOrderMin, input.DateOrderMax, input.DateNeedMin, input.DateNeedMax, input.DateDeliveryMin, input.DateDeliveryMax, input.DeliveryMethodCode, input.DeliveryZipCode, input.DeliveryCityCode, input.DeliveryAreaCode, input.DeliveryAddress, input.DeliveryFeeMin, input.DeliveryFeeMax, input.UserName, input.OrderStateCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _tradeOrderRepository.GetListAsync(input.FilterText, input.KeyId, input.OrderNumber, input.DateOrderMin, input.DateOrderMax, input.DateNeedMin, input.DateNeedMax, input.DateDeliveryMin, input.DateDeliveryMax, input.DeliveryMethodCode, input.DeliveryZipCode, input.DeliveryCityCode, input.DeliveryAreaCode, input.DeliveryAddress, input.DeliveryFeeMin, input.DeliveryFeeMax, input.UserName, input.OrderStateCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TradeOrderDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TradeOrder>, List<TradeOrderDto>>(items)
            };
        }

        public virtual async Task<TradeOrderDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<TradeOrder, TradeOrderDto>(await _tradeOrderRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.TradeOrders.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _tradeOrderRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.TradeOrders.Create)]
        public virtual async Task<TradeOrderDto> CreateAsync(TradeOrderCreateDto input)
        {

            var tradeOrder = await _tradeOrderManager.CreateAsync(
            input.KeyId, input.OrderNumber, input.DateOrder, input.DeliveryMethodCode, input.DeliveryZipCode, input.DeliveryCityCode, input.DeliveryAreaCode, input.DeliveryAddress, input.DeliveryFee, input.UserName, input.OrderStateCode, input.DateNeed, input.DateDelivery, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<TradeOrder, TradeOrderDto>(tradeOrder);
        }

        [Authorize(ResumePermissions.TradeOrders.Edit)]
        public virtual async Task<TradeOrderDto> UpdateAsync(Guid id, TradeOrderUpdateDto input)
        {

            var tradeOrder = await _tradeOrderManager.UpdateAsync(
            id,
            input.KeyId, input.OrderNumber, input.DateOrder, input.DeliveryMethodCode, input.DeliveryZipCode, input.DeliveryCityCode, input.DeliveryAreaCode, input.DeliveryAddress, input.DeliveryFee, input.UserName, input.OrderStateCode, input.DateNeed, input.DateDelivery, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<TradeOrder, TradeOrderDto>(tradeOrder);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeOrderExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tradeOrderRepository.GetListAsync(input.FilterText, input.KeyId, input.OrderNumber, input.DateOrderMin, input.DateOrderMax, input.DateNeedMin, input.DateNeedMax, input.DateDeliveryMin, input.DateDeliveryMax, input.DeliveryMethodCode, input.DeliveryZipCode, input.DeliveryCityCode, input.DeliveryAreaCode, input.DeliveryAddress, input.DeliveryFeeMin, input.DeliveryFeeMax, input.UserName, input.OrderStateCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TradeOrder>, List<TradeOrderExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "TradeOrders.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new TradeOrderExcelDownloadTokenCacheItem { Token = token },
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