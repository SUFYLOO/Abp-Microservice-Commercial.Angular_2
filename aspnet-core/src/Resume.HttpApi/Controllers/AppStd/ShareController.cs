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

namespace Resume.App.Controllers.AppStd.Shares
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Share")]
    [Route("api-std/app/shares")]
    [Authorize(ResumePermissions.ShareDefaults.Default)]
    public class ShareController : AbpController
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
        
        public virtual async Task<IActionResult> GetShareCodeTextValueAsync(ShareCodeInput input)
        {
            var Result = await _sharesAppService.GetShareCodeTextValueAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetShareCodeNameCode")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(NameCodeDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetShareCodeNameCodeAsync(ShareCodeInput input)
        {
            var Result = await _sharesAppService.GetShareCodeTextValueAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("GetShareCodeByGroupCode")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ShareCodeByGroupCodeDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetShareCodeByGroupCodeAsync(ShareCodeByGroupCodeInput input)
        {
            var Result = await _sharesAppService.GetShareCodeByGroupCodeAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage) ;
        }

        [HttpPost]
        [Route("SendShareSendQueue")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SendShareSendQueueDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SendShareSendQueueAsync(SendShareSendQueueInput input)
        {
            var Result = await _sharesAppService.SendShareSendQueueAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        [HttpPost]
        [Route("SaveShareUpload")]
        [ProducesResponseType(typeof(SaveShareUploadDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> SaveShareUploadAsync([FromForm] SaveShareUploadInput input)
        {
            var Result = await _sharesAppService.SaveShareUploadAsync(input);
            var ResultCheck = Result.Check;
            var ResultMessage = Result.Messages;

            return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
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
            //input.Id = Id;
            input.Note = Note;
            input.inputWithStream = inputWithStream;
            return _sharesAppService.SaveShareUploadAsync(input);
        }

        [HttpPost]
        [Route("GetShareUploadList")]
        [ProducesResponseType(typeof(ShareUploadsDto), StatusCodes.Status200OK)]
        
        public virtual async Task<IActionResult> GetShareUploadListAsync(ShareUploadListInput input)
        {
           var Result = await _sharesAppService.GetShareUploadListAsync(input);
           var ResultCheck = Result.Check;
           var ResultMessage = Result.Messages;

           return ResultCheck ? Ok(Result.Data) : BadRequest(ResultMessage);
        }

        /// <summary>
        /// ¤£¯à§ï
        /// </summary>
        
        [HttpPost]
        [Route("DownloadShareUpload")]
        [ProducesResponseType(typeof(IRemoteStreamContent), StatusCodes.Status200OK)]
        
        public virtual Task<IRemoteStreamContent> DownloadShareUploadAsync(DownloadShareUploadInput input)
        {
            return _sharesAppService.DownloadShareUploadAsync(input);
        }
    }
}