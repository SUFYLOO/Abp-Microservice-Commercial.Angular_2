using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyJobContents
{
    public interface ICompanyJobContentsAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyJobContentDto>> GetListAsync(GetCompanyJobContentsInput input);

        Task<CompanyJobContentDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyJobContentDto> CreateAsync(CompanyJobContentCreateDto input);

        Task<CompanyJobContentDto> UpdateAsync(Guid id, CompanyJobContentUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobContentExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}