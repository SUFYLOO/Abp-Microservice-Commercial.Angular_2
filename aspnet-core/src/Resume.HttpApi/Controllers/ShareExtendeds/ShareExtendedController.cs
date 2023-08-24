using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareExtendeds;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareExtendeds
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareExtended")]
    [Route("api/app/share-extendeds")]

    public class ShareExtendedController : AbpController, IShareExtendedsAppService
    {
        private readonly IShareExtendedsAppService _shareExtendedsAppService;

        public ShareExtendedController(IShareExtendedsAppService shareExtendedsAppService)
        {
            _shareExtendedsAppService = shareExtendedsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareExtendedDto>> GetListAsync(GetShareExtendedsInput input)
        {
            return _shareExtendedsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareExtendedDto> GetAsync(Guid id)
        {
            return _shareExtendedsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareExtendedDto> CreateAsync(ShareExtendedCreateDto input)
        {
            return _shareExtendedsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareExtendedDto> UpdateAsync(Guid id, ShareExtendedUpdateDto input)
        {
            return _shareExtendedsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareExtendedsAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareExtendedExcelDownloadDto input)
        {
            return _shareExtendedsAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareExtendedsAppService.GetDownloadTokenAsync();
        }
    }
}