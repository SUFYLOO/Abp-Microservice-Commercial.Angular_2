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
using Resume.SystemPages;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.SystemPages
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.SystemPages.Default)]
    public class SystemPagesAppService : ApplicationService, ISystemPagesAppService
    {
        private readonly IDistributedCache<SystemPageExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ISystemPageRepository _systemPageRepository;
        private readonly SystemPageManager _systemPageManager;

        public SystemPagesAppService(ISystemPageRepository systemPageRepository, SystemPageManager systemPageManager, IDistributedCache<SystemPageExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _systemPageRepository = systemPageRepository;
            _systemPageManager = systemPageManager;
        }

        public virtual async Task<PagedResultDto<SystemPageDto>> GetListAsync(GetSystemPagesInput input)
        {
            var totalCount = await _systemPageRepository.GetCountAsync(input.FilterText, input.TypeCode, input.FilePath, input.FileName, input.FileTitle, input.SystemUserRoleKeys, input.ParentCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _systemPageRepository.GetListAsync(input.FilterText, input.TypeCode, input.FilePath, input.FileName, input.FileTitle, input.SystemUserRoleKeys, input.ParentCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SystemPageDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SystemPage>, List<SystemPageDto>>(items)
            };
        }

        public virtual async Task<SystemPageDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<SystemPage, SystemPageDto>(await _systemPageRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.SystemPages.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _systemPageRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.SystemPages.Create)]
        public virtual async Task<SystemPageDto> CreateAsync(SystemPageCreateDto input)
        {

            var systemPage = await _systemPageManager.CreateAsync(
            input.TypeCode, input.SystemUserRoleKeys, input.ParentCode, input.DateA, input.DateD, input.Sort, input.Status, input.FilePath, input.FileName, input.FileTitle, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemPage, SystemPageDto>(systemPage);
        }

        [Authorize(ResumePermissions.SystemPages.Edit)]
        public virtual async Task<SystemPageDto> UpdateAsync(Guid id, SystemPageUpdateDto input)
        {

            var systemPage = await _systemPageManager.UpdateAsync(
            id,
            input.TypeCode, input.SystemUserRoleKeys, input.ParentCode, input.DateA, input.DateD, input.Sort, input.Status, input.FilePath, input.FileName, input.FileTitle, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemPage, SystemPageDto>(systemPage);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemPageExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _systemPageRepository.GetListAsync(input.FilterText, input.TypeCode, input.FilePath, input.FileName, input.FileTitle, input.SystemUserRoleKeys, input.ParentCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SystemPage>, List<SystemPageExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SystemPages.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SystemPageExcelDownloadTokenCacheItem { Token = token },
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