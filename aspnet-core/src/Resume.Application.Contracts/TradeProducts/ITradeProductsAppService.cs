using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.TradeProducts
{
    public interface ITradeProductsAppService : IApplicationService
    {
        Task<PagedResultDto<TradeProductDto>> GetListAsync(GetTradeProductsInput input);

        Task<TradeProductDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TradeProductDto> CreateAsync(TradeProductCreateDto input);

        Task<TradeProductDto> UpdateAsync(Guid id, TradeProductUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeProductExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}