using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobs
{
    public interface ICompanyJobsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobDto>> GetListAsync(GetCompanyJobsInput input);

        Task<CompanyJobDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobDto> CreateAsync(CompanyJobCreateDto input);

        Task<CompanyJobDto> UpdateAsync(Guid id, CompanyJobUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}