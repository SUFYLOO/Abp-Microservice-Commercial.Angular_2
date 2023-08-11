using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.CompanyInvitationss
{
    public interface ICompanyInvitationssAppService : IApplicationService
    {
        Task<PagedResultDto<CompanyInvitationsDto>> GetListAsync(GetCompanyInvitationssInput input);

        Task<CompanyInvitationsDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<CompanyInvitationsDto> CreateAsync(CompanyInvitationsCreateDto input);

        Task<CompanyInvitationsDto> UpdateAsync(Guid id, CompanyInvitationsUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyInvitationsExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}