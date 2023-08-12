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
using Resume.UserAccountBinds;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserAccountBinds
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserAccountBinds.Default)]
    public class UserAccountBindsAppService : ApplicationService, IUserAccountBindsAppService
    {
        private readonly IDistributedCache<UserAccountBindExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserAccountBindRepository _userAccountBindRepository;
        private readonly UserAccountBindManager _userAccountBindManager;

        public UserAccountBindsAppService(IUserAccountBindRepository userAccountBindRepository, UserAccountBindManager userAccountBindManager, IDistributedCache<UserAccountBindExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userAccountBindRepository = userAccountBindRepository;
            _userAccountBindManager = userAccountBindManager;
        }

        public virtual async Task<PagedResultDto<UserAccountBindDto>> GetListAsync(GetUserAccountBindsInput input)
        {
            var totalCount = await _userAccountBindRepository.GetCountAsync(input.FilterText, input.UserMainId, input.ThirdPartyTypeCode, input.ThirdPartyAccountId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userAccountBindRepository.GetListAsync(input.FilterText, input.UserMainId, input.ThirdPartyTypeCode, input.ThirdPartyAccountId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserAccountBindDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserAccountBind>, List<UserAccountBindDto>>(items)
            };
        }

        public virtual async Task<UserAccountBindDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserAccountBind, UserAccountBindDto>(await _userAccountBindRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserAccountBinds.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userAccountBindRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserAccountBinds.Create)]
        public virtual async Task<UserAccountBindDto> CreateAsync(UserAccountBindCreateDto input)
        {

            var userAccountBind = await _userAccountBindManager.CreateAsync(
            input.UserMainId, input.ThirdPartyTypeCode, input.ThirdPartyAccountId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserAccountBind, UserAccountBindDto>(userAccountBind);
        }

        [Authorize(ResumePermissions.UserAccountBinds.Edit)]
        public virtual async Task<UserAccountBindDto> UpdateAsync(Guid id, UserAccountBindUpdateDto input)
        {

            var userAccountBind = await _userAccountBindManager.UpdateAsync(
            id,
            input.UserMainId, input.ThirdPartyTypeCode, input.ThirdPartyAccountId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserAccountBind, UserAccountBindDto>(userAccountBind);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserAccountBindExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userAccountBindRepository.GetListAsync(input.FilterText, input.UserMainId, input.ThirdPartyTypeCode, input.ThirdPartyAccountId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserAccountBind>, List<UserAccountBindExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserAccountBinds.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserAccountBindExcelDownloadTokenCacheItem { Token = token },
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