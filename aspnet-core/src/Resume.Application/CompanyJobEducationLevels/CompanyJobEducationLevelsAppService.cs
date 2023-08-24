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
using Resume.CompanyJobEducationLevels;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobEducationLevels
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobEducationLevels.Default)]
    public class CompanyJobEducationLevelsAppService : ApplicationService, ICompanyJobEducationLevelsAppService
    {
        private readonly IDistributedCache<CompanyJobEducationLevelExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobEducationLevelRepository _companyJobEducationLevelRepository;
        private readonly CompanyJobEducationLevelManager _companyJobEducationLevelManager;

        public CompanyJobEducationLevelsAppService(ICompanyJobEducationLevelRepository companyJobEducationLevelRepository, CompanyJobEducationLevelManager companyJobEducationLevelManager, IDistributedCache<CompanyJobEducationLevelExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobEducationLevelRepository = companyJobEducationLevelRepository;
            _companyJobEducationLevelManager = companyJobEducationLevelManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobEducationLevelDto>> GetListAsync(GetCompanyJobEducationLevelsInput input)
        {
            var totalCount = await _companyJobEducationLevelRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.EducationLevelCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobEducationLevelRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.EducationLevelCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobEducationLevelDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobEducationLevel>, List<CompanyJobEducationLevelDto>>(items)
            };
        }

        public virtual async Task<CompanyJobEducationLevelDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobEducationLevel, CompanyJobEducationLevelDto>(await _companyJobEducationLevelRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobEducationLevels.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobEducationLevelRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobEducationLevels.Create)]
        public virtual async Task<CompanyJobEducationLevelDto> CreateAsync(CompanyJobEducationLevelCreateDto input)
        {

            var companyJobEducationLevel = await _companyJobEducationLevelManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.EducationLevelCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobEducationLevel, CompanyJobEducationLevelDto>(companyJobEducationLevel);
        }

        [Authorize(ResumePermissions.CompanyJobEducationLevels.Edit)]
        public virtual async Task<CompanyJobEducationLevelDto> UpdateAsync(Guid id, CompanyJobEducationLevelUpdateDto input)
        {

            var companyJobEducationLevel = await _companyJobEducationLevelManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.EducationLevelCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CompanyJobEducationLevel, CompanyJobEducationLevelDto>(companyJobEducationLevel);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobEducationLevelExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobEducationLevelRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.EducationLevelCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobEducationLevel>, List<CompanyJobEducationLevelExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobEducationLevels.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobEducationLevelExcelDownloadTokenCacheItem { Token = token },
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