using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobDisabilityCategories
{
    public interface ICompanyJobDisabilityCategoriesAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobDisabilityCategoryDto>> GetListAsync(GetCompanyJobDisabilityCategoriesInput input);

        Task<CompanyJobDisabilityCategoryDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobDisabilityCategoryDto> CreateAsync(CompanyJobDisabilityCategoryCreateDto input);

        Task<CompanyJobDisabilityCategoryDto> UpdateAsync(Guid id, CompanyJobDisabilityCategoryUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobDisabilityCategoryExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}