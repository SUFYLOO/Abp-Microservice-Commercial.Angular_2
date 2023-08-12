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
using Resume.SystemUserRoles;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.SystemUserRoles
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.SystemUserRoles.Default)]
    public class SystemUserRolesAppService : ApplicationService, ISystemUserRolesAppService
    {
        private readonly IDistributedCache<SystemUserRoleExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ISystemUserRoleRepository _systemUserRoleRepository;
        private readonly SystemUserRoleManager _systemUserRoleManager;

        public SystemUserRolesAppService(ISystemUserRoleRepository systemUserRoleRepository, SystemUserRoleManager systemUserRoleManager, IDistributedCache<SystemUserRoleExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _systemUserRoleRepository = systemUserRoleRepository;
            _systemUserRoleManager = systemUserRoleManager;
        }

        public virtual async Task<PagedResultDto<SystemUserRoleDto>> GetListAsync(GetSystemUserRolesInput input)
        {
            var totalCount = await _systemUserRoleRepository.GetCountAsync(input.FilterText, input.Name, input.KeysMin, input.KeysMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _systemUserRoleRepository.GetListAsync(input.FilterText, input.Name, input.KeysMin, input.KeysMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<SystemUserRoleDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<SystemUserRole>, List<SystemUserRoleDto>>(items)
            };
        }

        public virtual async Task<SystemUserRoleDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<SystemUserRole, SystemUserRoleDto>(await _systemUserRoleRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.SystemUserRoles.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _systemUserRoleRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.SystemUserRoles.Create)]
        public virtual async Task<SystemUserRoleDto> CreateAsync(SystemUserRoleCreateDto input)
        {

            var systemUserRole = await _systemUserRoleManager.CreateAsync(
            input.Name, input.Keys, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<SystemUserRole, SystemUserRoleDto>(systemUserRole);
        }

        [Authorize(ResumePermissions.SystemUserRoles.Edit)]
        public virtual async Task<SystemUserRoleDto> UpdateAsync(Guid id, SystemUserRoleUpdateDto input)
        {

            var systemUserRole = await _systemUserRoleManager.UpdateAsync(
            id,
            input.Name, input.Keys, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<SystemUserRole, SystemUserRoleDto>(systemUserRole);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(SystemUserRoleExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _systemUserRoleRepository.GetListAsync(input.FilterText, input.Name, input.KeysMin, input.KeysMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<SystemUserRole>, List<SystemUserRoleExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "SystemUserRoles.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new SystemUserRoleExcelDownloadTokenCacheItem { Token = token },
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