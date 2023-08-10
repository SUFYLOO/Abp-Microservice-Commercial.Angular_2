using Resume.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Content;
using Volo.FileManagement.Directories;
using Volo.FileManagement.Files;

namespace Resume.Controllers.AppStd
{
    [RemoteService]
    [Area("app")]
    [ControllerName("File")]
    [Route("api-std/app/file")]
    [Authorize(ResumePermissions.ShareDefaults.Default)]
    public class ShareFileDescriptorController : AbpController
    {
        IFileDescriptorAppService _shareFileDescriptorAppService;

        public ShareFileDescriptorController(IFileDescriptorAppService shareFileDescriptorAppService)
        {
            _shareFileDescriptorAppService = shareFileDescriptorAppService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(FileDescriptorDto), StatusCodes.Status200OK)]

        public virtual Task<FileDescriptorDto> CreateAsync(Guid? directoryId, CreateFileInputWithStream inputWithStream)
        {
            return _shareFileDescriptorAppService.CreateAsync(directoryId, inputWithStream);
        }

        [HttpDelete]
        [Route("Delete")]

        public virtual Task DeleteAsync(Guid id)
        {
            return _shareFileDescriptorAppService.DeleteAsync(id);
        }

        [HttpPost]
        [Route("Download")]
        [ProducesResponseType(typeof(IRemoteStreamContent), StatusCodes.Status200OK)]
        public virtual Task<IRemoteStreamContent> DownloadAsync(Guid id, string token)
        {
            return _shareFileDescriptorAppService.DownloadAsync(id, token);
        }

        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(typeof(FileDescriptorDto), StatusCodes.Status200OK)]
        public virtual Task<FileDescriptorDto> GetAsync(Guid id)
        {
            return _shareFileDescriptorAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("GetContent")]

        public virtual Task<byte[]> GetContentAsync(Guid id)
        {
            return _shareFileDescriptorAppService.GetContentAsync(id);
        }

        //[HttpGet]
        //[Route("GetDownloadToken")]
        //public virtual Task<DownloadTokenResultDto> GetDownloadTokenAsync(Guid id)
        //{
        //    return _shareFileDescriptorAppService.GetDownloadTokenAsync(id);
        //}

        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType(typeof(FileDescriptorDto), StatusCodes.Status200OK)]
        public virtual Task<ListResultDto<FileDescriptorDto>> GetListAsync(Guid? directoryId)
        {
            return _shareFileDescriptorAppService.GetListAsync(directoryId);
        }

        [HttpGet]
        [Route("GetPreInfo")]
        [ProducesResponseType(typeof(FileUploadPreInfoDto), StatusCodes.Status200OK)]
        public virtual Task<List<FileUploadPreInfoDto>> GetPreInfoAsync(List<FileUploadPreInfoRequest> input)
        {
            return _shareFileDescriptorAppService.GetPreInfoAsync(input);
        }

        [HttpPost]
        [Route("Move")]
        [ProducesResponseType(typeof(FileDescriptorDto), StatusCodes.Status200OK)]
        public virtual Task<FileDescriptorDto> MoveAsync(MoveFileInput input)
        {
            return _shareFileDescriptorAppService.MoveAsync(input);
        }

        [HttpPost]
        [Route("Rename")]
        [ProducesResponseType(typeof(FileDescriptorDto), StatusCodes.Status200OK)]
        public virtual Task<FileDescriptorDto> RenameAsync(Guid id, RenameFileInput input)
        {
            return _shareFileDescriptorAppService.RenameAsync(id, input);
        }
    }
}