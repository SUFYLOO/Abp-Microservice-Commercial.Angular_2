using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyPointss
{
    public interface ICompanyPointssAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyPointsDto>> GetListAsync(GetCompanyPointssInput input);

        Task<CompanyPointsDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyPointsDto> CreateAsync(CompanyPointsCreateDto input);

        Task<CompanyPointsDto> UpdateAsync(Guid id, CompanyPointsUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyPointsExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}