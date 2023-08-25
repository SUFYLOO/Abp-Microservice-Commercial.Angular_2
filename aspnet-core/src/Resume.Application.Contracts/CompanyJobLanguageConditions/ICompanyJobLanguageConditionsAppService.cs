using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobLanguageConditions
{
    public interface ICompanyJobLanguageConditionsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobLanguageConditionDto>> GetListAsync(GetCompanyJobLanguageConditionsInput input);

        Task<CompanyJobLanguageConditionDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobLanguageConditionDto> CreateAsync(CompanyJobLanguageConditionCreateDto input);

        Task<CompanyJobLanguageConditionDto> UpdateAsync(Guid id, CompanyJobLanguageConditionUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobLanguageConditionExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}