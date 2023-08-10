using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Resume.Permissions;
using Resume.ShareMessageTpls;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ShareMessageTpls
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ShareMessageTpls.Default)]
    public class ShareMessageTplsAppService : ApplicationService, IShareMessageTplsAppService
    {
        private readonly IDistributedCache<ShareMessageTplExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IShareMessageTplRepository _shareMessageTplRepository;
        private readonly ShareMessageTplManager _shareMessageTplManager;

        public ShareMessageTplsAppService(IShareMessageTplRepository shareMessageTplRepository, ShareMessageTplManager shareMessageTplManager, IDistributedCache<ShareMessageTplExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _shareMessageTplRepository = shareMessageTplRepository;
            _shareMessageTplManager = shareMessageTplManager;
        }

        public virtual async Task<PagedResultDto<ShareMessageTplDto>> GetListAsync(GetShareMessageTplsInput input)
        {
            var totalCount = await _shareMessageTplRepository.GetCountAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.Name, input.Statement, input.TitleContents, input.ContentMail, input.ContentSMS, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _shareMessageTplRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.Name, input.Statement, input.TitleContents, input.ContentMail, input.ContentSMS, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ShareMessageTplDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ShareMessageTpl>, List<ShareMessageTplDto>>(items)
            };
        }

        public virtual async Task<ShareMessageTplDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ShareMessageTpl, ShareMessageTplDto>(await _shareMessageTplRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ShareMessageTpls.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _shareMessageTplRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ShareMessageTpls.Create)]
        public virtual async Task<ShareMessageTplDto> CreateAsync(ShareMessageTplCreateDto input)
        {

            var shareMessageTpl = await _shareMessageTplManager.CreateAsync(
            input.Key1, input.Key2, input.Key3, input.Name, input.Statement, input.TitleContents, input.ContentMail, input.ContentSMS, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareMessageTpl, ShareMessageTplDto>(shareMessageTpl);
        }

        [Authorize(ResumePermissions.ShareMessageTpls.Edit)]
        public virtual async Task<ShareMessageTplDto> UpdateAsync(Guid id, ShareMessageTplUpdateDto input)
        {

            var shareMessageTpl = await _shareMessageTplManager.UpdateAsync(
            id,
            input.Key1, input.Key2, input.Key3, input.Name, input.Statement, input.TitleContents, input.ContentMail, input.ContentSMS, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ShareMessageTpl, ShareMessageTplDto>(shareMessageTpl);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ShareMessageTplExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _shareMessageTplRepository.GetListAsync(input.FilterText, input.Key1, input.Key2, input.Key3, input.Name, input.Statement, input.TitleContents, input.ContentMail, input.ContentSMS, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ShareMessageTpl>, List<ShareMessageTplExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ShareMessageTpls.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ShareMessageTplExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}