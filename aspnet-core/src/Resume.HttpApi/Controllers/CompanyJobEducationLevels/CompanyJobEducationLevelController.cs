using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobEducationLevels;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobEducationLevels
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobEducationLevel")]
    [Route("api/app/company-job-education-levels")]

    public class CompanyJobEducationLevelController : AbpController, ICompanyJobEducationLevelsAppService
    {
        private readonly ICompanyJobEducationLevelsAppService _companyJobEducationLevelsAppService;

        public CompanyJobEducationLevelController(ICompanyJobEducationLevelsAppService companyJobEducationLevelsAppService)
        {
            _companyJobEducationLevelsAppService = companyJobEducationLevelsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobEducationLevelDto>> GetListAsync(GetCompanyJobEducationLevelsInput input)
        {
            return _companyJobEducationLevelsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobEducationLevelDto> GetAsync(Guid id)
        {
            return _companyJobEducationLevelsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobEducationLevelDto> CreateAsync(CompanyJobEducationLevelCreateDto input)
        {
            return _companyJobEducationLevelsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobEducationLevelDto> UpdateAsync(Guid id, CompanyJobEducationLevelUpdateDto input)
        {
            return _companyJobEducationLevelsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobEducationLevelsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobEducationLevelExcelDownloadDto input)
        {
            return _companyJobEducationLevelsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobEducationLevelsAppService.GetDownloadTokenAsync();
        }
    }
}