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
using Resume.CompanyJobContents;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobContents
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobContents.Default)]
    public class CompanyJobContentsAppService : ApplicationService, ICompanyJobContentsAppService
    {
        private readonly IDistributedCache<CompanyJobContentExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobContentRepository _companyJobContentRepository;
        private readonly CompanyJobContentManager _companyJobContentManager;

        public CompanyJobContentsAppService(ICompanyJobContentRepository companyJobContentRepository, CompanyJobContentManager companyJobContentManager, IDistributedCache<CompanyJobContentExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobContentRepository = companyJobContentRepository;
            _companyJobContentManager = companyJobContentManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobContentDto>> GetListAsync(GetCompanyJobContentsInput input)
        {
            var totalCount = await _companyJobContentRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.Name, input.JobTypeCode, input.PeopleRequiredNumberMin, input.PeopleRequiredNumberMax, input.PeopleRequiredNumberUnlimited, input.JobType, input.JobTypeContent, input.SalaryPayTypeCode, input.SalaryMinMin, input.SalaryMinMax, input.SalaryMaxMin, input.SalaryMaxMax, input.SalaryUp, input.WorkPlace, input.WorkHours, input.WorkHour, input.WorkShift, input.WorkRemoteAllow, input.WorkRemoteTypeCode, input.WorkRemote, input.WorkDifferentPlaces, input.HolidaySystemCode, input.WorkDayCode, input.WorkIdentityCode, input.DisabilityCategory, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobContentRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.Name, input.JobTypeCode, input.PeopleRequiredNumberMin, input.PeopleRequiredNumberMax, input.PeopleRequiredNumberUnlimited, input.JobType, input.JobTypeContent, input.SalaryPayTypeCode, input.SalaryMinMin, input.SalaryMinMax, input.SalaryMaxMin, input.SalaryMaxMax, input.SalaryUp, input.WorkPlace, input.WorkHours, input.WorkHour, input.WorkShift, input.WorkRemoteAllow, input.WorkRemoteTypeCode, input.WorkRemote, input.WorkDifferentPlaces, input.HolidaySystemCode, input.WorkDayCode, input.WorkIdentityCode, input.DisabilityCategory, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobContentDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobContent>, List<CompanyJobContentDto>>(items)
            };
        }

        public virtual async Task<CompanyJobContentDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobContent, CompanyJobContentDto>(await _companyJobContentRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobContents.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobContentRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobContents.Create)]
        public virtual async Task<CompanyJobContentDto> CreateAsync(CompanyJobContentCreateDto input)
        {

            var companyJobContent = await _companyJobContentManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.Name, input.JobTypeCode, input.PeopleRequiredNumber, input.PeopleRequiredNumberUnlimited, input.JobType, input.JobTypeContent, input.SalaryPayTypeCode, input.SalaryMin, input.SalaryMax, input.SalaryUp, input.WorkPlace, input.WorkHours, input.WorkHour, input.WorkShift, input.WorkRemoteAllow, input.WorkRemoteTypeCode, input.WorkRemote, input.WorkDifferentPlaces, input.HolidaySystemCode, input.WorkDayCode, input.WorkIdentityCode, input.DisabilityCategory, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobContent, CompanyJobContentDto>(companyJobContent);
        }

        [Authorize(ResumePermissions.CompanyJobContents.Edit)]
        public virtual async Task<CompanyJobContentDto> UpdateAsync(Guid id, CompanyJobContentUpdateDto input)
        {

            var companyJobContent = await _companyJobContentManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.Name, input.JobTypeCode, input.PeopleRequiredNumber, input.PeopleRequiredNumberUnlimited, input.JobType, input.JobTypeContent, input.SalaryPayTypeCode, input.SalaryMin, input.SalaryMax, input.SalaryUp, input.WorkPlace, input.WorkHours, input.WorkHour, input.WorkShift, input.WorkRemoteAllow, input.WorkRemoteTypeCode, input.WorkRemote, input.WorkDifferentPlaces, input.HolidaySystemCode, input.WorkDayCode, input.WorkIdentityCode, input.DisabilityCategory, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CompanyJobContent, CompanyJobContentDto>(companyJobContent);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobContentExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobContentRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.Name, input.JobTypeCode, input.PeopleRequiredNumberMin, input.PeopleRequiredNumberMax, input.PeopleRequiredNumberUnlimited, input.JobType, input.JobTypeContent, input.SalaryPayTypeCode, input.SalaryMinMin, input.SalaryMinMax, input.SalaryMaxMin, input.SalaryMaxMax, input.SalaryUp, input.WorkPlace, input.WorkHours, input.WorkHour, input.WorkShift, input.WorkRemoteAllow, input.WorkRemoteTypeCode, input.WorkRemote, input.WorkDifferentPlaces, input.HolidaySystemCode, input.WorkDayCode, input.WorkIdentityCode, input.DisabilityCategory, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobContent>, List<CompanyJobContentExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobContents.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobContentExcelDownloadTokenCacheItem { Token = token },
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