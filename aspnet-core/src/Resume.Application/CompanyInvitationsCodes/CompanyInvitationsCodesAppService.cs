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
using Resume.CompanyInvitationsCodes;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyInvitationsCodes
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyInvitationsCodes.Default)]
    public class CompanyInvitationsCodesAppService : ApplicationService, ICompanyInvitationsCodesAppService
    {
        private readonly IDistributedCache<CompanyInvitationsCodeExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyInvitationsCodeRepository _companyInvitationsCodeRepository;
        private readonly CompanyInvitationsCodeManager _companyInvitationsCodeManager;

        public CompanyInvitationsCodesAppService(ICompanyInvitationsCodeRepository companyInvitationsCodeRepository, CompanyInvitationsCodeManager companyInvitationsCodeManager, IDistributedCache<CompanyInvitationsCodeExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyInvitationsCodeRepository = companyInvitationsCodeRepository;
            _companyInvitationsCodeManager = companyInvitationsCodeManager;
        }

        public virtual async Task<PagedResultDto<CompanyInvitationsCodeDto>> GetListAsync(GetCompanyInvitationsCodesInput input)
        {
            var totalCount = await _companyInvitationsCodeRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationId, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyInvitationsCodeRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationId, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyInvitationsCodeDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyInvitationsCode>, List<CompanyInvitationsCodeDto>>(items)
            };
        }

        public virtual async Task<CompanyInvitationsCodeDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyInvitationsCode, CompanyInvitationsCodeDto>(await _companyInvitationsCodeRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyInvitationsCodes.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyInvitationsCodeRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyInvitationsCodes.Create)]
        public virtual async Task<CompanyInvitationsCodeDto> CreateAsync(CompanyInvitationsCodeCreateDto input)
        {

            var companyInvitationsCode = await _companyInvitationsCodeManager.CreateAsync(
            input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationId, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyInvitationsCode, CompanyInvitationsCodeDto>(companyInvitationsCode);
        }

        [Authorize(ResumePermissions.CompanyInvitationsCodes.Edit)]
        public virtual async Task<CompanyInvitationsCodeDto> UpdateAsync(Guid id, CompanyInvitationsCodeUpdateDto input)
        {

            var companyInvitationsCode = await _companyInvitationsCodeManager.UpdateAsync(
            id,
            input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationId, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<CompanyInvitationsCode, CompanyInvitationsCodeDto>(companyInvitationsCode);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyInvitationsCodeExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyInvitationsCodeRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.CompanyInvitationId, input.VerifyId, input.VerifyCode, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyInvitationsCode>, List<CompanyInvitationsCodeExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyInvitationsCodes.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyInvitationsCodeExcelDownloadTokenCacheItem { Token = token },
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