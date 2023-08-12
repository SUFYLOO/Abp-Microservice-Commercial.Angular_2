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
using Resume.UserCompanyBinds;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.UserCompanyBinds
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.UserCompanyBinds.Default)]
    public class UserCompanyBindsAppService : ApplicationService, IUserCompanyBindsAppService
    {
        private readonly IDistributedCache<UserCompanyBindExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IUserCompanyBindRepository _userCompanyBindRepository;
        private readonly UserCompanyBindManager _userCompanyBindManager;

        public UserCompanyBindsAppService(IUserCompanyBindRepository userCompanyBindRepository, UserCompanyBindManager userCompanyBindManager, IDistributedCache<UserCompanyBindExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _userCompanyBindRepository = userCompanyBindRepository;
            _userCompanyBindManager = userCompanyBindManager;
        }

        public virtual async Task<PagedResultDto<UserCompanyBindDto>> GetListAsync(GetUserCompanyBindsInput input)
        {
            var totalCount = await _userCompanyBindRepository.GetCountAsync(input.FilterText, input.UserMainId, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationsId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _userCompanyBindRepository.GetListAsync(input.FilterText, input.UserMainId, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationsId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<UserCompanyBindDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<UserCompanyBind>, List<UserCompanyBindDto>>(items)
            };
        }

        public virtual async Task<UserCompanyBindDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<UserCompanyBind, UserCompanyBindDto>(await _userCompanyBindRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.UserCompanyBinds.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _userCompanyBindRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.UserCompanyBinds.Create)]
        public virtual async Task<UserCompanyBindDto> CreateAsync(UserCompanyBindCreateDto input)
        {

            var userCompanyBind = await _userCompanyBindManager.CreateAsync(
            input.UserMainId, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationsId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserCompanyBind, UserCompanyBindDto>(userCompanyBind);
        }

        [Authorize(ResumePermissions.UserCompanyBinds.Edit)]
        public virtual async Task<UserCompanyBindDto> UpdateAsync(Guid id, UserCompanyBindUpdateDto input)
        {

            var userCompanyBind = await _userCompanyBindManager.UpdateAsync(
            id,
            input.UserMainId, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationsId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<UserCompanyBind, UserCompanyBindDto>(userCompanyBind);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(UserCompanyBindExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _userCompanyBindRepository.GetListAsync(input.FilterText, input.UserMainId, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationsId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<UserCompanyBind>, List<UserCompanyBindExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "UserCompanyBinds.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new UserCompanyBindExcelDownloadTokenCacheItem { Token = token },
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