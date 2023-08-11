using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobConditions;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobConditions
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobCondition")]
    [Route("api/app/company-job-conditions")]

    public class CompanyJobConditionController : AbpController, ICompanyJobConditionsAppService
    {
        private readonly ICompanyJobConditionsAppService _companyJobConditionsAppService;

        public CompanyJobConditionController(ICompanyJobConditionsAppService companyJobConditionsAppService)
        {
            _companyJobConditionsAppService = companyJobConditionsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobConditionDto>> GetListAsync(GetCompanyJobConditionsInput input)
        {
            return _companyJobConditionsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobConditionDto> GetAsync(Guid id)
        {
            return _companyJobConditionsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobConditionDto> CreateAsync(CompanyJobConditionCreateDto input)
        {
            return _companyJobConditionsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobConditionDto> UpdateAsync(Guid id, CompanyJobConditionUpdateDto input)
        {
            return _companyJobConditionsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobConditionsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobConditionExcelDownloadDto input)
        {
            return _companyJobConditionsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobConditionsAppService.GetDownloadTokenAsync();
        }
    }
}