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
using Resume.SystemValidates;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.SystemValidates
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.SystemValidates.Default)]
    public class SystemValidatesAppService : ApplicationService, ISystemValidatesAppService
    {
        private readonly IDistributedCache<SystemValidateExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ISystemValidateRepository _systemValidateRepository;
        private readonly SystemValidateManager _systemValidateManager;

        public SystemValidatesAppService(ISystemValidateRepository systemValidateRepository, SystemValidateManager systemValidateManager, IDistributedCache<SystemValidateExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _systemValidateRepository = systemValidateRepository;
            _systemValidateManager = systemValidateManager;
        }

        public virtual async Task<PagedResultDto<SystemValidateDto>> GetListAsync(GetSystemValidatesInput input)
        {
            var totalCount = await _systemValidateRepository.GetCountAsync(input.FilterText, input.Param, input.DateOpenMin, input.DateOpenMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _systemValidateRepository.GetListAsync(input.FilterText, input.Param, input.DateOpenMin, input.DateOpenMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SystemValidateDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SystemValidate>, List<SystemValidateDto>>(items)
            };
        }

        public virtual async Task<SystemValidateDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<SystemValidate, SystemValidateDto>(await _systemValidateRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.SystemValidates.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _systemValidateRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.SystemValidates.Create)]
        public virtual async Task<SystemValidateDto> CreateAsync(SystemValidateCreateDto input)
        {

            var systemValidate = await _systemValidateManager.CreateAsync(
            input.Param, input.DateOpen, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<SystemValidate, SystemValidateDto>(systemValidate);
        }

        [Authorize(ResumePermissions.SystemValidates.Edit)]
        public virtual async Task<SystemValidateDto> UpdateAsync(Guid id, SystemValidateUpdateDto input)
        {

            var systemValidate = await _systemValidateManager.UpdateAsync(
            id,
            input.Param, input.DateOpen, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<SystemValidate, SystemValidateDto>(systemValidate);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemValidateExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _systemValidateRepository.GetListAsync(input.FilterText, input.Param, input.DateOpenMin, input.DateOpenMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SystemValidate>, List<SystemValidateExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SystemValidates.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SystemValidateExcelDownloadTokenCacheItem { Token = token },
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