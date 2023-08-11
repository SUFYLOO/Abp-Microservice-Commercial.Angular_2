using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.TradeOrders
{
    public interface ITradeOrdersAppService : IApplicationService
    {
        Task<PagedResultDto<TradeOrderDto>> GetListAsync(GetTradeOrdersInput input);

        Task<TradeOrderDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TradeOrderDto> CreateAsync(TradeOrderCreateDto input);

        Task<TradeOrderDto> UpdateAsync(Guid id, TradeOrderUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeOrderExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}