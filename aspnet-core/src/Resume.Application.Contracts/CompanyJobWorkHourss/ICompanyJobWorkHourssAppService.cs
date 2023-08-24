using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobWorkHourss
{
    public interface ICompanyJobWorkHourssAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobWorkHoursDto>> GetListAsync(GetCompanyJobWorkHourssInput input);

        Task<CompanyJobWorkHoursDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobWorkHoursDto> CreateAsync(CompanyJobWorkHoursCreateDto input);

        Task<CompanyJobWorkHoursDto> UpdateAsync(Guid id, CompanyJobWorkHoursUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobWorkHoursExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}