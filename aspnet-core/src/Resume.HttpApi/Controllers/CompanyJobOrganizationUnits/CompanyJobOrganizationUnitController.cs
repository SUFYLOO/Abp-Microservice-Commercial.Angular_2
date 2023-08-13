using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobOrganizationUnits;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobOrganizationUnits
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobOrganizationUnit")]
    [Route("api/app/company-job-organization-units")]

    public class CompanyJobOrganizationUnitController : AbpController, ICompanyJobOrganizationUnitsAppService
    {
        private readonly ICompanyJobOrganizationUnitsAppService _companyJobOrganizationUnitsAppService;

        public CompanyJobOrganizationUnitController(ICompanyJobOrganizationUnitsAppService companyJobOrganizationUnitsAppService)
        {
            _companyJobOrganizationUnitsAppService = companyJobOrganizationUnitsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobOrganizationUnitDto>> GetListAsync(GetCompanyJobOrganizationUnitsInput input)
        {
            return _companyJobOrganizationUnitsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobOrganizationUnitDto> GetAsync(Guid id)
        {
            return _companyJobOrganizationUnitsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobOrganizationUnitDto> CreateAsync(CompanyJobOrganizationUnitCreateDto input)
        {
            return _companyJobOrganizationUnitsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobOrganizationUnitDto> UpdateAsync(Guid id, CompanyJobOrganizationUnitUpdateDto input)
        {
            return _companyJobOrganizationUnitsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobOrganizationUnitsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobOrganizationUnitExcelDownloadDto input)
        {
            return _companyJobOrganizationUnitsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobOrganizationUnitsAppService.GetDownloadTokenAsync();
        }
    }
}