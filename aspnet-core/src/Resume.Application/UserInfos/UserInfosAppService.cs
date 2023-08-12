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
using Resume.UserInfos;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserInfos
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserInfos.Default)]
    public class UserInfosAppService : ApplicationService, IUserInfosAppService
    {
        private readonly IDistributedCache<UserInfoExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly UserInfoManager _userInfoManager;

        public UserInfosAppService(IUserInfoRepository userInfoRepository, UserInfoManager userInfoManager, IDistributedCache<UserInfoExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userInfoRepository = userInfoRepository;
            _userInfoManager = userInfoManager;
        }

        public virtual async Task<PagedResultDto<UserInfoDto>> GetListAsync(GetUserInfosInput input)
        {
            var totalCount = await _userInfoRepository.GetCountAsync(input.FilterText, input.UserMainId, input.NameC, input.NameE, input.IdentityNo, input.BirthDateMin, input.BirthDateMax, input.SexCode, input.BloodCode, input.PlaceOfBirthCode, input.PassportNo, input.NationalityCode, input.ResidenceNo, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userInfoRepository.GetListAsync(input.FilterText, input.UserMainId, input.NameC, input.NameE, input.IdentityNo, input.BirthDateMin, input.BirthDateMax, input.SexCode, input.BloodCode, input.PlaceOfBirthCode, input.PassportNo, input.NationalityCode, input.ResidenceNo, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserInfoDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserInfo>, List<UserInfoDto>>(items)
            };
        }

        public virtual async Task<UserInfoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserInfo, UserInfoDto>(await _userInfoRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserInfos.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userInfoRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserInfos.Create)]
        public virtual async Task<UserInfoDto> CreateAsync(UserInfoCreateDto input)
        {

            var userInfo = await _userInfoManager.CreateAsync(
            input.UserMainId, input.NameC, input.NameE, input.IdentityNo, input.SexCode, input.BloodCode, input.PlaceOfBirthCode, input.PassportNo, input.NationalityCode, input.ResidenceNo, input.BirthDate, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserInfo, UserInfoDto>(userInfo);
        }

        [Authorize(ResumePermissions.UserInfos.Edit)]
        public virtual async Task<UserInfoDto> UpdateAsync(Guid id, UserInfoUpdateDto input)
        {

            var userInfo = await _userInfoManager.UpdateAsync(
            id,
            input.UserMainId, input.NameC, input.NameE, input.IdentityNo, input.SexCode, input.BloodCode, input.PlaceOfBirthCode, input.PassportNo, input.NationalityCode, input.ResidenceNo, input.BirthDate, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<UserInfo, UserInfoDto>(userInfo);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserInfoExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userInfoRepository.GetListAsync(input.FilterText, input.UserMainId, input.NameC, input.NameE, input.IdentityNo, input.BirthDateMin, input.BirthDateMax, input.SexCode, input.BloodCode, input.PlaceOfBirthCode, input.PassportNo, input.NationalityCode, input.ResidenceNo, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserInfo>, List<UserInfoExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserInfos.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserInfoExcelDownloadTokenCacheItem { Token = token },
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