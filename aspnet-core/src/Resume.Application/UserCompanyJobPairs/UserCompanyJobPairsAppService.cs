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
using Resume.UserCompanyJobPairs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserCompanyJobPairs
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserCompanyJobPairs.Default)]
    public class UserCompanyJobPairsAppService : ApplicationService, IUserCompanyJobPairsAppService
    {
        private readonly IDistributedCache<UserCompanyJobPairExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserCompanyJobPairRepository _userCompanyJobPairRepository;
        private readonly UserCompanyJobPairManager _userCompanyJobPairManager;

        public UserCompanyJobPairsAppService(IUserCompanyJobPairRepository userCompanyJobPairRepository, UserCompanyJobPairManager userCompanyJobPairManager, IDistributedCache<UserCompanyJobPairExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userCompanyJobPairRepository = userCompanyJobPairRepository;
            _userCompanyJobPairManager = userCompanyJobPairManager;
        }

        public virtual async Task<PagedResultDto<UserCompanyJobPairDto>> GetListAsync(GetUserCompanyJobPairsInput input)
        {
            var totalCount = await _userCompanyJobPairRepository.GetCountAsync(input.FilterText, input.UserMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userCompanyJobPairRepository.GetListAsync(input.FilterText, input.UserMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserCompanyJobPairDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserCompanyJobPair>, List<UserCompanyJobPairDto>>(items)
            };
        }

        public virtual async Task<UserCompanyJobPairDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserCompanyJobPair, UserCompanyJobPairDto>(await _userCompanyJobPairRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserCompanyJobPairs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userCompanyJobPairRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserCompanyJobPairs.Create)]
        public virtual async Task<UserCompanyJobPairDto> CreateAsync(UserCompanyJobPairCreateDto input)
        {

            var userCompanyJobPair = await _userCompanyJobPairManager.CreateAsync(
            input.UserMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserCompanyJobPair, UserCompanyJobPairDto>(userCompanyJobPair);
        }

        [Authorize(ResumePermissions.UserCompanyJobPairs.Edit)]
        public virtual async Task<UserCompanyJobPairDto> UpdateAsync(Guid id, UserCompanyJobPairUpdateDto input)
        {

            var userCompanyJobPair = await _userCompanyJobPairManager.UpdateAsync(
            id,
            input.UserMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserCompanyJobPair, UserCompanyJobPairDto>(userCompanyJobPair);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobPairExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userCompanyJobPairRepository.GetListAsync(input.FilterText, input.UserMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserCompanyJobPair>, List<UserCompanyJobPairExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserCompanyJobPairs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserCompanyJobPairExcelDownloadTokenCacheItem { Token = token },
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