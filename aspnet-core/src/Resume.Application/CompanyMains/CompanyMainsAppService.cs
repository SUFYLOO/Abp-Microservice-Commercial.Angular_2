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
using Resume.CompanyMains;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyMains
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyMains.Default)]
    public class CompanyMainsAppService : ApplicationService, ICompanyMainsAppService
    {
        private readonly IDistributedCache<CompanyMainExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyMainRepository _companyMainRepository;
        private readonly CompanyMainManager _companyMainManager;

        public CompanyMainsAppService(ICompanyMainRepository companyMainRepository, CompanyMainManager companyMainManager, IDistributedCache<CompanyMainExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyMainRepository = companyMainRepository;
            _companyMainManager = companyMainManager;
        }

        public virtual async Task<PagedResultDto<CompanyMainDto>> GetListAsync(GetCompanyMainsInput input)
        {
            var totalCount = await _companyMainRepository.GetCountAsync(input.FilterText, input.Name, input.Compilation, input.OfficePhone, input.FaxPhone, input.Address, input.Principal, input.AllowSearch, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.Note, input.SortMin, input.SortMax, input.Status, input.IndustryCategory, input.CompanyUrl, input.CapitalAmountMin, input.CapitalAmountMax, input.HideCapitalAmount, input.CompanyScaleCode, input.HidePrincipal, input.CompanyUserId, input.CompanyProfile, input.BusinessPhilosophy, input.OperatingItems, input.WelfareSystem, input.Matching, input.ContractPass);
            var items = await _companyMainRepository.GetListAsync(input.FilterText, input.Name, input.Compilation, input.OfficePhone, input.FaxPhone, input.Address, input.Principal, input.AllowSearch, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.Note, input.SortMin, input.SortMax, input.Status, input.IndustryCategory, input.CompanyUrl, input.CapitalAmountMin, input.CapitalAmountMax, input.HideCapitalAmount, input.CompanyScaleCode, input.HidePrincipal, input.CompanyUserId, input.CompanyProfile, input.BusinessPhilosophy, input.OperatingItems, input.WelfareSystem, input.Matching, input.ContractPass, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyMainDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyMain>, List<CompanyMainDto>>(items)
            };
        }

        public virtual async Task<CompanyMainDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyMain, CompanyMainDto>(await _companyMainRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyMains.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyMainRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyMains.Create)]
        public virtual async Task<CompanyMainDto> CreateAsync(CompanyMainCreateDto input)
        {

            var companyMain = await _companyMainManager.CreateAsync(
            input.Name, input.AllowSearch, input.DateA, input.DateD, input.Sort, input.Status, input.IndustryCategory, input.CompanyUrl, input.CapitalAmount, input.HideCapitalAmount, input.CompanyScaleCode, input.HidePrincipal, input.CompanyProfile, input.BusinessPhilosophy, input.OperatingItems, input.WelfareSystem, input.Matching, input.ContractPass, input.Compilation, input.OfficePhone, input.FaxPhone, input.Address, input.Principal, input.ExtendedInformation, input.Note, input.CompanyUserId
            );

            return ObjectMapper.Map<CompanyMain, CompanyMainDto>(companyMain);
        }

        [Authorize(ResumePermissions.CompanyMains.Edit)]
        public virtual async Task<CompanyMainDto> UpdateAsync(Guid id, CompanyMainUpdateDto input)
        {

            var companyMain = await _companyMainManager.UpdateAsync(
            id,
            input.Name, input.AllowSearch, input.DateA, input.DateD, input.Sort, input.Status, input.IndustryCategory, input.CompanyUrl, input.CapitalAmount, input.HideCapitalAmount, input.CompanyScaleCode, input.HidePrincipal, input.CompanyProfile, input.BusinessPhilosophy, input.OperatingItems, input.WelfareSystem, input.Matching, input.ContractPass, input.Compilation, input.OfficePhone, input.FaxPhone, input.Address, input.Principal, input.ExtendedInformation, input.Note, input.CompanyUserId
            );

            return ObjectMapper.Map<CompanyMain, CompanyMainDto>(companyMain);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyMainExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyMainRepository.GetListAsync(input.FilterText, input.Name, input.Compilation, input.OfficePhone, input.FaxPhone, input.Address, input.Principal, input.AllowSearch, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.Note, input.SortMin, input.SortMax, input.Status, input.IndustryCategory, input.CompanyUrl, input.CapitalAmountMin, input.CapitalAmountMax, input.HideCapitalAmount, input.CompanyScaleCode, input.HidePrincipal, input.CompanyUserId, input.CompanyProfile, input.BusinessPhilosophy, input.OperatingItems, input.WelfareSystem, input.Matching, input.ContractPass);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyMain>, List<CompanyMainExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyMains.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyMainExcelDownloadTokenCacheItem { Token = token },
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