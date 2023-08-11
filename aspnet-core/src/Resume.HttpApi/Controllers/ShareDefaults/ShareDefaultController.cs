using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareDefaults;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareDefaults
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareDefault")]
    [Route("api/app/share-defaults")]

    public class ShareDefaultController : AbpController, IShareDefaultsAppService
    {
        private readonly IShareDefaultsAppService _shareDefaultsAppService;

        public ShareDefaultController(IShareDefaultsAppService shareDefaultsAppService)
        {
            _shareDefaultsAppService = shareDefaultsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareDefaultDto>> GetListAsync(GetShareDefaultsInput input)
        {
            return _shareDefaultsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareDefaultDto> GetAsync(Guid id)
        {
            return _shareDefaultsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareDefaultDto> CreateAsync(ShareDefaultCreateDto input)
        {
            return _shareDefaultsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareDefaultDto> UpdateAsync(Guid id, ShareDefaultUpdateDto input)
        {
            return _shareDefaultsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareDefaultsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareDefaultExcelDownloadDto input)
        {
            return _shareDefaultsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareDefaultsAppService.GetDownloadTokenAsync();
        }
    }
}