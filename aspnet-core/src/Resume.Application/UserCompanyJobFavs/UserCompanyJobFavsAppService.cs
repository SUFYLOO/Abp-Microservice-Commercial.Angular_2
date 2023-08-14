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
using Resume.UserCompanyJobFavs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserCompanyJobFavs
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserCompanyJobFavs.Default)]
    public class UserCompanyJobFavsAppService : ApplicationService, IUserCompanyJobFavsAppService
    {
        private readonly IDistributedCache<UserCompanyJobFavExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserCompanyJobFavRepository _userCompanyJobFavRepository;
        private readonly UserCompanyJobFavManager _userCompanyJobFavManager;

        public UserCompanyJobFavsAppService(IUserCompanyJobFavRepository userCompanyJobFavRepository, UserCompanyJobFavManager userCompanyJobFavManager, IDistributedCache<UserCompanyJobFavExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userCompanyJobFavRepository = userCompanyJobFavRepository;
            _userCompanyJobFavManager = userCompanyJobFavManager;
        }

        public virtual async Task<PagedResultDto<UserCompanyJobFavDto>> GetListAsync(GetUserCompanyJobFavsInput input)
        {
            var totalCount = await _userCompanyJobFavRepository.GetCountAsync(input.FilterText, input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userCompanyJobFavRepository.GetListAsync(input.FilterText, input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserCompanyJobFavDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserCompanyJobFav>, List<UserCompanyJobFavDto>>(items)
            };
        }

        public virtual async Task<UserCompanyJobFavDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserCompanyJobFav, UserCompanyJobFavDto>(await _userCompanyJobFavRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserCompanyJobFavs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userCompanyJobFavRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserCompanyJobFavs.Create)]
        public virtual async Task<UserCompanyJobFavDto> CreateAsync(UserCompanyJobFavCreateDto input)
        {

            var userCompanyJobFav = await _userCompanyJobFavManager.CreateAsync(
            input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserCompanyJobFav, UserCompanyJobFavDto>(userCompanyJobFav);
        }

        [Authorize(ResumePermissions.UserCompanyJobFavs.Edit)]
        public virtual async Task<UserCompanyJobFavDto> UpdateAsync(Guid id, UserCompanyJobFavUpdateDto input)
        {

            var userCompanyJobFav = await _userCompanyJobFavManager.UpdateAsync(
            id,
            input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserCompanyJobFav, UserCompanyJobFavDto>(userCompanyJobFav);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobFavExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userCompanyJobFavRepository.GetListAsync(input.FilterText, input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserCompanyJobFav>, List<UserCompanyJobFavExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserCompanyJobFavs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserCompanyJobFavExcelDownloadTokenCacheItem { Token = token },
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