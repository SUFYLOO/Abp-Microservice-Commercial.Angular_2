using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.CompanyJobWorkHourss;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.CompanyJobWorkHourss
{
    [RemoteService]
    [Area("app")]
    [ControllerName("CompanyJobWorkHours")]
    [Route("api/app/company-job-work-hourss")]

    public class CompanyJobWorkHoursController : AbpController, ICompanyJobWorkHourssAppService
    {
        private readonly ICompanyJobWorkHourssAppService _companyJobWorkHourssAppService;

        public CompanyJobWorkHoursController(ICompanyJobWorkHourssAppService companyJobWorkHourssAppService)
        {
            _companyJobWorkHourssAppService = companyJobWorkHourssAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<CompanyJobWorkHoursDto>> GetListAsync(GetCompanyJobWorkHourssInput input)
        {
            return _companyJobWorkHourssAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<CompanyJobWorkHoursDto> GetAsync(Guid id)
        {
            return _companyJobWorkHourssAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<CompanyJobWorkHoursDto> CreateAsync(CompanyJobWorkHoursCreateDto input)
        {
            return _companyJobWorkHourssAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<CompanyJobWorkHoursDto> UpdateAsync(Guid id, CompanyJobWorkHoursUpdateDto input)
        {
            return _companyJobWorkHourssAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _companyJobWorkHourssAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobWorkHoursExcelDownloadDto input)
        {
            return _companyJobWorkHourssAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _companyJobWorkHourssAppService.GetDownloadTokenAsync();
        }
    }
}