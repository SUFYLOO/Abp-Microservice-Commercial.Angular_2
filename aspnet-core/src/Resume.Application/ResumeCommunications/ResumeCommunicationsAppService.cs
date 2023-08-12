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
using Resume.ResumeCommunications;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeCommunications
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeCommunications.Default)]
    public class ResumeCommunicationsAppService : ApplicationService, IResumeCommunicationsAppService
    {
        private readonly IDistributedCache<ResumeCommunicationExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeCommunicationRepository _resumeCommunicationRepository;
        private readonly ResumeCommunicationManager _resumeCommunicationManager;

        public ResumeCommunicationsAppService(IResumeCommunicationRepository resumeCommunicationRepository, ResumeCommunicationManager resumeCommunicationManager, IDistributedCache<ResumeCommunicationExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeCommunicationRepository = resumeCommunicationRepository;
            _resumeCommunicationManager = resumeCommunicationManager;
        }

        public virtual async Task<PagedResultDto<ResumeCommunicationDto>> GetListAsync(GetResumeCommunicationsInput input)
        {
            var totalCount = await _resumeCommunicationRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.CommunicationCategoryCode, input.CommunicationValue, input.Main, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeCommunicationRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.CommunicationCategoryCode, input.CommunicationValue, input.Main, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeCommunicationDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeCommunication>, List<ResumeCommunicationDto>>(items)
            };
        }

        public virtual async Task<ResumeCommunicationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeCommunication, ResumeCommunicationDto>(await _resumeCommunicationRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeCommunications.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeCommunicationRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeCommunications.Create)]
        public virtual async Task<ResumeCommunicationDto> CreateAsync(ResumeCommunicationCreateDto input)
        {

            var resumeCommunication = await _resumeCommunicationManager.CreateAsync(
            input.ResumeMainId, input.CommunicationCategoryCode, input.CommunicationValue, input.Main, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeCommunication, ResumeCommunicationDto>(resumeCommunication);
        }

        [Authorize(ResumePermissions.ResumeCommunications.Edit)]
        public virtual async Task<ResumeCommunicationDto> UpdateAsync(Guid id, ResumeCommunicationUpdateDto input)
        {

            var resumeCommunication = await _resumeCommunicationManager.UpdateAsync(
            id,
            input.ResumeMainId, input.CommunicationCategoryCode, input.CommunicationValue, input.Main, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeCommunication, ResumeCommunicationDto>(resumeCommunication);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeCommunicationExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeCommunicationRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.CommunicationCategoryCode, input.CommunicationValue, input.Main, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeCommunication>, List<ResumeCommunicationExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeCommunications.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeCommunicationExcelDownloadTokenCacheItem { Token = token },
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