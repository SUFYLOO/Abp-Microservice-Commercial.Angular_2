using Resume.App.Shares;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.FileManagement.Directories;

namespace Resume.App
{
    public interface IShareDirectoryDescriptorAppService : IApplicationService
    {
        Task<DirectoryDescriptorDto> GetAsync(Guid id);

        Task<ListResultDto<DirectoryDescriptorInfoDto>> GetListAsync(Guid? parentId);

        Task<DirectoryDescriptorDto> CreateAsync(CreateDirectoryInput input);

        Task<DirectoryDescriptorDto> RenameAsync(Guid id, RenameDirectoryInput input);

        Task<PagedResultDto<DirectoryContentDto>> GetContentAsync(DirectoryContentRequestInput input);

        Task DeleteAsync(Guid id);

        Task<DirectoryDescriptorDto> MoveAsync(MoveDirectoryInput input);
    }
}
