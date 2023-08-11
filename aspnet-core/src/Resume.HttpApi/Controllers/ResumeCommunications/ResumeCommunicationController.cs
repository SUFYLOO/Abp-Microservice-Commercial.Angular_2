using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ResumeCommunications;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ResumeCommunications
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ResumeCommunication")]
    [Route("api/app/resume-communications")]

    public class ResumeCommunicationController : AbpController, IResumeCommunicationsAppService
    {
        private readonly IResumeCommunicationsAppService _resumeCommunicationsAppService;

        public ResumeCommunicationController(IResumeCommunicationsAppService resumeCommunicationsAppService)
        {
            _resumeCommunicationsAppService = resumeCommunicationsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ResumeCommunicationDto>> GetListAsync(GetResumeCommunicationsInput input)
        {
            return _resumeCommunicationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ResumeCommunicationDto> GetAsync(Guid id)
        {
            return _resumeCommunicationsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ResumeCommunicationDto> CreateAsync(ResumeCommunicationCreateDto input)
        {
            return _resumeCommunicationsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ResumeCommunicationDto> UpdateAsync(Guid id, ResumeCommunicationUpdateDto input)
        {
            return _resumeCommunicationsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _resumeCommunicationsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeCommunicationExcelDownloadDto input)
        {
            return _resumeCommunicationsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _resumeCommunicationsAppService.GetDownloadTokenAsync();
        }
    }
}