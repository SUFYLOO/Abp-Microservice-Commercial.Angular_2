using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobLanguageConditions;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobLanguageConditions
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobLanguageCondition")]
    [Route("api/app/company-job-language-conditions")]

    public class CompanyJobLanguageConditionController : AbpController, ICompanyJobLanguageConditionsAppService
    {
        private readonly ICompanyJobLanguageConditionsAppService _companyJobLanguageConditionsAppService;

        public CompanyJobLanguageConditionController(ICompanyJobLanguageConditionsAppService companyJobLanguageConditionsAppService)
        {
            _companyJobLanguageConditionsAppService = companyJobLanguageConditionsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobLanguageConditionDto>> GetListAsync(GetCompanyJobLanguageConditionsInput input)
        {
            return _companyJobLanguageConditionsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobLanguageConditionDto> GetAsync(Guid id)
        {
            return _companyJobLanguageConditionsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobLanguageConditionDto> CreateAsync(CompanyJobLanguageConditionCreateDto input)
        {
            return _companyJobLanguageConditionsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobLanguageConditionDto> UpdateAsync(Guid id, CompanyJobLanguageConditionUpdateDto input)
        {
            return _companyJobLanguageConditionsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobLanguageConditionsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobLanguageConditionExcelDownloadDto input)
        {
            return _companyJobLanguageConditionsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobLanguageConditionsAppService.GetDownloadTokenAsync();
        }
    }
}