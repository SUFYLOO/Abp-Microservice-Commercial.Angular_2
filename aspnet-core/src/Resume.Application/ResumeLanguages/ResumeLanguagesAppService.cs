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
using Resume.ResumeLanguages;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeLanguages
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeLanguages.Default)]
    public class ResumeLanguagesAppService : ApplicationService, IResumeLanguagesAppService
    {
        private readonly IDistributedCache<ResumeLanguageExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeLanguageRepository _resumeLanguageRepository;
        private readonly ResumeLanguageManager _resumeLanguageManager;

        public ResumeLanguagesAppService(IResumeLanguageRepository resumeLanguageRepository, ResumeLanguageManager resumeLanguageManager, IDistributedCache<ResumeLanguageExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeLanguageRepository = resumeLanguageRepository;
            _resumeLanguageManager = resumeLanguageManager;
        }

        public virtual async Task<PagedResultDto<ResumeLanguageDto>> GetListAsync(GetResumeLanguagesInput input)
        {
            var totalCount = await _resumeLanguageRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeLanguageRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeLanguageDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeLanguage>, List<ResumeLanguageDto>>(items)
            };
        }

        public virtual async Task<ResumeLanguageDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeLanguage, ResumeLanguageDto>(await _resumeLanguageRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeLanguages.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeLanguageRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeLanguages.Create)]
        public virtual async Task<ResumeLanguageDto> CreateAsync(ResumeLanguageCreateDto input)
        {

            var resumeLanguage = await _resumeLanguageManager.CreateAsync(
            input.ResumeMainId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeLanguage, ResumeLanguageDto>(resumeLanguage);
        }

        [Authorize(ResumePermissions.ResumeLanguages.Edit)]
        public virtual async Task<ResumeLanguageDto> UpdateAsync(Guid id, ResumeLanguageUpdateDto input)
        {

            var resumeLanguage = await _resumeLanguageManager.UpdateAsync(
            id,
            input.ResumeMainId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.DateA, input.DateD, input.Sort, input.Status, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeLanguage, ResumeLanguageDto>(resumeLanguage);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeLanguageExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeLanguageRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.LanguageCategoryCode, input.LevelSayCode, input.LevelListenCode, input.LevelReadCode, input.LevelWriteCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeLanguage>, List<ResumeLanguageExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeLanguages.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeLanguageExcelDownloadTokenCacheItem { Token = token },
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