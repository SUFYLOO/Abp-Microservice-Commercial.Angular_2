using Resume.App.Shares;
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
using Volo.FileManagement.Directories;

namespace Resume.Controllers.AppStd
{
    [RemoteService]
    [Area("app")]
    [ControllerName("File")]
    [Route("api-std/app/directory")]
    [Authorize(ResumePermissions.ShareDefaults.Default)]
    public class ShareDirectoryDescriptorController : AbpController
    {
        private readonly IDirectoryDescriptorAppService _shareDirectoryDescriptorAppService;

        public ShareDirectoryDescriptorController(IDirectoryDescriptorAppService directoryDescriptorAppService)
        {
            _shareDirectoryDescriptorAppService = directoryDescriptorAppService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(DirectoryDescriptorDto), StatusCodes.Status200OK)]
        public virtual Task<DirectoryDescriptorDto> CreateAsync(CreateDirectoryInput input)
        {
            return _shareDirectoryDescriptorAppService.CreateAsync(input);
        }

        [HttpDelete]
        [Route("Delete")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _shareDirectoryDescriptorAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("Get")]
        [ProducesResponseType(typeof(DirectoryDescriptorDto), StatusCodes.Status200OK)]

        public virtual Task<DirectoryDescriptorDto> GetAsync(Guid id)
        {
            return _shareDirectoryDescriptorAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("GetContent")]
        [ProducesResponseType(typeof(DirectoryContentDto), StatusCodes.Status200OK)]

        public virtual Task<PagedResultDto<DirectoryContentDto>> GetContentAsync(DirectoryContentRequestInput input)
        {
            return _shareDirectoryDescriptorAppService.GetContentAsync(input);
        }

        [HttpGet]
        [Route("GetList")]
        [ProducesResponseType(typeof(DirectoryDescriptorInfoDto), StatusCodes.Status200OK)]

        public virtual Task<ListResultDto<DirectoryDescriptorInfoDto>> GetListAsync(Guid? parentId)
        {
            return _shareDirectoryDescriptorAppService.GetListAsync(parentId);
        }

        [HttpPost]
        [Route("Move")]
        [ProducesResponseType(typeof(DirectoryDescriptorDto), StatusCodes.Status200OK)]

        public virtual Task<DirectoryDescriptorDto> MoveAsync(MoveDirectoryInput input)
        {
            return _shareDirectoryDescriptorAppService.MoveAsync(input);
        }

        [HttpPost]
        [Route("Rename")]
        [ProducesResponseType(typeof(DirectoryDescriptorDto), StatusCodes.Status200OK)]

        public virtual Task<DirectoryDescriptorDto> RenameAsync(Guid id, RenameDirectoryInput input)
        {
            return _shareDirectoryDescriptorAppService.RenameAsync(id, input);
        }
    }
}