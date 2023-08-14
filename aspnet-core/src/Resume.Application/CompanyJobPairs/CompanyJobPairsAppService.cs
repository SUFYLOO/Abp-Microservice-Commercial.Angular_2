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
using Resume.CompanyJobPairs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyJobPairs
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyJobPairs.Default)]
    public class CompanyJobPairsAppService : ApplicationService, ICompanyJobPairsAppService
    {
        private readonly IDistributedCache<CompanyJobPairExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyJobPairRepository _companyJobPairRepository;
        private readonly CompanyJobPairManager _companyJobPairManager;

        public CompanyJobPairsAppService(ICompanyJobPairRepository companyJobPairRepository, CompanyJobPairManager companyJobPairManager, IDistributedCache<CompanyJobPairExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyJobPairRepository = companyJobPairRepository;
            _companyJobPairManager = companyJobPairManager;
        }

        public virtual async Task<PagedResultDto<CompanyJobPairDto>> GetListAsync(GetCompanyJobPairsInput input)
        {
            var totalCount = await _companyJobPairRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyJobPairRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyJobPairDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyJobPair>, List<CompanyJobPairDto>>(items)
            };
        }

        public virtual async Task<CompanyJobPairDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyJobPair, CompanyJobPairDto>(await _companyJobPairRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyJobPairs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyJobPairRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyJobPairs.Create)]
        public virtual async Task<CompanyJobPairDto> CreateAsync(CompanyJobPairCreateDto input)
        {

            var companyJobPair = await _companyJobPairManager.CreateAsync(
            input.CompanyMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobPair, CompanyJobPairDto>(companyJobPair);
        }

        [Authorize(ResumePermissions.CompanyJobPairs.Edit)]
        public virtual async Task<CompanyJobPairDto> UpdateAsync(Guid id, CompanyJobPairUpdateDto input)
        {

            var companyJobPair = await _companyJobPairManager.UpdateAsync(
            id,
            input.CompanyMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyJobPair, CompanyJobPairDto>(companyJobPair);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyJobPairExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyJobPairRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.Name, input.PairCondition, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyJobPair>, List<CompanyJobPairExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyJobPairs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyJobPairExcelDownloadTokenCacheItem { Token = token },
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