using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobConditions
{
    public interface ICompanyJobConditionsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobConditionDto>> GetListAsync(GetCompanyJobConditionsInput input);

        Task<CompanyJobConditionDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobConditionDto> CreateAsync(CompanyJobConditionCreateDto input);

        Task<CompanyJobConditionDto> UpdateAsync(Guid id, CompanyJobConditionUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobConditionExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}