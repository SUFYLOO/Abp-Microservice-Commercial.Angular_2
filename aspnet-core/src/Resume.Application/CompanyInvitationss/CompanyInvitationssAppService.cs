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
using Resume.CompanyInvitationss;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.CompanyInvitationss
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.CompanyInvitationss.Default)]
    public class CompanyInvitationssAppService : ApplicationService, ICompanyInvitationssAppService
    {
        private readonly IDistributedCache<CompanyInvitationsExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly ICompanyInvitationsRepository _companyInvitationsRepository;
        private readonly CompanyInvitationsManager _companyInvitationsManager;

        public CompanyInvitationssAppService(ICompanyInvitationsRepository companyInvitationsRepository, CompanyInvitationsManager companyInvitationsManager, IDistributedCache<CompanyInvitationsExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _companyInvitationsRepository = companyInvitationsRepository;
            _companyInvitationsManager = companyInvitationsManager;
        }

        public virtual async Task<PagedResultDto<CompanyInvitationsDto>> GetListAsync(GetCompanyInvitationssInput input)
        {
            var totalCount = await _companyInvitationsRepository.GetCountAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OpenAllJob, input.UserMainId, input.UserMainName, input.UserMainLoginMobilePhone, input.UserMainLoginEmail, input.UserMainLoginIdentityNo, input.SendTypeCode, input.SendStatusCode, input.ResumeFlowStageCode, input.IsRead, input.UserCompanyBindId, input.ResumeSnapshotId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _companyInvitationsRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OpenAllJob, input.UserMainId, input.UserMainName, input.UserMainLoginMobilePhone, input.UserMainLoginEmail, input.UserMainLoginIdentityNo, input.SendTypeCode, input.SendStatusCode, input.ResumeFlowStageCode, input.IsRead, input.UserCompanyBindId, input.ResumeSnapshotId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CompanyInvitationsDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<CompanyInvitations>, List<CompanyInvitationsDto>>(items)
            };
        }

        public virtual async Task<CompanyInvitationsDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<CompanyInvitations, CompanyInvitationsDto>(await _companyInvitationsRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.CompanyInvitationss.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _companyInvitationsRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.CompanyInvitationss.Create)]
        public virtual async Task<CompanyInvitationsDto> CreateAsync(CompanyInvitationsCreateDto input)
        {

            var companyInvitations = await _companyInvitationsManager.CreateAsync(
            input.CompanyMainId, input.OpenAllJob, input.UserMainName, input.UserMainLoginMobilePhone, input.UserMainLoginEmail, input.UserMainLoginIdentityNo, input.SendTypeCode, input.SendStatusCode, input.ResumeFlowStageCode, input.IsRead, input.CompanyJobId, input.UserMainId, input.UserCompanyBindId, input.ResumeSnapshotId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyInvitations, CompanyInvitationsDto>(companyInvitations);
        }

        [Authorize(ResumePermissions.CompanyInvitationss.Edit)]
        public virtual async Task<CompanyInvitationsDto> UpdateAsync(Guid id, CompanyInvitationsUpdateDto input)
        {

            var companyInvitations = await _companyInvitationsManager.UpdateAsync(
            id,
            input.CompanyMainId, input.OpenAllJob, input.UserMainName, input.UserMainLoginMobilePhone, input.UserMainLoginEmail, input.UserMainLoginIdentityNo, input.SendTypeCode, input.SendStatusCode, input.ResumeFlowStageCode, input.IsRead, input.CompanyJobId, input.UserMainId, input.UserCompanyBindId, input.ResumeSnapshotId, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<CompanyInvitations, CompanyInvitationsDto>(companyInvitations);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(CompanyInvitationsExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _companyInvitationsRepository.GetListAsync(input.FilterText, input.CompanyMainId, input.CompanyJobId, input.OpenAllJob, input.UserMainId, input.UserMainName, input.UserMainLoginMobilePhone, input.UserMainLoginEmail, input.UserMainLoginIdentityNo, input.SendTypeCode, input.SendStatusCode, input.ResumeFlowStageCode, input.IsRead, input.UserCompanyBindId, input.ResumeSnapshotId, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<CompanyInvitations>, List<CompanyInvitationsExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "CompanyInvitationss.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new CompanyInvitationsExcelDownloadTokenCacheItem { Token = token },
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