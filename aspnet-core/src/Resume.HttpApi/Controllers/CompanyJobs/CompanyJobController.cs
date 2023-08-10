using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobs;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJob")]
    [Route("api/app/company-jobs")]

    public class CompanyJobController : AbpController, ICompanyJobsAppService
    {
        private readonly ICompanyJobsAppService _companyJobsAppService;

        public CompanyJobController(ICompanyJobsAppService companyJobsAppService)
        {
            _companyJobsAppService = companyJobsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobDto>> GetListAsync(GetCompanyJobsInput input)
        {
            return _companyJobsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobDto> GetAsync(Guid id)
        {
            return _companyJobsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobDto> CreateAsync(CompanyJobCreateDto input)
        {
            return _companyJobsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobDto> UpdateAsync(Guid id, CompanyJobUpdateDto input)
        {
            return _companyJobsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobExcelDownloadDto input)
        {
            return _companyJobsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobsAppService.GetDownloadTokenAsync();
        }
    }
}