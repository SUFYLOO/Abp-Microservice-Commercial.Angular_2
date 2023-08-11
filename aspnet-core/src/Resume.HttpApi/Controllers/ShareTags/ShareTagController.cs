using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareTags;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareTags
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareTag")]
    [Route("api/app/share-tags")]

    public class ShareTagController : AbpController, IShareTagsAppService
    {
        private readonly IShareTagsAppService _shareTagsAppService;

        public ShareTagController(IShareTagsAppService shareTagsAppService)
        {
            _shareTagsAppService = shareTagsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareTagDto>> GetListAsync(GetShareTagsInput input)
        {
            return _shareTagsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareTagDto> GetAsync(Guid id)
        {
            return _shareTagsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareTagDto> CreateAsync(ShareTagCreateDto input)
        {
            return _shareTagsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareTagDto> UpdateAsync(Guid id, ShareTagUpdateDto input)
        {
            return _shareTagsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareTagsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareTagExcelDownloadDto input)
        {
            return _shareTagsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareTagsAppService.GetDownloadTokenAsync();
        }
    }
}