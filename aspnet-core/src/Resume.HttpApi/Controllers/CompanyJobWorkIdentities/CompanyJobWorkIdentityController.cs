using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobWorkIdentities;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobWorkIdentities
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobWorkIdentity")]
    [Route("api/app/company-job-work-identities")]

    public class CompanyJobWorkIdentityController : AbpController, ICompanyJobWorkIdentitiesAppService
    {
        private readonly ICompanyJobWorkIdentitiesAppService _companyJobWorkIdentitiesAppService;

        public CompanyJobWorkIdentityController(ICompanyJobWorkIdentitiesAppService companyJobWorkIdentitiesAppService)
        {
            _companyJobWorkIdentitiesAppService = companyJobWorkIdentitiesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobWorkIdentityDto>> GetListAsync(GetCompanyJobWorkIdentitiesInput input)
        {
            return _companyJobWorkIdentitiesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobWorkIdentityDto> GetAsync(Guid id)
        {
            return _companyJobWorkIdentitiesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobWorkIdentityDto> CreateAsync(CompanyJobWorkIdentityCreateDto input)
        {
            return _companyJobWorkIdentitiesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobWorkIdentityDto> UpdateAsync(Guid id, CompanyJobWorkIdentityUpdateDto input)
        {
            return _companyJobWorkIdentitiesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobWorkIdentitiesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobWorkIdentityExcelDownloadDto input)
        {
            return _companyJobWorkIdentitiesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobWorkIdentitiesAppService.GetDownloadTokenAsync();
        }
    }
}