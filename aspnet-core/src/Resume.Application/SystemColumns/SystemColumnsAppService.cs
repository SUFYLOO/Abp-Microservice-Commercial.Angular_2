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
using Resume.SystemColumns;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.SystemColumns
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.SystemColumns.Default)]
    public class SystemColumnsAppService : ApplicationService, ISystemColumnsAppService
    {
        private readonly IDistributedCache<SystemColumnExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ISystemColumnRepository _systemColumnRepository;
        private readonly SystemColumnManager _systemColumnManager;

        public SystemColumnsAppService(ISystemColumnRepository systemColumnRepository, SystemColumnManager systemColumnManager, IDistributedCache<SystemColumnExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _systemColumnRepository = systemColumnRepository;
            _systemColumnManager = systemColumnManager;
        }

        public virtual async Task<PagedResultDto<SystemColumnDto>> GetListAsync(GetSystemColumnsInput input)
        {
            var totalCount = await _systemColumnRepository.GetCountAsync(input.FilterText, input.SystemTableId, input.Name, input.IsKey, input.IsSensitive, input.NeedMask, input.DefaultValue, input.CheckCode, input.Related, input.AllowUpdate, input.AllowNull, input.AllowEmpty, input.AllowExport, input.AllowSort, input.ColumnTypeCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _systemColumnRepository.GetListAsync(input.FilterText, input.SystemTableId, input.Name, input.IsKey, input.IsSensitive, input.NeedMask, input.DefaultValue, input.CheckCode, input.Related, input.AllowUpdate, input.AllowNull, input.AllowEmpty, input.AllowExport, input.AllowSort, input.ColumnTypeCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SystemColumnDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SystemColumn>, List<SystemColumnDto>>(items)
            };
        }

        public virtual async Task<SystemColumnDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<SystemColumn, SystemColumnDto>(await _systemColumnRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.SystemColumns.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _systemColumnRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.SystemColumns.Create)]
        public virtual async Task<SystemColumnDto> CreateAsync(SystemColumnCreateDto input)
        {

            var systemColumn = await _systemColumnManager.CreateAsync(
            input.SystemTableId, input.Name, input.IsKey, input.IsSensitive, input.NeedMask, input.DefaultValue, input.CheckCode, input.Related, input.AllowUpdate, input.AllowNull, input.AllowEmpty, input.AllowExport, input.AllowSort, input.ColumnTypeCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemColumn, SystemColumnDto>(systemColumn);
        }

        [Authorize(ResumePermissions.SystemColumns.Edit)]
        public virtual async Task<SystemColumnDto> UpdateAsync(Guid id, SystemColumnUpdateDto input)
        {

            var systemColumn = await _systemColumnManager.UpdateAsync(
            id,
            input.SystemTableId, input.Name, input.IsKey, input.IsSensitive, input.NeedMask, input.DefaultValue, input.CheckCode, input.Related, input.AllowUpdate, input.AllowNull, input.AllowEmpty, input.AllowExport, input.AllowSort, input.ColumnTypeCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<SystemColumn, SystemColumnDto>(systemColumn);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemColumnExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _systemColumnRepository.GetListAsync(input.FilterText, input.SystemTableId, input.Name, input.IsKey, input.IsSensitive, input.NeedMask, input.DefaultValue, input.CheckCode, input.Related, input.AllowUpdate, input.AllowNull, input.AllowEmpty, input.AllowExport, input.AllowSort, input.ColumnTypeCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SystemColumn>, List<SystemColumnExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SystemColumns.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SystemColumnExcelDownloadTokenCacheItem { Token = token },
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