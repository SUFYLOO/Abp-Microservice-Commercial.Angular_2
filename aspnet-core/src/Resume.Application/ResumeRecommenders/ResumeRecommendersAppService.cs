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
using Resume.ResumeRecommenders;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeRecommenders
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeRecommenders.Default)]
    public class ResumeRecommendersAppService : ApplicationService, IResumeRecommendersAppService
    {
        private readonly IDistributedCache<ResumeRecommenderExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeRecommenderRepository _resumeRecommenderRepository;
        private readonly ResumeRecommenderManager _resumeRecommenderManager;

        public ResumeRecommendersAppService(IResumeRecommenderRepository resumeRecommenderRepository, ResumeRecommenderManager resumeRecommenderManager, IDistributedCache<ResumeRecommenderExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeRecommenderRepository = resumeRecommenderRepository;
            _resumeRecommenderManager = resumeRecommenderManager;
        }

        public virtual async Task<PagedResultDto<ResumeRecommenderDto>> GetListAsync(GetResumeRecommendersInput input)
        {
            var totalCount = await _resumeRecommenderRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.Name, input.CompanyName, input.JobName, input.MobilePhone, input.OfficePhone, input.Email, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeRecommenderRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.CompanyName, input.JobName, input.MobilePhone, input.OfficePhone, input.Email, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeRecommenderDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeRecommender>, List<ResumeRecommenderDto>>(items)
            };
        }

        public virtual async Task<ResumeRecommenderDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeRecommender, ResumeRecommenderDto>(await _resumeRecommenderRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeRecommenders.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeRecommenderRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeRecommenders.Create)]
        public virtual async Task<ResumeRecommenderDto> CreateAsync(ResumeRecommenderCreateDto input)
        {

            var resumeRecommender = await _resumeRecommenderManager.CreateAsync(
            input.ResumeMainId, input.Name, input.DateA, input.DateD, input.Sort, input.Status, input.CompanyName, input.JobName, input.MobilePhone, input.OfficePhone, input.Email, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeRecommender, ResumeRecommenderDto>(resumeRecommender);
        }

        [Authorize(ResumePermissions.ResumeRecommenders.Edit)]
        public virtual async Task<ResumeRecommenderDto> UpdateAsync(Guid id, ResumeRecommenderUpdateDto input)
        {

            var resumeRecommender = await _resumeRecommenderManager.UpdateAsync(
            id,
            input.ResumeMainId, input.Name, input.DateA, input.DateD, input.Sort, input.Status, input.CompanyName, input.JobName, input.MobilePhone, input.OfficePhone, input.Email, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeRecommender, ResumeRecommenderDto>(resumeRecommender);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeRecommenderExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeRecommenderRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.CompanyName, input.JobName, input.MobilePhone, input.OfficePhone, input.Email, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeRecommender>, List<ResumeRecommenderExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeRecommenders.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeRecommenderExcelDownloadTokenCacheItem { Token = token },
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