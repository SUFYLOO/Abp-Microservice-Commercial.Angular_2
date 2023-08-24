using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobWorkIdentities
{
    public interface ICompanyJobWorkIdentitiesAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobWorkIdentityDto>> GetListAsync(GetCompanyJobWorkIdentitiesInput input);

        Task<CompanyJobWorkIdentityDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobWorkIdentityDto> CreateAsync(CompanyJobWorkIdentityCreateDto input);

        Task<CompanyJobWorkIdentityDto> UpdateAsync(Guid id, CompanyJobWorkIdentityUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobWorkIdentityExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}