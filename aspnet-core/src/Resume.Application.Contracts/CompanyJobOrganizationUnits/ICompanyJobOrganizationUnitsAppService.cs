using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobOrganizationUnits
{
    public interface ICompanyJobOrganizationUnitsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobOrganizationUnitDto>> GetListAsync(GetCompanyJobOrganizationUnitsInput input);

        Task<CompanyJobOrganizationUnitDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobOrganizationUnitDto> CreateAsync(CompanyJobOrganizationUnitCreateDto input);

        Task<CompanyJobOrganizationUnitDto> UpdateAsync(Guid id, CompanyJobOrganizationUnitUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobOrganizationUnitExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}