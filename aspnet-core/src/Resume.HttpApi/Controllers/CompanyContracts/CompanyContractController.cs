using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyContracts;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyContracts
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyContract")]
    [Route("api/app/company-contracts")]

    public class CompanyContractController : AbpController, ICompanyContractsAppService
    {
        private readonly ICompanyContractsAppService _companyContractsAppService;

        public CompanyContractController(ICompanyContractsAppService companyContractsAppService)
        {
            _companyContractsAppService = companyContractsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyContractDto>> GetListAsync(GetCompanyContractsInput input)
        {
            return _companyContractsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyContractDto> GetAsync(Guid id)
        {
            return _companyContractsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyContractDto> CreateAsync(CompanyContractCreateDto input)
        {
            return _companyContractsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyContractDto> UpdateAsync(Guid id, CompanyContractUpdateDto input)
        {
            return _companyContractsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyContractsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyContractExcelDownloadDto input)
        {
            return _companyContractsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyContractsAppService.GetDownloadTokenAsync();
        }
    }
}