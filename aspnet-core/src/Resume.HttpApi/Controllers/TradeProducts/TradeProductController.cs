using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.TradeProducts;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.TradeProducts
{
    [RemoteService]
    [Area("app")]
    [ControllerName("TradeProduct")]
    [Route("api/app/trade-products")]

    public class TradeProductController : AbpController, ITradeProductsAppService
    {
        private readonly ITradeProductsAppService _tradeProductsAppService;

        public TradeProductController(ITradeProductsAppService tradeProductsAppService)
        {
            _tradeProductsAppService = tradeProductsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TradeProductDto>> GetListAsync(GetTradeProductsInput input)
        {
            return _tradeProductsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TradeProductDto> GetAsync(Guid id)
        {
            return _tradeProductsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<TradeProductDto> CreateAsync(TradeProductCreateDto input)
        {
            return _tradeProductsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TradeProductDto> UpdateAsync(Guid id, TradeProductUpdateDto input)
        {
            return _tradeProductsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _tradeProductsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeProductExcelDownloadDto input)
        {
            return _tradeProductsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _tradeProductsAppService.GetDownloadTokenAsync();
        }
    }
}