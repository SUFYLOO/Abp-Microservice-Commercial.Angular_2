using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Resume.Shared;
using Resume.App.Users;
using Resume.App;
using Resume.App.Resumes;
using Resume.App.Shares;
using System.Collections.Generic;
using Resume.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.FileManagement.Files;
using Microsoft.AspNetCore.Http;

namespace Resume.App.Controllers.App.Shares
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Share")]
    [Route("api/app/shares")]
    [Authorize(ResumePermissions.ShareDefaults.Default)]
    public class ShareController : AbpController, ISharesAppService
    {
        private readonly ISharesAppService _sharesAppService;

        public ShareController(ISharesAppService sharesAppService)
        {
            _sharesAppService = sharesAppService;
        }

        [HttpPost]
        [Route("GetShareCodeTextValue")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TextValueDto), StatusCodes.Status200OK)]
           
        public virtual Task<ResultDto<List<TextValueDto>>> GetShareCodeTextValueAsync(ShareCodeInput input)
        {
            return _sharesAppService.GetShareCodeTextValueAsync(input);
        }

        [HttpPost]
        [Route("GetShareCodeNameCode")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(NameCodeDto), StatusCodes.Status200OK)]
           
        public virtual Task<ResultDto<List<NameCodeDto>>> GetShareCodeNameCodeAsync(ShareCodeInput input)
        {
            return _sharesAppService.GetShareCodeNameCodeAsync(input);
        }

        [HttpPost]
        [Route("GetShareCodeByGroupCode")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ShareCodeByGroupCodeDto), StatusCodes.Status200OK)]
           
        public virtual Task<ResultDto<List<ShareCodeByGroupCodeDto>>> GetShareCodeByGroupCodeAsync(ShareCodeByGroupCodeInput input)
        {
            return _sharesAppService.GetShareCodeByGroupCodeAsync(input);
        }

        [HttpPost]
        [Route("SendShareSendQueue")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SendShareSendQueueDto), StatusCodes.Status200OK)]
           
        public virtual Task<ResultDto<SendShareSendQueueDto>> SendShareSendQueueAsync(SendShareSendQueueInput input)
        {
            return _sharesAppService.SendShareSendQueueAsync(input);
        }

        [HttpPost]
        [Route("SaveShareUpload")]
        [ProducesResponseType(typeof(SaveShareUploadDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<SaveShareUploadDto>> SaveShareUploadAsync([FromForm] SaveShareUploadInput input)
        {
            return _sharesAppService.SaveShareUploadAsync(input);
        }

        [HttpPost]
        [Route("SaveShareUpload1")]
        [ProducesResponseType(typeof(SaveShareUploadDto), StatusCodes.Status200OK)]
        
        public virtual Task<ResultDto<SaveShareUploadDto>> SaveShareUpload1Async(string Key1, string Key2, string Key3, string Code, string Note, CreateFileInputWithStream inputWithStream)
        {
            var input = new SaveShareUploadInput();
            input.Key1 = Key1;
            input.Key2 = Key2;
            input.Key3 = Key3;
            //input.Id = Code;
            input.Note = Note;
            input.inputWithStream = inputWithStream;
            return _sharesAppService.SaveShareUploadAsync(input);
        }

        [HttpPost]
        [Route("GetShareUploadList")]
        [ProducesResponseType(typeof(ShareUploadsDto), StatusCodes.Status200OK)]
           
        public virtual Task<ResultDto<List<ShareUploadsDto>>> GetShareUploadListAsync(ShareUploadListInput input)
        {
            return _sharesAppService.GetShareUploadListAsync(input);
        }

        [HttpPost]
        [Route("DownloadShareUpload")]
        [ProducesResponseType(typeof(IRemoteStreamContent), StatusCodes.Status200OK)]
           
        public virtual Task<IRemoteStreamContent> DownloadShareUploadAsync(DownloadShareUploadInput input)
        {
            return _sharesAppService.DownloadShareUploadAsync(input);
        }
    }
}