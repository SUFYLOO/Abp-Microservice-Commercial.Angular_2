using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareCodes;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareCodes
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareCode")]
    [Route("api/app/share-codes")]

    public class ShareCodeController : AbpController, IShareCodesAppService
    {
        private readonly IShareCodesAppService _shareCodesAppService;

        public ShareCodeController(IShareCodesAppService shareCodesAppService)
        {
            _shareCodesAppService = shareCodesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareCodeDto>> GetListAsync(GetShareCodesInput input)
        {
            return _shareCodesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareCodeDto> GetAsync(Guid id)
        {
            return _shareCodesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareCodeDto> CreateAsync(ShareCodeCreateDto input)
        {
            return _shareCodesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareCodeDto> UpdateAsync(Guid id, ShareCodeUpdateDto input)
        {
            return _shareCodesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareCodesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareCodeExcelDownloadDto input)
        {
            return _shareCodesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareCodesAppService.GetDownloadTokenAsync();
        }
    }
}