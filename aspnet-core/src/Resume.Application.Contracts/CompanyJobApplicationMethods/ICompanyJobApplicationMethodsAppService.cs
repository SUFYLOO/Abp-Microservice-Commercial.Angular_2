using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobApplicationMethods
{
    public interface ICompanyJobApplicationMethodsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobApplicationMethodDto>> GetListAsync(GetCompanyJobApplicationMethodsInput input);

        Task<CompanyJobApplicationMethodDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobApplicationMethodDto> CreateAsync(CompanyJobApplicationMethodCreateDto input);

        Task<CompanyJobApplicationMethodDto> UpdateAsync(Guid id, CompanyJobApplicationMethodUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobApplicationMethodExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}