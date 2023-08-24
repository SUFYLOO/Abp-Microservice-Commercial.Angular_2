using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobDisabilityCategories;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobDisabilityCategories
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobDisabilityCategory")]
    [Route("api/app/company-job-disability-categories")]

    public class CompanyJobDisabilityCategoryController : AbpController, ICompanyJobDisabilityCategoriesAppService
    {
        private readonly ICompanyJobDisabilityCategoriesAppService _companyJobDisabilityCategoriesAppService;

        public CompanyJobDisabilityCategoryController(ICompanyJobDisabilityCategoriesAppService companyJobDisabilityCategoriesAppService)
        {
            _companyJobDisabilityCategoriesAppService = companyJobDisabilityCategoriesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobDisabilityCategoryDto>> GetListAsync(GetCompanyJobDisabilityCategoriesInput input)
        {
            return _companyJobDisabilityCategoriesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobDisabilityCategoryDto> GetAsync(Guid id)
        {
            return _companyJobDisabilityCategoriesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobDisabilityCategoryDto> CreateAsync(CompanyJobDisabilityCategoryCreateDto input)
        {
            return _companyJobDisabilityCategoriesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobDisabilityCategoryDto> UpdateAsync(Guid id, CompanyJobDisabilityCategoryUpdateDto input)
        {
            return _companyJobDisabilityCategoriesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobDisabilityCategoriesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobDisabilityCategoryExcelDownloadDto input)
        {
            return _companyJobDisabilityCategoriesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobDisabilityCategoriesAppService.GetDownloadTokenAsync();
        }
    }
}