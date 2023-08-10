using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.UserCompanyJobApplies
{
    public interface IUserCompanyJobAppliesAppService : IApplicationService
    {
        Task<PagedResultDto<UserCompanyJobApplyDto>> GetListAsync(GetUserCompanyJobAppliesInput input);

        Task<UserCompanyJobApplyDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<UserCompanyJobApplyDto> CreateAsync(UserCompanyJobApplyCreateDto input);

        Task<UserCompanyJobApplyDto> UpdateAsync(Guid id, UserCompanyJobApplyUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobApplyExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}