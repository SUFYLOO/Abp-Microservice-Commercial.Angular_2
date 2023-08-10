using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.TradeOderDetails
{
    public interface ITradeOderDetailsAppService : IApplicationService
    {
        Task<PagedResultDto<TradeOderDetailDto>> GetListAsync(GetTradeOderDetailsInput input);

        Task<TradeOderDetailDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<TradeOderDetailDto> CreateAsync(TradeOderDetailCreateDto input);

        Task<TradeOderDetailDto> UpdateAsync(Guid id, TradeOderDetailUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(TradeOderDetailExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}