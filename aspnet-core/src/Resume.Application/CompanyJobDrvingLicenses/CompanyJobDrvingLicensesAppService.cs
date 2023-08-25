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
using Resume.CompanyJobDrvingLicenses;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobDrvingLicenses
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobDrvingLicenses.Default)]
    public class CompanyJobDrvingLicensesAppService : ApplicationService, ICompanyJobDrvingLicensesAppService
    {
        private readonly IDistributedCache<CompanyJobDrvingLicenseExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobDrvingLicenseRepository _companyJobDrvingLicenseRepository;
        private readonly CompanyJobDrvingLicenseManager _companyJobDrvingLicenseManager;

        public CompanyJobDrvingLicensesAppService(ICompanyJobDrvingLicenseRepository companyJobDrvingLicenseRepository, CompanyJobDrvingLicenseManager companyJobDrvingLicenseManager, IDistributedCache<CompanyJobDrvingLicenseExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobDrvingLicenseRepository = companyJobDrvingLicenseRepository;
            _companyJobDrvingLicenseManager = companyJobDrvingLicenseManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobDrvingLicenseDto>> GetListAsync(GetCompanyJobDrvingLicensesInput input)
        {
            var totalCount = await _companyJobDrvingLicenseRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobDrvingLicenseRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobDrvingLicenseDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobDrvingLicense>, List<CompanyJobDrvingLicenseDto>>(items)
            };
        }

        public virtual async Task<CompanyJobDrvingLicenseDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobDrvingLicense, CompanyJobDrvingLicenseDto>(await _companyJobDrvingLicenseRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobDrvingLicenses.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobDrvingLicenseRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobDrvingLicenses.Create)]
        public virtual async Task<CompanyJobDrvingLicenseDto> CreateAsync(CompanyJobDrvingLicenseCreateDto input)
        {

            var companyJobDrvingLicense = await _companyJobDrvingLicenseManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobDrvingLicense, CompanyJobDrvingLicenseDto>(companyJobDrvingLicense);
        }

        [Authorize(ResumePermissions.CompanyJobDrvingLicenses.Edit)]
        public virtual async Task<CompanyJobDrvingLicenseDto> UpdateAsync(Guid id, CompanyJobDrvingLicenseUpdateDto input)
        {

            var companyJobDrvingLicense = await _companyJobDrvingLicenseManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobDrvingLicense, CompanyJobDrvingLicenseDto>(companyJobDrvingLicense);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobDrvingLicenseExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobDrvingLicenseRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobDrvingLicense>, List<CompanyJobDrvingLicenseExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobDrvingLicenses.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobDrvingLicenseExcelDownloadTokenCacheItem { Token = token },
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