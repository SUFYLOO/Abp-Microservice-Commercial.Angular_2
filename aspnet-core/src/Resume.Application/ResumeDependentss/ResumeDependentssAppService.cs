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
using Resume.ResumeDependentss;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeDependentss
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeDependentss.Default)]
    public class ResumeDependentssAppService : ApplicationService, IResumeDependentssAppService
    {
        private readonly IDistributedCache<ResumeDependentsExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeDependentsRepository _resumeDependentsRepository;
        private readonly ResumeDependentsManager _resumeDependentsManager;

        public ResumeDependentssAppService(IResumeDependentsRepository resumeDependentsRepository, ResumeDependentsManager resumeDependentsManager, IDistributedCache<ResumeDependentsExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeDependentsRepository = resumeDependentsRepository;
            _resumeDependentsManager = resumeDependentsManager;
        }

        public virtual async Task<PagedResultDto<ResumeDependentsDto>> GetListAsync(GetResumeDependentssInput input)
        {
            var totalCount = await _resumeDependentsRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.Name, input.IdentityNo, input.KinshipCode, input.BirthDateMin, input.BirthDateMax, input.Address, input.MobilePhone, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeDependentsRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.IdentityNo, input.KinshipCode, input.BirthDateMin, input.BirthDateMax, input.Address, input.MobilePhone, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeDependentsDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeDependents>, List<ResumeDependentsDto>>(items)
            };
        }

        public virtual async Task<ResumeDependentsDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeDependents, ResumeDependentsDto>(await _resumeDependentsRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeDependentss.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeDependentsRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeDependentss.Create)]
        public virtual async Task<ResumeDependentsDto> CreateAsync(ResumeDependentsCreateDto input)
        {

            var resumeDependents = await _resumeDependentsManager.CreateAsync(
            input.ResumeMainId, input.Name, input.IdentityNo, input.KinshipCode, input.BirthDate, input.DateA, input.DateD, input.Sort, input.Status, input.Address, input.MobilePhone, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeDependents, ResumeDependentsDto>(resumeDependents);
        }

        [Authorize(ResumePermissions.ResumeDependentss.Edit)]
        public virtual async Task<ResumeDependentsDto> UpdateAsync(Guid id, ResumeDependentsUpdateDto input)
        {

            var resumeDependents = await _resumeDependentsManager.UpdateAsync(
            id,
            input.ResumeMainId, input.Name, input.IdentityNo, input.KinshipCode, input.BirthDate, input.DateA, input.DateD, input.Sort, input.Status, input.Address, input.MobilePhone, input.ExtendedInformation, input.Note
            );

            return ObjectMapper.Map<ResumeDependents, ResumeDependentsDto>(resumeDependents);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeDependentsExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeDependentsRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.Name, input.IdentityNo, input.KinshipCode, input.BirthDateMin, input.BirthDateMax, input.Address, input.MobilePhone, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeDependents>, List<ResumeDependentsExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeDependentss.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeDependentsExcelDownloadTokenCacheItem { Token = token },
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