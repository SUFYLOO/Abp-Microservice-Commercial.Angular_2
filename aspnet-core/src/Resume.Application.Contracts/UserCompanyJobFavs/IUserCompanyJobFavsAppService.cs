using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserCompanyJobFavs
{
    public interface IUserCompanyJobFavsAppService : IApplicationService
    {
        Task<PagedResultDto<UserCompanyJobFavDto>> GetListAsync(GetUserCompanyJobFavsInput input);

        Task<UserCompanyJobFavDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserCompanyJobFavDto> CreateAsync(UserCompanyJobFavCreateDto input);

        Task<UserCompanyJobFavDto> UpdateAsync(Guid id, UserCompanyJobFavUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobFavExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}