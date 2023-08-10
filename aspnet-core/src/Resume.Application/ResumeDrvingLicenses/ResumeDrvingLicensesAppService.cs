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
using Resume.ResumeDrvingLicenses;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeDrvingLicenses
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeDrvingLicenses.Default)]
    public class ResumeDrvingLicensesAppService : ApplicationService, IResumeDrvingLicensesAppService
    {
        private readonly IDistributedCache<ResumeDrvingLicenseExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeDrvingLicenseRepository _resumeDrvingLicenseRepository;
        private readonly ResumeDrvingLicenseManager _resumeDrvingLicenseManager;

        public ResumeDrvingLicensesAppService(IResumeDrvingLicenseRepository resumeDrvingLicenseRepository, ResumeDrvingLicenseManager resumeDrvingLicenseManager, IDistributedCache<ResumeDrvingLicenseExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeDrvingLicenseRepository = resumeDrvingLicenseRepository;
            _resumeDrvingLicenseManager = resumeDrvingLicenseManager;
        }

        public virtual async Task<PagedResultDto<ResumeDrvingLicenseDto>> GetListAsync(GetResumeDrvingLicensesInput input)
        {
            var totalCount = await _resumeDrvingLicenseRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeDrvingLicenseRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeDrvingLicenseDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicenseDto>>(items)
            };
        }

        public virtual async Task<ResumeDrvingLicenseDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeDrvingLicense, ResumeDrvingLicenseDto>(await _resumeDrvingLicenseRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeDrvingLicenses.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeDrvingLicenseRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeDrvingLicenses.Create)]
        public virtual async Task<ResumeDrvingLicenseDto> CreateAsync(ResumeDrvingLicenseCreateDto input)
        {

            var resumeDrvingLicense = await _resumeDrvingLicenseManager.CreateAsync(
            input.ResumeMainId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeDrvingLicense, ResumeDrvingLicenseDto>(resumeDrvingLicense);
        }

        [Authorize(ResumePermissions.ResumeDrvingLicenses.Edit)]
        public virtual async Task<ResumeDrvingLicenseDto> UpdateAsync(Guid id, ResumeDrvingLicenseUpdateDto input)
        {

            var resumeDrvingLicense = await _resumeDrvingLicenseManager.UpdateAsync(
            id,
            input.ResumeMainId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeDrvingLicense, ResumeDrvingLicenseDto>(resumeDrvingLicense);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeDrvingLicenseExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeDrvingLicenseRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.DrvingLicenseCode, input.HaveDrvingLicense, input.HaveCar, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeDrvingLicense>, List<ResumeDrvingLicenseExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeDrvingLicenses.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeDrvingLicenseExcelDownloadTokenCacheItem { Token = token },
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