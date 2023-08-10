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
using Resume.UserTokens;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserTokens
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserTokens.Default)]
    public class UserTokensAppService : ApplicationService, IUserTokensAppService
    {
        private readonly IDistributedCache<UserTokenExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly UserTokenManager _userTokenManager;

        public UserTokensAppService(IUserTokenRepository userTokenRepository, UserTokenManager userTokenManager, IDistributedCache<UserTokenExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userTokenRepository = userTokenRepository;
            _userTokenManager = userTokenManager;
        }

        public virtual async Task<PagedResultDto<UserTokenDto>> GetListAsync(GetUserTokensInput input)
        {
            var totalCount = await _userTokenRepository.GetCountAsync(input.FilterText, input.UserMainId, input.TokenOld, input.TokenNew, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userTokenRepository.GetListAsync(input.FilterText, input.UserMainId, input.TokenOld, input.TokenNew, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserTokenDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserToken>, List<UserTokenDto>>(items)
            };
        }

        public virtual async Task<UserTokenDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserToken, UserTokenDto>(await _userTokenRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserTokens.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userTokenRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserTokens.Create)]
        public virtual async Task<UserTokenDto> CreateAsync(UserTokenCreateDto input)
        {

            var userToken = await _userTokenManager.CreateAsync(
            input.UserMainId, input.TokenOld, input.TokenNew, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserToken, UserTokenDto>(userToken);
        }

        [Authorize(ResumePermissions.UserTokens.Edit)]
        public virtual async Task<UserTokenDto> UpdateAsync(Guid id, UserTokenUpdateDto input)
        {

            var userToken = await _userTokenManager.UpdateAsync(
            id,
            input.UserMainId, input.TokenOld, input.TokenNew, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<UserToken, UserTokenDto>(userToken);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserTokenExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userTokenRepository.GetListAsync(input.FilterText, input.UserMainId, input.TokenOld, input.TokenNew, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserToken>, List<UserTokenExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserTokens.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserTokenExcelDownloadTokenCacheItem { Token = token },
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