using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobPays;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobPays
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobPay")]
    [Route("api/app/company-job-pays")]

    public class CompanyJobPayController : AbpController, ICompanyJobPaysAppService
    {
        private readonly ICompanyJobPaysAppService _companyJobPaysAppService;

        public CompanyJobPayController(ICompanyJobPaysAppService companyJobPaysAppService)
        {
            _companyJobPaysAppService = companyJobPaysAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobPayDto>> GetListAsync(GetCompanyJobPaysInput input)
        {
            return _companyJobPaysAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobPayDto> GetAsync(Guid id)
        {
            return _companyJobPaysAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobPayDto> CreateAsync(CompanyJobPayCreateDto input)
        {
            return _companyJobPaysAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobPayDto> UpdateAsync(Guid id, CompanyJobPayUpdateDto input)
        {
            return _companyJobPaysAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobPaysAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobPayExcelDownloadDto input)
        {
            return _companyJobPaysAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobPaysAppService.GetDownloadTokenAsync();
        }
    }
}