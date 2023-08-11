using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.TradeOderDetails;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.TradeOderDetails
{
    [RemoteService]
    [Area("app")]
    [ControllerName("TradeOderDetail")]
    [Route("api/app/trade-oder-details")]

    public class TradeOderDetailController : AbpController, ITradeOderDetailsAppService
    {
        private readonly ITradeOderDetailsAppService _tradeOderDetailsAppService;

        public TradeOderDetailController(ITradeOderDetailsAppService tradeOderDetailsAppService)
        {
            _tradeOderDetailsAppService = tradeOderDetailsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<TradeOderDetailDto>> GetListAsync(GetTradeOderDetailsInput input)
        {
            return _tradeOderDetailsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<TradeOderDetailDto> GetAsync(Guid id)
        {
            return _tradeOderDetailsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<TradeOderDetailDto> CreateAsync(TradeOderDetailCreateDto input)
        {
            return _tradeOderDetailsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<TradeOderDetailDto> UpdateAsync(Guid id, TradeOderDetailUpdateDto input)
        {
            return _tradeOderDetailsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _tradeOderDetailsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeOderDetailExcelDownloadDto input)
        {
            return _tradeOderDetailsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _tradeOderDetailsAppService.GetDownloadTokenAsync();
        }
    }
}