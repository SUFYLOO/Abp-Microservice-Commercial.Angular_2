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
using Resume.ResumeEducationss;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeEducationss
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeEducationss.Default)]
    public class ResumeEducationssAppService : ApplicationService, IResumeEducationssAppService
    {
        private readonly IDistributedCache<ResumeEducationsExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeEducationsRepository _resumeEducationsRepository;
        private readonly ResumeEducationsManager _resumeEducationsManager;

        public ResumeEducationssAppService(IResumeEducationsRepository resumeEducationsRepository, ResumeEducationsManager resumeEducationsManager, IDistributedCache<ResumeEducationsExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeEducationsRepository = resumeEducationsRepository;
            _resumeEducationsManager = resumeEducationsManager;
        }

        public virtual async Task<PagedResultDto<ResumeEducationsDto>> GetListAsync(GetResumeEducationssInput input)
        {
            var totalCount = await _resumeEducationsRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.EducationLevelCode, input.SchoolCode, input.SchoolName, input.Night, input.Working, input.MajorDepartmentName, input.MajorDepartmentCategoryCode, input.MinorDepartmentName, input.MinorDepartmentCategoryCode, input.GraduationCode, input.Domestic, input.CountryCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeEducationsRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.EducationLevelCode, input.SchoolCode, input.SchoolName, input.Night, input.Working, input.MajorDepartmentName, input.MajorDepartmentCategoryCode, input.MinorDepartmentName, input.MinorDepartmentCategoryCode, input.GraduationCode, input.Domestic, input.CountryCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeEducationsDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeEducations>, List<ResumeEducationsDto>>(items)
            };
        }

        public virtual async Task<ResumeEducationsDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeEducations, ResumeEducationsDto>(await _resumeEducationsRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeEducationss.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeEducationsRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeEducationss.Create)]
        public virtual async Task<ResumeEducationsDto> CreateAsync(ResumeEducationsCreateDto input)
        {

            var resumeEducations = await _resumeEducationsManager.CreateAsync(
            input.ResumeMainId, input.EducationLevelCode, input.SchoolCode, input.SchoolName, input.Night, input.Working, input.MajorDepartmentName, input.MajorDepartmentCategoryCode, input.MinorDepartmentName, input.MinorDepartmentCategoryCode, input.GraduationCode, input.Domestic, input.CountryCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeEducations, ResumeEducationsDto>(resumeEducations);
        }

        [Authorize(ResumePermissions.ResumeEducationss.Edit)]
        public virtual async Task<ResumeEducationsDto> UpdateAsync(Guid id, ResumeEducationsUpdateDto input)
        {

            var resumeEducations = await _resumeEducationsManager.UpdateAsync(
            id,
            input.ResumeMainId, input.EducationLevelCode, input.SchoolCode, input.SchoolName, input.Night, input.Working, input.MajorDepartmentName, input.MajorDepartmentCategoryCode, input.MinorDepartmentName, input.MinorDepartmentCategoryCode, input.GraduationCode, input.Domestic, input.CountryCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeEducations, ResumeEducationsDto>(resumeEducations);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeEducationsExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeEducationsRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.EducationLevelCode, input.SchoolCode, input.SchoolName, input.Night, input.Working, input.MajorDepartmentName, input.MajorDepartmentCategoryCode, input.MinorDepartmentName, input.MinorDepartmentCategoryCode, input.GraduationCode, input.Domestic, input.CountryCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeEducations>, List<ResumeEducationsExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeEducationss.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeEducationsExcelDownloadTokenCacheItem { Token = token },
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