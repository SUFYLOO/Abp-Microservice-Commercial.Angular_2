using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyInvitationss;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyInvitationss
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyInvitations")]
    [Route("api/app/company-invitationss")]

    public class CompanyInvitationsController : AbpController, ICompanyInvitationssAppService
    {
        private readonly ICompanyInvitationssAppService _companyInvitationssAppService;

        public CompanyInvitationsController(ICompanyInvitationssAppService companyInvitationssAppService)
        {
            _companyInvitationssAppService = companyInvitationssAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyInvitationsDto>> GetListAsync(GetCompanyInvitationssInput input)
        {
            return _companyInvitationssAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyInvitationsDto> GetAsync(Guid id)
        {
            return _companyInvitationssAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyInvitationsDto> CreateAsync(CompanyInvitationsCreateDto input)
        {
            return _companyInvitationssAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyInvitationsDto> UpdateAsync(Guid id, CompanyInvitationsUpdateDto input)
        {
            return _companyInvitationssAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyInvitationssAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyInvitationsExcelDownloadDto input)
        {
            return _companyInvitationssAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyInvitationssAppService.GetDownloadTokenAsync();
        }
    }
}