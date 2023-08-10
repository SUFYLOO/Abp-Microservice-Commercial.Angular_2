using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.BlobStoring;
using Volo.Abp.Caching;
using Volo.Abp.Content;
using Volo.Abp.DependencyInjection;
using Volo.FileManagement;
using Volo.FileManagement.Directories;
using Volo.FileManagement.Files;
using static Volo.FileManagement.Authorization.FileManagementPermissions;

namespace Resume.App
{
    [RemoteService(IsEnabled = false)]
    [Volo.Abp.DependencyInjection.Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IFileDescriptorAppService), IncludeSelf = true)]
    [AllowAnonymous]
    public class ShareFileDescriptorAppService : FileDescriptorAppService, ITransientDependency
    {
   
        public ShareFileDescriptorAppService(IFileManager fileManager, IFileDescriptorRepository fileDescriptorRepository, IBlobContainer<FileManagementContainer> blobContainer, IDistributedCache<FileDownloadTokenCacheItem, string> downloadTokenCache)
            :base(fileManager  , fileDescriptorRepository , blobContainer , downloadTokenCache)
        {
        }

        public override Task<FileDescriptorDto> CreateAsync(Guid? directoryId, CreateFileInputWithStream inputWithStream)
        {
            return base.CreateAsync(directoryId, inputWithStream);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<IRemoteStreamContent> DownloadAsync(Guid id, string token)
        {
            var tk =  GetDownloadTokenAsync(id);

            return base.DownloadAsync(id, tk.Result.Token);
        }

        public override Task<FileDescriptorDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        public override Task<byte[]> GetContentAsync(Guid id)
        {
            return base.GetContentAsync(id);
        }

        public override Task<ListResultDto<FileDescriptorDto>> GetListAsync(Guid? directoryId)
        {
            return base.GetListAsync(directoryId);
        }

        public override Task<List<FileUploadPreInfoDto>> GetPreInfoAsync(List<FileUploadPreInfoRequest> input)
        {
            return base.GetPreInfoAsync(input);
        }

        public override Task<FileDescriptorDto> MoveAsync(MoveFileInput input)
        {
            return base.MoveAsync(input);
        }

        public override Task<FileDescriptorDto> RenameAsync(Guid id, RenameFileInput input)
        {
            return base.RenameAsync(id, input);
        }

        protected override string BeautifySize(long size)
        {
            return base.BeautifySize(size);
        }

        protected override Task CheckSizeAsync(long contentLength)
        {
            return base.CheckSizeAsync(contentLength);
        }

        protected override string FormatSize(float size)
        {
            return base.FormatSize(size);
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
