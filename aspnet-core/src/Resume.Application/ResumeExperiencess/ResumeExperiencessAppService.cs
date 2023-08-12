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
using Resume.ResumeExperiencess;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeExperiencess
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeExperiencess.Default)]
    public class ResumeExperiencessAppService : ApplicationService, IResumeExperiencessAppService
    {
        private readonly IDistributedCache<ResumeExperiencesExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeExperiencesRepository _resumeExperiencesRepository;
        private readonly ResumeExperiencesManager _resumeExperiencesManager;

        public ResumeExperiencessAppService(IResumeExperiencesRepository resumeExperiencesRepository, ResumeExperiencesManager resumeExperiencesManager, IDistributedCache<ResumeExperiencesExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeExperiencesRepository = resumeExperiencesRepository;
            _resumeExperiencesManager = resumeExperiencesManager;
        }

        public virtual async Task<PagedResultDto<ResumeExperiencesDto>> GetListAsync(GetResumeExperiencessInput input)
        {
            var totalCount = await _resumeExperiencesRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.Name, input.WorkNatureCode, input.HideCompanyName, input.IndustryCategoryCode, input.JobName, input.JobType, input.Working, input.WorkPlaceCode, input.HideWorkSalary, input.SalaryPayTypeCode, input.CurrencyTypeCode, input.Salary1Min, input.Salary1Max, input.Salary2Min, input.Salary2Max, input.CompanyScaleCode, input.CompanyManagementNumberCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeExperiencesRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.WorkNatureCode, input.HideCompanyName, input.IndustryCategoryCode, input.JobName, input.JobType, input.Working, input.WorkPlaceCode, input.HideWorkSalary, input.SalaryPayTypeCode, input.CurrencyTypeCode, input.Salary1Min, input.Salary1Max, input.Salary2Min, input.Salary2Max, input.CompanyScaleCode, input.CompanyManagementNumberCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeExperiencesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeExperiences>, List<ResumeExperiencesDto>>(items)
            };
        }

        public virtual async Task<ResumeExperiencesDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeExperiences, ResumeExperiencesDto>(await _resumeExperiencesRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeExperiencess.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeExperiencesRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeExperiencess.Create)]
        public virtual async Task<ResumeExperiencesDto> CreateAsync(ResumeExperiencesCreateDto input)
        {

            var resumeExperiences = await _resumeExperiencesManager.CreateAsync(
            input.ResumeMainId, input.Name, input.WorkNatureCode, input.HideCompanyName, input.IndustryCategoryCode, input.JobName, input.JobType, input.Working, input.WorkPlaceCode, input.HideWorkSalary, input.SalaryPayTypeCode, input.CurrencyTypeCode, input.Salary1, input.Salary2, input.CompanyScaleCode, input.CompanyManagementNumberCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeExperiences, ResumeExperiencesDto>(resumeExperiences);
        }

        [Authorize(ResumePermissions.ResumeExperiencess.Edit)]
        public virtual async Task<ResumeExperiencesDto> UpdateAsync(Guid id, ResumeExperiencesUpdateDto input)
        {

            var resumeExperiences = await _resumeExperiencesManager.UpdateAsync(
            id,
            input.ResumeMainId, input.Name, input.WorkNatureCode, input.HideCompanyName, input.IndustryCategoryCode, input.JobName, input.JobType, input.Working, input.WorkPlaceCode, input.HideWorkSalary, input.SalaryPayTypeCode, input.CurrencyTypeCode, input.Salary1, input.Salary2, input.CompanyScaleCode, input.CompanyManagementNumberCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeExperiences, ResumeExperiencesDto>(resumeExperiences);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeExperiencesExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeExperiencesRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.WorkNatureCode, input.HideCompanyName, input.IndustryCategoryCode, input.JobName, input.JobType, input.Working, input.WorkPlaceCode, input.HideWorkSalary, input.SalaryPayTypeCode, input.CurrencyTypeCode, input.Salary1Min, input.Salary1Max, input.Salary2Min, input.Salary2Max, input.CompanyScaleCode, input.CompanyManagementNumberCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeExperiences>, List<ResumeExperiencesExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeExperiencess.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeExperiencesExcelDownloadTokenCacheItem { Token = token },
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