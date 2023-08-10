using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.TradeOrders;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.TradeOrders
{
    [RemoteService]
    [Area("app")]
    [ControllerName("TradeOrder")]
    [Route("api/app/trade-orders")]

    public class TradeOrderController : AbpController, ITradeOrdersAppService
    {
        private readonly ITradeOrdersAppService _tradeOrdersAppService;

        public TradeOrderController(ITradeOrdersAppService tradeOrdersAppService)
        {
            _tradeOrdersAppService = tradeOrdersAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TradeOrderDto>> GetListAsync(GetTradeOrdersInput input)
        {
            return _tradeOrdersAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TradeOrderDto> GetAsync(Guid id)
        {
            return _tradeOrdersAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<TradeOrderDto> CreateAsync(TradeOrderCreateDto input)
        {
            return _tradeOrdersAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TradeOrderDto> UpdateAsync(Guid id, TradeOrderUpdateDto input)
        {
            return _tradeOrdersAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _tradeOrdersAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeOrderExcelDownloadDto input)
        {
            return _tradeOrdersAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _tradeOrdersAppService.GetDownloadTokenAsync();
        }
    }
}