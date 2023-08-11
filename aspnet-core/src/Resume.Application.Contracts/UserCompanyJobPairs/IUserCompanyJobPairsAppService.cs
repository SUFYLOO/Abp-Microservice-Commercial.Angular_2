using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserCompanyJobPairs
{
    public interface IUserCompanyJobPairsAppService : IApplicationService
    {
        Task<PagedResultDto<UserCompanyJobPairDto>> GetListAsync(GetUserCompanyJobPairsInput input);

        Task<UserCompanyJobPairDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserCompanyJobPairDto> CreateAsync(UserCompanyJobPairCreateDto input);

        Task<UserCompanyJobPairDto> UpdateAsync(Guid id, UserCompanyJobPairUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobPairExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}