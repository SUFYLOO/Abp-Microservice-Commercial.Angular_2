using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.FileManagement.Directories;
using Volo.FileManagement.Files;

namespace Resume.App
{
    [RemoteService(IsEnabled = false)]
    [Volo.Abp.DependencyInjection.Dependency( ReplaceServices = true)]
    [ExposeServices(typeof(IDirectoryDescriptorAppService), IncludeSelf = true)]
    public  class ShareDirectoryDescriptorAppService : DirectoryDescriptorAppService, ITransientDependency
    {
        public ShareDirectoryDescriptorAppService(IDirectoryManager directoryManager, IFileManager fileManager, IDirectoryDescriptorRepository directoryDescriptorRepository, IFileDescriptorRepository fileDescriptorRepository, IOptions<FileIconOption> fileIconOption)
            : base(directoryManager, fileManager, directoryDescriptorRepository, fileDescriptorRepository, fileIconOption)
        {
        }

        [AllowAnonymous]
        public override Task<DirectoryDescriptorDto> CreateAsync(CreateDirectoryInput input)
        {
            return base.CreateAsync(input);
        }

        [AllowAnonymous]
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        [AllowAnonymous]
        public override Task<DirectoryDescriptorDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        [AllowAnonymous]
        public override Task<PagedResultDto<DirectoryContentDto>> GetContentAsync(DirectoryContentRequestInput input)
        {
            return base.GetContentAsync(input);
        }

        [AllowAnonymous]
        public override Task<ListResultDto<DirectoryDescriptorInfoDto>> GetListAsync(Guid? parentId)
        {
            return base.GetListAsync(parentId);
        }

        [AllowAnonymous]
        public override Task<DirectoryDescriptorDto> MoveAsync(MoveDirectoryInput input)
        {
            return base.MoveAsync(input);
        }

        [AllowAnonymous]
        public override Task<DirectoryDescriptorDto> RenameAsync(Guid id, RenameDirectoryInput input)
        {
            return base.RenameAsync(id, input);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override Task CheckPolicyAsync(string policyName)
        {
            return base.CheckPolicyAsync(policyName);
        }

        protected override IStringLocalizer CreateLocalizer()
        {
            return base.CreateLocalizer();
        }
    }
}
