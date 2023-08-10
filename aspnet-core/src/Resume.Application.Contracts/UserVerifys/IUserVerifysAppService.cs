using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserVerifys
{
    public interface IUserVerifysAppService : IApplicationService
    {
        Task<PagedResultDto<UserVerifyDto>> GetListAsync(GetUserVerifysInput input);

        Task<UserVerifyDto> GetAsync(long id);

        Task DeleteAsync(long id);

        Task<UserVerifyDto> CreateAsync(UserVerifyCreateDto input);

        Task<UserVerifyDto> UpdateAsync(long id, UserVerifyUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserVerifyExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}