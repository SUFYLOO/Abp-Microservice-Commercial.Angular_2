using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobDrvingLicenses
{
    public interface ICompanyJobDrvingLicensesAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobDrvingLicenseDto>> GetListAsync(GetCompanyJobDrvingLicensesInput input);

        Task<CompanyJobDrvingLicenseDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobDrvingLicenseDto> CreateAsync(CompanyJobDrvingLicenseCreateDto input);

        Task<CompanyJobDrvingLicenseDto> UpdateAsync(Guid id, CompanyJobDrvingLicenseUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobDrvingLicenseExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}