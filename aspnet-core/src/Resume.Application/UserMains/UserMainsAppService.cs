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
using Resume.UserMains;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserMains
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserMains.Default)]
    public class UserMainsAppService : ApplicationService, IUserMainsAppService
    {
        private readonly IDistributedCache<UserMainExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserMainRepository _userMainRepository;
        private readonly UserMainManager _userMainManager;

        public UserMainsAppService(IUserMainRepository userMainRepository, UserMainManager userMainManager, IDistributedCache<UserMainExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userMainRepository = userMainRepository;
            _userMainManager = userMainManager;
        }

        public virtual async Task<PagedResultDto<UserMainDto>> GetListAsync(GetUserMainsInput input)
        {
            var totalCount = await _userMainRepository.GetCountAsync(input.FilterText, input.UserId, input.Name, input.AnonymousName, input.LoginAccountCode, input.LoginMobilePhoneUpdate, input.LoginMobilePhone, input.LoginEmailUpdate, input.LoginEmail, input.LoginIdentityNo, input.Password, input.SystemUserRoleKeysMin, input.SystemUserRoleKeysMax, input.AllowSearch, input.DateAMin, input.DateAMax, input.ExtendedInformation, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Matching);
            var items = await _userMainRepository.GetListAsync(input.FilterText, input.UserId, input.Name, input.AnonymousName, input.LoginAccountCode, input.LoginMobilePhoneUpdate, input.LoginMobilePhone, input.LoginEmailUpdate, input.LoginEmail, input.LoginIdentityNo, input.Password, input.SystemUserRoleKeysMin, input.SystemUserRoleKeysMax, input.AllowSearch, input.DateAMin, input.DateAMax, input.ExtendedInformation, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Matching, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserMainDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserMain>, List<UserMainDto>>(items)
            };
        }

        public virtual async Task<UserMainDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserMain, UserMainDto>(await _userMainRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserMains.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userMainRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserMains.Create)]
        public virtual async Task<UserMainDto> CreateAsync(UserMainCreateDto input)
        {

            var userMain = await _userMainManager.CreateAsync(
            input.UserId, input.Name, input.LoginAccountCode, input.LoginMobilePhoneUpdate, input.LoginMobilePhone, input.LoginEmailUpdate, input.LoginEmail, input.LoginIdentityNo, input.Password, input.SystemUserRoleKeys, input.AllowSearch, input.DateA, input.DateD, input.Sort, input.Status, input.Matching, input.AnonymousName, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<UserMain, UserMainDto>(userMain);
        }

        [Authorize(ResumePermissions.UserMains.Edit)]
        public virtual async Task<UserMainDto> UpdateAsync(Guid id, UserMainUpdateDto input)
        {

            var userMain = await _userMainManager.UpdateAsync(
            id,
            input.UserId, input.Name, input.LoginAccountCode, input.LoginMobilePhoneUpdate, input.LoginMobilePhone, input.LoginEmailUpdate, input.LoginEmail, input.LoginIdentityNo, input.Password, input.SystemUserRoleKeys, input.AllowSearch, input.DateA, input.DateD, input.Sort, input.Status, input.Matching, input.AnonymousName, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<UserMain, UserMainDto>(userMain);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserMainExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userMainRepository.GetListAsync(input.FilterText, input.UserId, input.Name, input.AnonymousName, input.LoginAccountCode, input.LoginMobilePhoneUpdate, input.LoginMobilePhone, input.LoginEmailUpdate, input.LoginEmail, input.LoginIdentityNo, input.Password, input.SystemUserRoleKeysMin, input.SystemUserRoleKeysMax, input.AllowSearch, input.DateAMin, input.DateAMax, input.ExtendedInformation, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Matching);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserMain>, List<UserMainExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserMains.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserMainExcelDownloadTokenCacheItem { Token = token },
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