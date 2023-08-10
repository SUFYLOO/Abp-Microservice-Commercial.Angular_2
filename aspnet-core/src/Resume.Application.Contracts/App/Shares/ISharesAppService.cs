using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Resume.Shared;
using Volo.Abp.Account;
using System.Collections.Generic;
using Volo.FileManagement.Files;

namespace Resume.App.Shares
{
    public interface ISharesAppService : IApplicationService
    {
        Task<ResultDto<List<TextValueDto>>> GetShareCodeTextValueAsync(ShareCodeInput input);
        Task<ResultDto<List<ShareCodeByGroupCodeDto>>> GetShareCodeByGroupCodeAsync(ShareCodeByGroupCodeInput input);
        Task<ResultDto<List<NameCodeDto>>> GetShareCodeNameCodeAsync(ShareCodeInput input);
        Task<ResultDto<SendShareSendQueueDto>> SendShareSendQueueAsync(SendShareSendQueueInput input);
        Task<ResultDto<SaveShareUploadDto>> SaveShareUploadAsync(SaveShareUploadInput input);
        Task<ResultDto<List<ShareUploadsDto>>> GetShareUploadListAsync(ShareUploadListInput input);
        Task<IRemoteStreamContent> DownloadShareUploadAsync(DownloadShareUploadInput input);
    }
}