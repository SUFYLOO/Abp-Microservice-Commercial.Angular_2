using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyMains
{
    public interface ICompanyMainsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyMainDto>> GetListAsync(GetCompanyMainsInput input);

        Task<CompanyMainDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyMainDto> CreateAsync(CompanyMainCreateDto input);

        Task<CompanyMainDto> UpdateAsync(Guid id, CompanyMainUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyMainExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}