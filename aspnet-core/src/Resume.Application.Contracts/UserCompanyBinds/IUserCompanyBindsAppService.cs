using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserCompanyBinds
{
    public interface IUserCompanyBindsAppService : IApplicationService
    {
        Task<PagedResultDto<UserCompanyBindDto>> GetListAsync(GetUserCompanyBindsInput input);

        Task<UserCompanyBindDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserCompanyBindDto> CreateAsync(UserCompanyBindCreateDto input);

        Task<UserCompanyBindDto> UpdateAsync(Guid id, UserCompanyBindUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyBindExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}