using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobContents;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobContents
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobContent")]
    [Route("api/app/company-job-contents")]

    public class CompanyJobContentController : AbpController, ICompanyJobContentsAppService
    {
        private readonly ICompanyJobContentsAppService _companyJobContentsAppService;

        public CompanyJobContentController(ICompanyJobContentsAppService companyJobContentsAppService)
        {
            _companyJobContentsAppService = companyJobContentsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobContentDto>> GetListAsync(GetCompanyJobContentsInput input)
        {
            return _companyJobContentsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobContentDto> GetAsync(Guid id)
        {
            return _companyJobContentsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobContentDto> CreateAsync(CompanyJobContentCreateDto input)
        {
            return _companyJobContentsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobContentDto> UpdateAsync(Guid id, CompanyJobContentUpdateDto input)
        {
            return _companyJobContentsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobContentsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobContentExcelDownloadDto input)
        {
            return _companyJobContentsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobContentsAppService.GetDownloadTokenAsync();
        }
    }
}