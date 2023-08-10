using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserInfos
{
    public interface IUserInfosAppService : IApplicationService
    {
        Task<PagedResultDto<UserInfoDto>> GetListAsync(GetUserInfosInput input);

        Task<UserInfoDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserInfoDto> CreateAsync(UserInfoCreateDto input);

        Task<UserInfoDto> UpdateAsync(Guid id, UserInfoUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserInfoExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}