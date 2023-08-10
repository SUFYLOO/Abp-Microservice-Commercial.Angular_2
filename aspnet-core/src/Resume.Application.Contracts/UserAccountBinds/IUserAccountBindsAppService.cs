using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserAccountBinds
{
    public interface IUserAccountBindsAppService : IApplicationService
    {
        Task<PagedResultDto<UserAccountBindDto>> GetListAsync(GetUserAccountBindsInput input);

        Task<UserAccountBindDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserAccountBindDto> CreateAsync(UserAccountBindCreateDto input);

        Task<UserAccountBindDto> UpdateAsync(Guid id, UserAccountBindUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserAccountBindExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}