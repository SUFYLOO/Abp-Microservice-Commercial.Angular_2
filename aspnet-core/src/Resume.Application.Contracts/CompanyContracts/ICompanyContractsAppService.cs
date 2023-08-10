using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyContracts
{
    public interface ICompanyContractsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyContractDto>> GetListAsync(GetCompanyContractsInput input);

        Task<CompanyContractDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyContractDto> CreateAsync(CompanyContractCreateDto input);

        Task<CompanyContractDto> UpdateAsync(Guid id, CompanyContractUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyContractExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}