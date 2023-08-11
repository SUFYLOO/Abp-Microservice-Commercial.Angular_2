using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobApplicationMethods;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobApplicationMethods
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobApplicationMethod")]
    [Route("api/app/company-job-application-methods")]

    public class CompanyJobApplicationMethodController : AbpController, ICompanyJobApplicationMethodsAppService
    {
        private readonly ICompanyJobApplicationMethodsAppService _companyJobApplicationMethodsAppService;

        public CompanyJobApplicationMethodController(ICompanyJobApplicationMethodsAppService companyJobApplicationMethodsAppService)
        {
            _companyJobApplicationMethodsAppService = companyJobApplicationMethodsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobApplicationMethodDto>> GetListAsync(GetCompanyJobApplicationMethodsInput input)
        {
            return _companyJobApplicationMethodsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobApplicationMethodDto> GetAsync(Guid id)
        {
            return _companyJobApplicationMethodsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobApplicationMethodDto> CreateAsync(CompanyJobApplicationMethodCreateDto input)
        {
            return _companyJobApplicationMethodsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobApplicationMethodDto> UpdateAsync(Guid id, CompanyJobApplicationMethodUpdateDto input)
        {
            return _companyJobApplicationMethodsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobApplicationMethodsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobApplicationMethodExcelDownloadDto input)
        {
            return _companyJobApplicationMethodsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobApplicationMethodsAppService.GetDownloadTokenAsync();
        }
    }
}