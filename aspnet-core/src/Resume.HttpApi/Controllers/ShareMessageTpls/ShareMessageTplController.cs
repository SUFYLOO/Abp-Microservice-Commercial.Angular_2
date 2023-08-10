using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareMessageTpls;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareMessageTpls
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareMessageTpl")]
    [Route("api/app/share-message-tpls")]

    public class ShareMessageTplController : AbpController, IShareMessageTplsAppService
    {
        private readonly IShareMessageTplsAppService _shareMessageTplsAppService;

        public ShareMessageTplController(IShareMessageTplsAppService shareMessageTplsAppService)
        {
            _shareMessageTplsAppService = shareMessageTplsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareMessageTplDto>> GetListAsync(GetShareMessageTplsInput input)
        {
            return _shareMessageTplsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareMessageTplDto> GetAsync(Guid id)
        {
            return _shareMessageTplsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareMessageTplDto> CreateAsync(ShareMessageTplCreateDto input)
        {
            return _shareMessageTplsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareMessageTplDto> UpdateAsync(Guid id, ShareMessageTplUpdateDto input)
        {
            return _shareMessageTplsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareMessageTplsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareMessageTplExcelDownloadDto input)
        {
            return _shareMessageTplsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareMessageTplsAppService.GetDownloadTokenAsync();
        }
    }
}