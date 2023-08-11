using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Resume.ShareLanguages;
using Volo.Abp.Content;
using Resume.Shared;

namespace Resume.Controllers.ShareLanguages
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ShareLanguage")]
    [Route("api/app/share-languages")]

    public class ShareLanguageController : AbpController, IShareLanguagesAppService
    {
        private readonly IShareLanguagesAppService _shareLanguagesAppService;

        public ShareLanguageController(IShareLanguagesAppService shareLanguagesAppService)
        {
            _shareLanguagesAppService = shareLanguagesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ShareLanguageDto>> GetListAsync(GetShareLanguagesInput input)
        {
            return _shareLanguagesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ShareLanguageDto> GetAsync(Guid id)
        {
            return _shareLanguagesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ShareLanguageDto> CreateAsync(ShareLanguageCreateDto input)
        {
            return _shareLanguagesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ShareLanguageDto> UpdateAsync(Guid id, ShareLanguageUpdateDto input)
        {
            return _shareLanguagesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareLanguagesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareLanguageExcelDownloadDto input)
        {
            return _shareLanguagesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _shareLanguagesAppService.GetDownloadTokenAsync();
        }
    }
}