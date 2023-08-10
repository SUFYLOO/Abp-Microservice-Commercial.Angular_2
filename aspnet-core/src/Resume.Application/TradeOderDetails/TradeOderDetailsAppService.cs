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
using Resume.TradeOderDetails;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.TradeOderDetails
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.TradeOderDetails.Default)]
    public class TradeOderDetailsAppService : ApplicationService, ITradeOderDetailsAppService
    {
        private readonly IDistributedCache<TradeOderDetailExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ITradeOderDetailRepository _tradeOderDetailRepository;
        private readonly TradeOderDetailManager _tradeOderDetailManager;

        public TradeOderDetailsAppService(ITradeOderDetailRepository tradeOderDetailRepository, TradeOderDetailManager tradeOderDetailManager, IDistributedCache<TradeOderDetailExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _tradeOderDetailRepository = tradeOderDetailRepository;
            _tradeOderDetailManager = tradeOderDetailManager;
        }

        public virtual async Task<PagedResultDto<TradeOderDetailDto>> GetListAsync(GetTradeOderDetailsInput input)
        {
            var totalCount = await _tradeOderDetailRepository.GetCountAsync(input.FilterText, input.TradeOrderId, input.TradeProductId, input.UnitPriceMin, input.UnitPriceMax, input.QuantityMin, input.QuantityMax, input.OrderDetailStateCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _tradeOderDetailRepository.GetListAsync(input.FilterText, input.TradeOrderId, input.TradeProductId, input.UnitPriceMin, input.UnitPriceMax, input.QuantityMin, input.QuantityMax, input.OrderDetailStateCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<TradeOderDetailDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<TradeOderDetail>, List<TradeOderDetailDto>>(items)
            };
        }

        public virtual async Task<TradeOderDetailDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<TradeOderDetail, TradeOderDetailDto>(await _tradeOderDetailRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.TradeOderDetails.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _tradeOderDetailRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.TradeOderDetails.Create)]
        public virtual async Task<TradeOderDetailDto> CreateAsync(TradeOderDetailCreateDto input)
        {

            var tradeOderDetail = await _tradeOderDetailManager.CreateAsync(
            input.TradeOrderId, input.TradeProductId, input.UnitPrice, input.Quantity, input.OrderDetailStateCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<TradeOderDetail, TradeOderDetailDto>(tradeOderDetail);
        }

        [Authorize(ResumePermissions.TradeOderDetails.Edit)]
        public virtual async Task<TradeOderDetailDto> UpdateAsync(Guid id, TradeOderDetailUpdateDto input)
        {

            var tradeOderDetail = await _tradeOderDetailManager.UpdateAsync(
            id,
            input.TradeOrderId, input.TradeProductId, input.UnitPrice, input.Quantity, input.OrderDetailStateCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<TradeOderDetail, TradeOderDetailDto>(tradeOderDetail);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeOderDetailExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _tradeOderDetailRepository.GetListAsync(input.FilterText, input.TradeOrderId, input.TradeProductId, input.UnitPriceMin, input.UnitPriceMax, input.QuantityMin, input.QuantityMax, input.OrderDetailStateCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<TradeOderDetail>, List<TradeOderDetailExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "TradeOderDetails.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new TradeOderDetailExcelDownloadTokenCacheItem { Token = token },
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