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
using Resume.CompanyJobOrganizationUnits;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobOrganizationUnits
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobOrganizationUnits.Default)]
    public class CompanyJobOrganizationUnitsAppService : ApplicationService, ICompanyJobOrganizationUnitsAppService
    {
        private readonly IDistributedCache<CompanyJobOrganizationUnitExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobOrganizationUnitRepository _companyJobOrganizationUnitRepository;
        private readonly CompanyJobOrganizationUnitManager _companyJobOrganizationUnitManager;

        public CompanyJobOrganizationUnitsAppService(ICompanyJobOrganizationUnitRepository companyJobOrganizationUnitRepository, CompanyJobOrganizationUnitManager companyJobOrganizationUnitManager, IDistributedCache<CompanyJobOrganizationUnitExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobOrganizationUnitRepository = companyJobOrganizationUnitRepository;
            _companyJobOrganizationUnitManager = companyJobOrganizationUnitManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobOrganizationUnitDto>> GetListAsync(GetCompanyJobOrganizationUnitsInput input)
        {
            var totalCount = await _companyJobOrganizationUnitRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OrganizationUnitId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobOrganizationUnitRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OrganizationUnitId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobOrganizationUnitDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobOrganizationUnit>, List<CompanyJobOrganizationUnitDto>>(items)
            };
        }

        public virtual async Task<CompanyJobOrganizationUnitDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobOrganizationUnit, CompanyJobOrganizationUnitDto>(await _companyJobOrganizationUnitRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobOrganizationUnits.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobOrganizationUnitRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobOrganizationUnits.Create)]
        public virtual async Task<CompanyJobOrganizationUnitDto> CreateAsync(CompanyJobOrganizationUnitCreateDto input)
        {

            var companyJobOrganizationUnit = await _companyJobOrganizationUnitManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.OrganizationUnitId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobOrganizationUnit, CompanyJobOrganizationUnitDto>(companyJobOrganizationUnit);
        }

        [Authorize(ResumePermissions.CompanyJobOrganizationUnits.Edit)]
        public virtual async Task<CompanyJobOrganizationUnitDto> UpdateAsync(Guid id, CompanyJobOrganizationUnitUpdateDto input)
        {

            var companyJobOrganizationUnit = await _companyJobOrganizationUnitManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.OrganizationUnitId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobOrganizationUnit, CompanyJobOrganizationUnitDto>(companyJobOrganizationUnit);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobOrganizationUnitExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobOrganizationUnitRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OrganizationUnitId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobOrganizationUnit>, List<CompanyJobOrganizationUnitExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobOrganizationUnits.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobOrganizationUnitExcelDownloadTokenCacheItem { Token = token },
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