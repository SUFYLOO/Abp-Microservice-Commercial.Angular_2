using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Volo.FileManagement.Files;

namespace Resume.App
{
    public interface IShareFileDescriptorAppService : IApplicationService
    {
        Task<FileDescriptorDto> GetAsync(Guid id);

        Task<ListResultDto<FileDescriptorDto>> GetListAsync(Guid? directoryId);

        Task<FileDescriptorDto> RenameAsync(Guid id, RenameFileInput input);

        Task<IRemoteStreamContent> DownloadAsync(Guid id, string token);

        Task DeleteAsync(Guid id);

        Task<FileDescriptorDto> CreateAsync(Guid? directoryId, CreateFileInputWithStream inputWithStream);

        Task<FileDescriptorDto> MoveAsync(MoveFileInput input);

        Task<List<FileUploadPreInfoDto>> GetPreInfoAsync(List<FileUploadPreInfoRequest> input);

        Task<byte[]> GetContentAsync(Guid id);

        //Task<DownloadTokenResultDto> GetDownloadTokenAsync(Guid id);
    }
}
