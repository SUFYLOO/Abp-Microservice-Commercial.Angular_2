using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareDictionarys;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareDictionarys
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareDictionary")]
    [Route("api/app/share-dictionarys")]

    public class ShareDictionaryController : AbpController, IShareDictionarysAppService
    {
        private readonly IShareDictionarysAppService _shareDictionarysAppService;

        public ShareDictionaryController(IShareDictionarysAppService shareDictionarysAppService)
        {
            _shareDictionarysAppService = shareDictionarysAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareDictionaryDto>> GetListAsync(GetShareDictionarysInput input)
        {
            return _shareDictionarysAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareDictionaryDto> GetAsync(Guid id)
        {
            return _shareDictionarysAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareDictionaryDto> CreateAsync(ShareDictionaryCreateDto input)
        {
            return _shareDictionarysAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareDictionaryDto> UpdateAsync(Guid id, ShareDictionaryUpdateDto input)
        {
            return _shareDictionarysAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareDictionarysAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareDictionaryExcelDownloadDto input)
        {
            return _shareDictionarysAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareDictionarysAppService.GetDownloadTokenAsync();
        }
    }
}