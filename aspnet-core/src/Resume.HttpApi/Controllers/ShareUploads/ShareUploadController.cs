using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareUploads;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareUploads
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareUpload")]
    [Route("api/app/share-uploads")]

    public class ShareUploadController : AbpController, IShareUploadsAppService
    {
        private readonly IShareUploadsAppService _shareUploadsAppService;

        public ShareUploadController(IShareUploadsAppService shareUploadsAppService)
        {
            _shareUploadsAppService = shareUploadsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareUploadDto>> GetListAsync(GetShareUploadsInput input)
        {
            return _shareUploadsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareUploadDto> GetAsync(Guid id)
        {
            return _shareUploadsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareUploadDto> CreateAsync(ShareUploadCreateDto input)
        {
            return _shareUploadsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareUploadDto> UpdateAsync(Guid id, ShareUploadUpdateDto input)
        {
            return _shareUploadsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareUploadsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareUploadExcelDownloadDto input)
        {
            return _shareUploadsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareUploadsAppService.GetDownloadTokenAsync();
        }
    }
}