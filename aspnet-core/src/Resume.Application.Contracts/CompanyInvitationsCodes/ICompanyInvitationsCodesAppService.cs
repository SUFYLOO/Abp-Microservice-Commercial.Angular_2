using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyInvitationsCodes
{
    public interface ICompanyInvitationsCodesAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyInvitationsCodeDto>> GetListAsync(GetCompanyInvitationsCodesInput input);

        Task<CompanyInvitationsCodeDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyInvitationsCodeDto> CreateAsync(CompanyInvitationsCodeCreateDto input);

        Task<CompanyInvitationsCodeDto> UpdateAsync(Guid id, CompanyInvitationsCodeUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyInvitationsCodeExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}