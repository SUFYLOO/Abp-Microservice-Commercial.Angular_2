using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyInvitationsCodes;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyInvitationsCodes
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyInvitationsCode")]
    [Route("api/app/company-invitations-codes")]

    public class CompanyInvitationsCodeController : AbpController, ICompanyInvitationsCodesAppService
    {
        private readonly ICompanyInvitationsCodesAppService _companyInvitationsCodesAppService;

        public CompanyInvitationsCodeController(ICompanyInvitationsCodesAppService companyInvitationsCodesAppService)
        {
            _companyInvitationsCodesAppService = companyInvitationsCodesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyInvitationsCodeDto>> GetListAsync(GetCompanyInvitationsCodesInput input)
        {
            return _companyInvitationsCodesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyInvitationsCodeDto> GetAsync(Guid id)
        {
            return _companyInvitationsCodesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyInvitationsCodeDto> CreateAsync(CompanyInvitationsCodeCreateDto input)
        {
            return _companyInvitationsCodesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyInvitationsCodeDto> UpdateAsync(Guid id, CompanyInvitationsCodeUpdateDto input)
        {
            return _companyInvitationsCodesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyInvitationsCodesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyInvitationsCodeExcelDownloadDto input)
        {
            return _companyInvitationsCodesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyInvitationsCodesAppService.GetDownloadTokenAsync();
        }
    }
}