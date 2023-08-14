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
using Resume.CompanyPointss;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyPointss
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyPointss.Default)]
    public class CompanyPointssAppService : ApplicationService, ICompanyPointssAppService
    {
        private readonly IDistributedCache<CompanyPointsExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyPointsRepository _companyPointsRepository;
        private readonly CompanyPointsManager _companyPointsManager;

        public CompanyPointssAppService(ICompanyPointsRepository companyPointsRepository, CompanyPointsManager companyPointsManager, IDistributedCache<CompanyPointsExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyPointsRepository = companyPointsRepository;
            _companyPointsManager = companyPointsManager;
        }

        public virtual async Task<PagedResultDto<CompanyPointsDto>> GetListAsync(GetCompanyPointssInput input)
        {
            var totalCount = await _companyPointsRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyPointsTypeCode, input.PointsMin, input.PointsMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyPointsRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyPointsTypeCode, input.PointsMin, input.PointsMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyPointsDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyPoints>, List<CompanyPointsDto>>(items)
            };
        }

        public virtual async Task<CompanyPointsDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyPoints, CompanyPointsDto>(await _companyPointsRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyPointss.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyPointsRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyPointss.Create)]
        public virtual async Task<CompanyPointsDto> CreateAsync(CompanyPointsCreateDto input)
        {

            var companyPoints = await _companyPointsManager.CreateAsync(
            input.CompanyMainId, input.CompanyPointsTypeCode, input.Points, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyPoints, CompanyPointsDto>(companyPoints);
        }

        [Authorize(ResumePermissions.CompanyPointss.Edit)]
        public virtual async Task<CompanyPointsDto> UpdateAsync(Guid id, CompanyPointsUpdateDto input)
        {

            var companyPoints = await _companyPointsManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyPointsTypeCode, input.Points, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyPoints, CompanyPointsDto>(companyPoints);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyPointsExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyPointsRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyPointsTypeCode, input.PointsMin, input.PointsMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyPoints>, List<CompanyPointsExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyPointss.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyPointsExcelDownloadTokenCacheItem { Token = token },
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