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
using Resume.SystemTables;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.SystemTables
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.SystemTables.Default)]
    public class SystemTablesAppService : ApplicationService, ISystemTablesAppService
    {
        private readonly IDistributedCache<SystemTableExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ISystemTableRepository _systemTableRepository;
        private readonly SystemTableManager _systemTableManager;

        public SystemTablesAppService(ISystemTableRepository systemTableRepository, SystemTableManager systemTableManager, IDistributedCache<SystemTableExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _systemTableRepository = systemTableRepository;
            _systemTableManager = systemTableManager;
        }

        public virtual async Task<PagedResultDto<SystemTableDto>> GetListAsync(GetSystemTablesInput input)
        {
            var totalCount = await _systemTableRepository.GetCountAsync(input.FilterText, input.Name, input.AllowInsert, input.AllowUpdate, input.AllowDelete, input.AllowSelect, input.AllowExport, input.AllowImport, input.AllowPage, input.AllowSort, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _systemTableRepository.GetListAsync(input.FilterText, input.Name, input.AllowInsert, input.AllowUpdate, input.AllowDelete, input.AllowSelect, input.AllowExport, input.AllowImport, input.AllowPage, input.AllowSort, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SystemTableDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SystemTable>, List<SystemTableDto>>(items)
            };
        }

        public virtual async Task<SystemTableDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<SystemTable, SystemTableDto>(await _systemTableRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.SystemTables.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _systemTableRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.SystemTables.Create)]
        public virtual async Task<SystemTableDto> CreateAsync(SystemTableCreateDto input)
        {

            var systemTable = await _systemTableManager.CreateAsync(
            input.Name, input.AllowInsert, input.AllowUpdate, input.AllowDelete, input.AllowSelect, input.AllowExport, input.AllowImport, input.AllowPage, input.AllowSort, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemTable, SystemTableDto>(systemTable);
        }

        [Authorize(ResumePermissions.SystemTables.Edit)]
        public virtual async Task<SystemTableDto> UpdateAsync(Guid id, SystemTableUpdateDto input)
        {

            var systemTable = await _systemTableManager.UpdateAsync(
            id,
            input.Name, input.AllowInsert, input.AllowUpdate, input.AllowDelete, input.AllowSelect, input.AllowExport, input.AllowImport, input.AllowPage, input.AllowSort, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemTable, SystemTableDto>(systemTable);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemTableExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _systemTableRepository.GetListAsync(input.FilterText, input.Name, input.AllowInsert, input.AllowUpdate, input.AllowDelete, input.AllowSelect, input.AllowExport, input.AllowImport, input.AllowPage, input.AllowSort, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SystemTable>, List<SystemTableExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SystemTables.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SystemTableExcelDownloadTokenCacheItem { Token = token },
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