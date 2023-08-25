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
using Resume.CompanyUserMainFavs;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyUserMainFavs
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyUserMainFavs.Default)]
    public class CompanyUserMainFavsAppService : ApplicationService, ICompanyUserMainFavsAppService
    {
        private readonly IDistributedCache<CompanyUserMainFavExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyUserMainFavRepository _companyUserMainFavRepository;
        private readonly CompanyUserMainFavManager _companyUserMainFavManager;

        public CompanyUserMainFavsAppService(ICompanyUserMainFavRepository companyUserMainFavRepository, CompanyUserMainFavManager companyUserMainFavManager, IDistributedCache<CompanyUserMainFavExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyUserMainFavRepository = companyUserMainFavRepository;
            _companyUserMainFavManager = companyUserMainFavManager;
        }

        public virtual async Task<PagedResultDto<CompanyUserMainFavDto>> GetListAsync(GetCompanyUserMainFavsInput input)
        {
            var totalCount = await _companyUserMainFavRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.UserMainId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyUserMainFavRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.UserMainId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyUserMainFavDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyUserMainFav>, List<CompanyUserMainFavDto>>(items)
            };
        }

        public virtual async Task<CompanyUserMainFavDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyUserMainFav, CompanyUserMainFavDto>(await _companyUserMainFavRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyUserMainFavs.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyUserMainFavRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyUserMainFavs.Create)]
        public virtual async Task<CompanyUserMainFavDto> CreateAsync(CompanyUserMainFavCreateDto input)
        {

            var companyUserMainFav = await _companyUserMainFavManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.UserMainId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyUserMainFav, CompanyUserMainFavDto>(companyUserMainFav);
        }

        [Authorize(ResumePermissions.CompanyUserMainFavs.Edit)]
        public virtual async Task<CompanyUserMainFavDto> UpdateAsync(Guid id, CompanyUserMainFavUpdateDto input)
        {

            var companyUserMainFav = await _companyUserMainFavManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.UserMainId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyUserMainFav, CompanyUserMainFavDto>(companyUserMainFav);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyUserMainFavExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyUserMainFavRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.UserMainId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyUserMainFav>, List<CompanyUserMainFavExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyUserMainFavs.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyUserMainFavExcelDownloadTokenCacheItem { Token = token },
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