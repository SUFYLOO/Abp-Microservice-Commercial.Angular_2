using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyMains;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyMains
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyMain")]
    [Route("api/app/company-mains")]

    public class CompanyMainController : AbpController, ICompanyMainsAppService
    {
        private readonly ICompanyMainsAppService _companyMainsAppService;

        public CompanyMainController(ICompanyMainsAppService companyMainsAppService)
        {
            _companyMainsAppService = companyMainsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyMainDto>> GetListAsync(GetCompanyMainsInput input)
        {
            return _companyMainsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyMainDto> GetAsync(Guid id)
        {
            return _companyMainsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyMainDto> CreateAsync(CompanyMainCreateDto input)
        {
            return _companyMainsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyMainDto> UpdateAsync(Guid id, CompanyMainUpdateDto input)
        {
            return _companyMainsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyMainsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyMainExcelDownloadDto input)
        {
            return _companyMainsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyMainsAppService.GetDownloadTokenAsync();
        }
    }
}