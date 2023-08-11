using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeDrvingLicenses;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeDrvingLicenses
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeDrvingLicense")]
    [Route("api/app/resume-drving-licenses")]

    public class ResumeDrvingLicenseController : AbpController, IResumeDrvingLicensesAppService
    {
        private readonly IResumeDrvingLicensesAppService _resumeDrvingLicensesAppService;

        public ResumeDrvingLicenseController(IResumeDrvingLicensesAppService resumeDrvingLicensesAppService)
        {
            _resumeDrvingLicensesAppService = resumeDrvingLicensesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeDrvingLicenseDto>> GetListAsync(GetResumeDrvingLicensesInput input)
        {
            return _resumeDrvingLicensesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeDrvingLicenseDto> GetAsync(Guid id)
        {
            return _resumeDrvingLicensesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeDrvingLicenseDto> CreateAsync(ResumeDrvingLicenseCreateDto input)
        {
            return _resumeDrvingLicensesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeDrvingLicenseDto> UpdateAsync(Guid id, ResumeDrvingLicenseUpdateDto input)
        {
            return _resumeDrvingLicensesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeDrvingLicensesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeDrvingLicenseExcelDownloadDto input)
        {
            return _resumeDrvingLicensesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeDrvingLicensesAppService.GetDownloadTokenAsync();
        }
    }
}