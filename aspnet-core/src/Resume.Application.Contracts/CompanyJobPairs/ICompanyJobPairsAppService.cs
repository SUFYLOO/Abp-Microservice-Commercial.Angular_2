using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobPairs
{
    public interface ICompanyJobPairsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobPairDto>> GetListAsync(GetCompanyJobPairsInput input);

        Task<CompanyJobPairDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobPairDto> CreateAsync(CompanyJobPairCreateDto input);

        Task<CompanyJobPairDto> UpdateAsync(Guid id, CompanyJobPairUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobPairExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}