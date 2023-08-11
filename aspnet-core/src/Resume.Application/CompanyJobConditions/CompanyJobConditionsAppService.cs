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
using Resume.CompanyJobConditions;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobConditions
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobConditions.Default)]
    public class CompanyJobConditionsAppService : ApplicationService, ICompanyJobConditionsAppService
    {
        private readonly IDistributedCache<CompanyJobConditionExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobConditionRepository _companyJobConditionRepository;
        private readonly CompanyJobConditionManager _companyJobConditionManager;

        public CompanyJobConditionsAppService(ICompanyJobConditionRepository companyJobConditionRepository, CompanyJobConditionManager companyJobConditionManager, IDistributedCache<CompanyJobConditionExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobConditionRepository = companyJobConditionRepository;
            _companyJobConditionManager = companyJobConditionManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobConditionDto>> GetListAsync(GetCompanyJobConditionsInput input)
        {
            var totalCount = await _companyJobConditionRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkExperienceYearCode, input.EducationLevel, input.MajorDepartmentCategory, input.LanguageCategory, input.ComputerExpertise, input.ProfessionalLicense, input.DrvingLicense, input.EtcCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobConditionRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkExperienceYearCode, input.EducationLevel, input.MajorDepartmentCategory, input.LanguageCategory, input.ComputerExpertise, input.ProfessionalLicense, input.DrvingLicense, input.EtcCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobConditionDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobCondition>, List<CompanyJobConditionDto>>(items)
            };
        }

        public virtual async Task<CompanyJobConditionDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobCondition, CompanyJobConditionDto>(await _companyJobConditionRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobConditions.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobConditionRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobConditions.Create)]
        public virtual async Task<CompanyJobConditionDto> CreateAsync(CompanyJobConditionCreateDto input)
        {

            var companyJobCondition = await _companyJobConditionManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.WorkExperienceYearCode, input.EducationLevel, input.MajorDepartmentCategory, input.LanguageCategory, input.ComputerExpertise, input.ProfessionalLicense, input.DrvingLicense, input.EtcCondition, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobCondition, CompanyJobConditionDto>(companyJobCondition);
        }

        [Authorize(ResumePermissions.CompanyJobConditions.Edit)]
        public virtual async Task<CompanyJobConditionDto> UpdateAsync(Guid id, CompanyJobConditionUpdateDto input)
        {

            var companyJobCondition = await _companyJobConditionManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.WorkExperienceYearCode, input.EducationLevel, input.MajorDepartmentCategory, input.LanguageCategory, input.ComputerExpertise, input.ProfessionalLicense, input.DrvingLicense, input.EtcCondition, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CompanyJobCondition, CompanyJobConditionDto>(companyJobCondition);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobConditionExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobConditionRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.WorkExperienceYearCode, input.EducationLevel, input.MajorDepartmentCategory, input.LanguageCategory, input.ComputerExpertise, input.ProfessionalLicense, input.DrvingLicense, input.EtcCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobCondition>, List<CompanyJobConditionExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobConditions.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobConditionExcelDownloadTokenCacheItem { Token = token },
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