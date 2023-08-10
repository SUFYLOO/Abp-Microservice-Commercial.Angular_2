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
using Resume.CompanyUsers;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyUsers
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyUsers.Default)]
    public class CompanyUsersAppService : ApplicationService, ICompanyUsersAppService
    {
        private readonly IDistributedCache<CompanyUserExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly CompanyUserManager _companyUserManager;

        public CompanyUsersAppService(ICompanyUserRepository companyUserRepository, CompanyUserManager companyUserManager, IDistributedCache<CompanyUserExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyUserRepository = companyUserRepository;
            _companyUserManager = companyUserManager;
        }

        public virtual async Task<PagedResultDto<CompanyUserDto>> GetListAsync(GetCompanyUsersInput input)
        {
            var totalCount = await _companyUserRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.UserMainId, input.JobName, input.OfficePhone, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.MatchingReceive);
            var items = await _companyUserRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.UserMainId, input.JobName, input.OfficePhone, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.MatchingReceive, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyUserDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyUser>, List<CompanyUserDto>>(items)
            };
        }

        public virtual async Task<CompanyUserDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyUser, CompanyUserDto>(await _companyUserRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyUsers.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyUserRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyUsers.Create)]
        public virtual async Task<CompanyUserDto> CreateAsync(CompanyUserCreateDto input)
        {

            var companyUser = await _companyUserManager.CreateAsync(
            input.CompanyMainId, input.UserMainId, input.DateA, input.DateD, input.Sort, input.Status, input.MatchingReceive, input.JobName, input.OfficePhone, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<CompanyUser, CompanyUserDto>(companyUser);
        }

        [Authorize(ResumePermissions.CompanyUsers.Edit)]
        public virtual async Task<CompanyUserDto> UpdateAsync(Guid id, CompanyUserUpdateDto input)
        {

            var companyUser = await _companyUserManager.UpdateAsync(
            id,
            input.CompanyMainId, input.UserMainId, input.DateA, input.DateD, input.Sort, input.Status, input.MatchingReceive, input.JobName, input.OfficePhone, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<CompanyUser, CompanyUserDto>(companyUser);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyUserExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyUserRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.UserMainId, input.JobName, input.OfficePhone, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.MatchingReceive);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyUser>, List<CompanyUserExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyUsers.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyUserExcelDownloadTokenCacheItem { Token = token },
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