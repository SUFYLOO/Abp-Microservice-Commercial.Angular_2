using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserTokens
{
    public interface IUserTokensAppService : IApplicationService
    {
        Task<PagedResultDto<UserTokenDto>> GetListAsync(GetUserTokensInput input);

        Task<UserTokenDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserTokenDto> CreateAsync(UserTokenCreateDto input);

        Task<UserTokenDto> UpdateAsync(Guid id, UserTokenUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserTokenExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}