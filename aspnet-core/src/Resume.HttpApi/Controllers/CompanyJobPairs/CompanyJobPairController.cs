using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobPairs;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobPairs
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobPair")]
    [Route("api/app/company-job-pairs")]

    public class CompanyJobPairController : AbpController, ICompanyJobPairsAppService
    {
        private readonly ICompanyJobPairsAppService _companyJobPairsAppService;

        public CompanyJobPairController(ICompanyJobPairsAppService companyJobPairsAppService)
        {
            _companyJobPairsAppService = companyJobPairsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobPairDto>> GetListAsync(GetCompanyJobPairsInput input)
        {
            return _companyJobPairsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobPairDto> GetAsync(Guid id)
        {
            return _companyJobPairsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobPairDto> CreateAsync(CompanyJobPairCreateDto input)
        {
            return _companyJobPairsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobPairDto> UpdateAsync(Guid id, CompanyJobPairUpdateDto input)
        {
            return _companyJobPairsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobPairsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobPairExcelDownloadDto input)
        {
            return _companyJobPairsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobPairsAppService.GetDownloadTokenAsync();
        }
    }
}