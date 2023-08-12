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
using Resume.UserVerifys;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserVerifys
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserVerifys.Default)]
    public class UserVerifysAppService : ApplicationService, IUserVerifysAppService
    {
        private readonly IDistributedCache<UserVerifyExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserVerifyRepository _userVerifyRepository;
        private readonly UserVerifyManager _userVerifyManager;

        public UserVerifysAppService(IUserVerifyRepository userVerifyRepository, UserVerifyManager userVerifyManager, IDistributedCache<UserVerifyExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userVerifyRepository = userVerifyRepository;
            _userVerifyManager = userVerifyManager;
        }

        public virtual async Task<PagedResultDto<UserVerifyDto>> GetListAsync(GetUserVerifysInput input)
        {
            var totalCount = await _userVerifyRepository.GetCountAsync(input.FilterText, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userVerifyRepository.GetListAsync(input.FilterText, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserVerifyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserVerify>, List<UserVerifyDto>>(items)
            };
        }

        public virtual async Task<UserVerifyDto> GetAsync(long id)
        {
            return ObjectMapper.Map<UserVerify, UserVerifyDto>(await _userVerifyRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserVerifys.Delete)]
        public virtual async Task DeleteAsync(long id)
        {
            await _userVerifyRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserVerifys.Create)]
        public virtual async Task<UserVerifyDto> CreateAsync(UserVerifyCreateDto input)
        {

            var userVerify = await _userVerifyManager.CreateAsync(
            input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserVerify, UserVerifyDto>(userVerify);
        }

        [Authorize(ResumePermissions.UserVerifys.Edit)]
        public virtual async Task<UserVerifyDto> UpdateAsync(long id, UserVerifyUpdateDto input)
        {

            var userVerify = await _userVerifyManager.UpdateAsync(
            id,
            input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserVerify, UserVerifyDto>(userVerify);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserVerifyExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userVerifyRepository.GetListAsync(input.FilterText, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserVerify>, List<UserVerifyExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserVerifys.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserVerifyExcelDownloadTokenCacheItem { Token = token },
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