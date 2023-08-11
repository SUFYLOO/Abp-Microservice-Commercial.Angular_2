using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeDependentss;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeDependentss
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeDependents")]
    [Route("api/app/resume-dependentss")]

    public class ResumeDependentsController : AbpController, IResumeDependentssAppService
    {
        private readonly IResumeDependentssAppService _resumeDependentssAppService;

        public ResumeDependentsController(IResumeDependentssAppService resumeDependentssAppService)
        {
            _resumeDependentssAppService = resumeDependentssAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeDependentsDto>> GetListAsync(GetResumeDependentssInput input)
        {
            return _resumeDependentssAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeDependentsDto> GetAsync(Guid id)
        {
            return _resumeDependentssAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeDependentsDto> CreateAsync(ResumeDependentsCreateDto input)
        {
            return _resumeDependentssAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeDependentsDto> UpdateAsync(Guid id, ResumeDependentsUpdateDto input)
        {
            return _resumeDependentssAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeDependentssAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeDependentsExcelDownloadDto input)
        {
            return _resumeDependentssAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeDependentssAppService.GetDownloadTokenAsync();
        }
    }
}