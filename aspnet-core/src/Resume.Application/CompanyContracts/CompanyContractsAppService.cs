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
using Resume.CompanyContracts;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyContracts
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyContracts.Default)]
    public class CompanyContractsAppService : ApplicationService, ICompanyContractsAppService
    {
        private readonly IDistributedCache<CompanyContractExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyContractRepository _companyContractRepository;
        private readonly CompanyContractManager _companyContractManager;

        public CompanyContractsAppService(ICompanyContractRepository companyContractRepository, CompanyContractManager companyContractManager, IDistributedCache<CompanyContractExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyContractRepository = companyContractRepository;
            _companyContractManager = companyContractManager;
        }

        public virtual async Task<PagedResultDto<CompanyContractDto>> GetListAsync(GetCompanyContractsInput input)
        {
            var totalCount = await _companyContractRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.PlanCode, input.PointsTotalMin, input.PointsTotalMax, input.PointsPayMin, input.PointsPayMax, input.PointsGiftMin, input.PointsGiftMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyContractRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.PlanCode, input.PointsTotalMin, input.PointsTotalMax, input.PointsPayMin, input.PointsPayMax, input.PointsGiftMin, input.PointsGiftMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyContractDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyContract>, List<CompanyContractDto>>(items)
            };
        }

        public virtual async Task<CompanyContractDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyContract, CompanyContractDto>(await _companyContractRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyContracts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyContractRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyContracts.Create)]
        public virtual async Task<CompanyContractDto> CreateAsync(CompanyContractCreateDto input)
        {

            var companyContract = await _companyContractManager.CreateAsync(
            input.CompanyMainId, input.PlanCode, input.PointsTotal, input.PointsPay, input.PointsGift, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyContract, CompanyContractDto>(companyContract);
        }

        [Authorize(ResumePermissions.CompanyContracts.Edit)]
        public virtual async Task<CompanyContractDto> UpdateAsync(Guid id, CompanyContractUpdateDto input)
        {

            var companyContract = await _companyContractManager.UpdateAsync(
            id,
            input.CompanyMainId, input.PlanCode, input.PointsTotal, input.PointsPay, input.PointsGift, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CompanyContract, CompanyContractDto>(companyContract);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyContractExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyContractRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.PlanCode, input.PointsTotalMin, input.PointsTotalMax, input.PointsPayMin, input.PointsPayMax, input.PointsGiftMin, input.PointsGiftMax, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyContract>, List<CompanyContractExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyContracts.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyContractExcelDownloadTokenCacheItem { Token = token },
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