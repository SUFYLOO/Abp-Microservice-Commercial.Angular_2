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
using Resume.CompanyJobDisabilityCategories;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobDisabilityCategories
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobDisabilityCategories.Default)]
    public class CompanyJobDisabilityCategoriesAppService : ApplicationService, ICompanyJobDisabilityCategoriesAppService
    {
        private readonly IDistributedCache<CompanyJobDisabilityCategoryExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobDisabilityCategoryRepository _companyJobDisabilityCategoryRepository;
        private readonly CompanyJobDisabilityCategoryManager _companyJobDisabilityCategoryManager;

        public CompanyJobDisabilityCategoriesAppService(ICompanyJobDisabilityCategoryRepository companyJobDisabilityCategoryRepository, CompanyJobDisabilityCategoryManager companyJobDisabilityCategoryManager, IDistributedCache<CompanyJobDisabilityCategoryExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobDisabilityCategoryRepository = companyJobDisabilityCategoryRepository;
            _companyJobDisabilityCategoryManager = companyJobDisabilityCategoryManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobDisabilityCategoryDto>> GetListAsync(GetCompanyJobDisabilityCategoriesInput input)
        {
            var totalCount = await _companyJobDisabilityCategoryRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.DisabilityCategoryCode, input.DisabilityLevelCode, input.DisabilityCertifiedDocumentsNeed, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobDisabilityCategoryRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.DisabilityCategoryCode, input.DisabilityLevelCode, input.DisabilityCertifiedDocumentsNeed, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobDisabilityCategoryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobDisabilityCategory>, List<CompanyJobDisabilityCategoryDto>>(items)
            };
        }

        public virtual async Task<CompanyJobDisabilityCategoryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobDisabilityCategory, CompanyJobDisabilityCategoryDto>(await _companyJobDisabilityCategoryRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobDisabilityCategories.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobDisabilityCategoryRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobDisabilityCategories.Create)]
        public virtual async Task<CompanyJobDisabilityCategoryDto> CreateAsync(CompanyJobDisabilityCategoryCreateDto input)
        {

            var companyJobDisabilityCategory = await _companyJobDisabilityCategoryManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.DisabilityCategoryCode, input.DisabilityLevelCode, input.DisabilityCertifiedDocumentsNeed, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobDisabilityCategory, CompanyJobDisabilityCategoryDto>(companyJobDisabilityCategory);
        }

        [Authorize(ResumePermissions.CompanyJobDisabilityCategories.Edit)]
        public virtual async Task<CompanyJobDisabilityCategoryDto> UpdateAsync(Guid id, CompanyJobDisabilityCategoryUpdateDto input)
        {

            var companyJobDisabilityCategory = await _companyJobDisabilityCategoryManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.DisabilityCategoryCode, input.DisabilityLevelCode, input.DisabilityCertifiedDocumentsNeed, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobDisabilityCategory, CompanyJobDisabilityCategoryDto>(companyJobDisabilityCategory);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobDisabilityCategoryExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobDisabilityCategoryRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.DisabilityCategoryCode, input.DisabilityLevelCode, input.DisabilityCertifiedDocumentsNeed, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobDisabilityCategory>, List<CompanyJobDisabilityCategoryExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobDisabilityCategories.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobDisabilityCategoryExcelDownloadTokenCacheItem { Token = token },
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