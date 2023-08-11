using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyUsers
{
    public interface ICompanyUsersAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyUserDto>> GetListAsync(GetCompanyUsersInput input);

        Task<CompanyUserDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyUserDto> CreateAsync(CompanyUserCreateDto input);

        Task<CompanyUserDto> UpdateAsync(Guid id, CompanyUserUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyUserExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}