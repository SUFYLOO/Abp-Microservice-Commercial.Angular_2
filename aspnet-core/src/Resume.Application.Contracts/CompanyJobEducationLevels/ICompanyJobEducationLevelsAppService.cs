using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobEducationLevels
{
    public interface ICompanyJobEducationLevelsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobEducationLevelDto>> GetListAsync(GetCompanyJobEducationLevelsInput input);

        Task<CompanyJobEducationLevelDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobEducationLevelDto> CreateAsync(CompanyJobEducationLevelCreateDto input);

        Task<CompanyJobEducationLevelDto> UpdateAsync(Guid id, CompanyJobEducationLevelUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobEducationLevelExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}