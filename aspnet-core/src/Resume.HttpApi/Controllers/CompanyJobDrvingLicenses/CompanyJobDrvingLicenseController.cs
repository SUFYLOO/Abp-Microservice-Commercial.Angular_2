using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobDrvingLicenses;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobDrvingLicenses
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobDrvingLicense")]
    [Route("api/app/company-job-drving-licenses")]

    public class CompanyJobDrvingLicenseController : AbpController, ICompanyJobDrvingLicensesAppService
    {
        private readonly ICompanyJobDrvingLicensesAppService _companyJobDrvingLicensesAppService;

        public CompanyJobDrvingLicenseController(ICompanyJobDrvingLicensesAppService companyJobDrvingLicensesAppService)
        {
            _companyJobDrvingLicensesAppService = companyJobDrvingLicensesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobDrvingLicenseDto>> GetListAsync(GetCompanyJobDrvingLicensesInput input)
        {
            return _companyJobDrvingLicensesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobDrvingLicenseDto> GetAsync(Guid id)
        {
            return _companyJobDrvingLicensesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobDrvingLicenseDto> CreateAsync(CompanyJobDrvingLicenseCreateDto input)
        {
            return _companyJobDrvingLicensesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobDrvingLicenseDto> UpdateAsync(Guid id, CompanyJobDrvingLicenseUpdateDto input)
        {
            return _companyJobDrvingLicensesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobDrvingLicensesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobDrvingLicenseExcelDownloadDto input)
        {
            return _companyJobDrvingLicensesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobDrvingLicensesAppService.GetDownloadTokenAsync();
        }
    }
}