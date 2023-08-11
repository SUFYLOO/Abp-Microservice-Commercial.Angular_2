using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobPays
{
    public interface ICompanyJobPaysAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobPayDto>> GetListAsync(GetCompanyJobPaysInput input);

        Task<CompanyJobPayDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobPayDto> CreateAsync(CompanyJobPayCreateDto input);

        Task<CompanyJobPayDto> UpdateAsync(Guid id, CompanyJobPayUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobPayExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}