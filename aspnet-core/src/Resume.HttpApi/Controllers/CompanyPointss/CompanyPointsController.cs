using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyPointss;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyPointss
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyPoints")]
    [Route("api/app/company-pointss")]

    public class CompanyPointsController : AbpController, ICompanyPointssAppService
    {
        private readonly ICompanyPointssAppService _companyPointssAppService;

        public CompanyPointsController(ICompanyPointssAppService companyPointssAppService)
        {
            _companyPointssAppService = companyPointssAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyPointsDto>> GetListAsync(GetCompanyPointssInput input)
        {
            return _companyPointssAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyPointsDto> GetAsync(Guid id)
        {
            return _companyPointssAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyPointsDto> CreateAsync(CompanyPointsCreateDto input)
        {
            return _companyPointssAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyPointsDto> UpdateAsync(Guid id, CompanyPointsUpdateDto input)
        {
            return _companyPointssAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyPointssAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyPointsExcelDownloadDto input)
        {
            return _companyPointssAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyPointssAppService.GetDownloadTokenAsync();
        }
    }
}