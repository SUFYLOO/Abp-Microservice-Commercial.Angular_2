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
using Resume.UserCompanyJobApplies;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserCompanyJobApplies
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserCompanyJobApplies.Default)]
    public class UserCompanyJobAppliesAppService : ApplicationService, IUserCompanyJobAppliesAppService
    {
        private readonly IDistributedCache<UserCompanyJobApplyExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserCompanyJobApplyRepository _userCompanyJobApplyRepository;
        private readonly UserCompanyJobApplyManager _userCompanyJobApplyManager;

        public UserCompanyJobAppliesAppService(IUserCompanyJobApplyRepository userCompanyJobApplyRepository, UserCompanyJobApplyManager userCompanyJobApplyManager, IDistributedCache<UserCompanyJobApplyExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userCompanyJobApplyRepository = userCompanyJobApplyRepository;
            _userCompanyJobApplyManager = userCompanyJobApplyManager;
        }

        public virtual async Task<PagedResultDto<UserCompanyJobApplyDto>> GetListAsync(GetUserCompanyJobAppliesInput input)
        {
            var totalCount = await _userCompanyJobApplyRepository.GetCountAsync(input.FilterText, input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userCompanyJobApplyRepository.GetListAsync(input.FilterText, input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserCompanyJobApplyDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserCompanyJobApply>, List<UserCompanyJobApplyDto>>(items)
            };
        }

        public virtual async Task<UserCompanyJobApplyDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserCompanyJobApply, UserCompanyJobApplyDto>(await _userCompanyJobApplyRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserCompanyJobApplies.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userCompanyJobApplyRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserCompanyJobApplies.Create)]
        public virtual async Task<UserCompanyJobApplyDto> CreateAsync(UserCompanyJobApplyCreateDto input)
        {

            var userCompanyJobApply = await _userCompanyJobApplyManager.CreateAsync(
            input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserCompanyJobApply, UserCompanyJobApplyDto>(userCompanyJobApply);
        }

        [Authorize(ResumePermissions.UserCompanyJobApplies.Edit)]
        public virtual async Task<UserCompanyJobApplyDto> UpdateAsync(Guid id, UserCompanyJobApplyUpdateDto input)
        {

            var userCompanyJobApply = await _userCompanyJobApplyManager.UpdateAsync(
            id,
            input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<UserCompanyJobApply, UserCompanyJobApplyDto>(userCompanyJobApply);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyJobApplyExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userCompanyJobApplyRepository.GetListAsync(input.FilterText, input.UserMainId, input.CompanyJobId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserCompanyJobApply>, List<UserCompanyJobApplyExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserCompanyJobApplies.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserCompanyJobApplyExcelDownloadTokenCacheItem { Token = token },
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