using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserMains
{
    public interface IUserMainsAppService : IApplicationService
    {
        Task<PagedResultDto<UserMainDto>> GetListAsync(GetUserMainsInput input);

        Task<UserMainDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserMainDto> CreateAsync(UserMainCreateDto input);

        Task<UserMainDto> UpdateAsync(Guid id, UserMainUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserMainExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}