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
using Resume.CompanyJobLanguageConditions;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobLanguageConditions
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobLanguageConditions.Default)]
    public class CompanyJobLanguageConditionsAppService : ApplicationService, ICompanyJobLanguageConditionsAppService
    {
        private readonly IDistributedCache<CompanyJobLanguageConditionExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobLanguageConditionRepository _companyJobLanguageConditionRepository;
        private readonly CompanyJobLanguageConditionManager _companyJobLanguageConditionManager;

        public CompanyJobLanguageConditionsAppService(ICompanyJobLanguageConditionRepository companyJobLanguageConditionRepository, CompanyJobLanguageConditionManager companyJobLanguageConditionManager, IDistributedCache<CompanyJobLanguageConditionExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobLanguageConditionRepository = companyJobLanguageConditionRepository;
            _companyJobLanguageConditionManager = companyJobLanguageConditionManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobLanguageConditionDto>> GetListAsync(GetCompanyJobLanguageConditionsInput input)
        {
            var totalCount = await _companyJobLanguageConditionRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobLanguageConditionRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobLanguageConditionDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobLanguageCondition>, List<CompanyJobLanguageConditionDto>>(items)
            };
        }

        public virtual async Task<CompanyJobLanguageConditionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobLanguageCondition, CompanyJobLanguageConditionDto>(await _companyJobLanguageConditionRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobLanguageConditions.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobLanguageConditionRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobLanguageConditions.Create)]
        public virtual async Task<CompanyJobLanguageConditionDto> CreateAsync(CompanyJobLanguageConditionCreateDto input)
        {

            var companyJobLanguageCondition = await _companyJobLanguageConditionManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobLanguageCondition, CompanyJobLanguageConditionDto>(companyJobLanguageCondition);
        }

        [Authorize(ResumePermissions.CompanyJobLanguageConditions.Edit)]
        public virtual async Task<CompanyJobLanguageConditionDto> UpdateAsync(Guid id, CompanyJobLanguageConditionUpdateDto input)
        {

            var companyJobLanguageCondition = await _companyJobLanguageConditionManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobLanguageCondition, CompanyJobLanguageConditionDto>(companyJobLanguageCondition);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobLanguageConditionExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobLanguageConditionRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobLanguageCondition>, List<CompanyJobLanguageConditionExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobLanguageConditions.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobLanguageConditionExcelDownloadTokenCacheItem { Token = token },
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