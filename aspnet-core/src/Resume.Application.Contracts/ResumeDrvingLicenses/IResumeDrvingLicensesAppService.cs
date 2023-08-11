using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.ResumeDrvingLicenses
{
    public interface IResumeDrvingLicensesAppService : IApplicationService
    {
        Task<PagedResultDto<ResumeDrvingLicenseDto>> GetListAsync(GetResumeDrvingLicensesInput input);

        Task<ResumeDrvingLicenseDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<ResumeDrvingLicenseDto> CreateAsync(ResumeDrvingLicenseCreateDto input);

        Task<ResumeDrvingLicenseDto> UpdateAsync(Guid id, ResumeDrvingLicenseUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeDrvingLicenseExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}