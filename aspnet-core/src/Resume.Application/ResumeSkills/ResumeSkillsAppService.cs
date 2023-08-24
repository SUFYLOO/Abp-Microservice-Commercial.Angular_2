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
using Resume.ResumeSkills;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Resume.Shared;

namespace Resume.ResumeSkills
{
    [RemoteService(IsEnabled = false)]
    [Authorize(ResumePermissions.ResumeSkills.Default)]
    public class ResumeSkillsAppService : ApplicationService, IResumeSkillsAppService
    {
        private readonly IDistributedCache<ResumeSkillExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IResumeSkillRepository _resumeSkillRepository;
        private readonly ResumeSkillManager _resumeSkillManager;

        public ResumeSkillsAppService(IResumeSkillRepository resumeSkillRepository, ResumeSkillManager resumeSkillManager, IDistributedCache<ResumeSkillExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _resumeSkillRepository = resumeSkillRepository;
            _resumeSkillManager = resumeSkillManager;
        }

        public virtual async Task<PagedResultDto<ResumeSkillDto>> GetListAsync(GetResumeSkillsInput input)
        {
            var totalCount = await _resumeSkillRepository.GetCountAsync(input.FilterText, input.ResumeMainId, input.ComputerExpertise, input.ComputerExpertiseEtc, input.ChineseTypingSpeedMin, input.ChineseTypingSpeedMax, input.ChineseTypingCode, input.EnglishTypingSpeedMin, input.EnglishTypingSpeedMax, input.ProfessionalLicense, input.ProfessionalLicenseEtc, input.WorkSkills, input.WorkSkillsEtc, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);
            var items = await _resumeSkillRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.ComputerExpertise, input.ComputerExpertiseEtc, input.ChineseTypingSpeedMin, input.ChineseTypingSpeedMax, input.ChineseTypingCode, input.EnglishTypingSpeedMin, input.EnglishTypingSpeedMax, input.ProfessionalLicense, input.ProfessionalLicenseEtc, input.WorkSkills, input.WorkSkillsEtc, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ResumeSkillDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ResumeSkill>, List<ResumeSkillDto>>(items)
            };
        }

        public virtual async Task<ResumeSkillDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ResumeSkill, ResumeSkillDto>(await _resumeSkillRepository.GetAsync(id));
        }

        [Authorize(ResumePermissions.ResumeSkills.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _resumeSkillRepository.DeleteAsync(id);
        }

        [Authorize(ResumePermissions.ResumeSkills.Create)]
        public virtual async Task<ResumeSkillDto> CreateAsync(ResumeSkillCreateDto input)
        {

            var resumeSkill = await _resumeSkillManager.CreateAsync(
            input.ResumeMainId, input.ComputerExpertise, input.ComputerExpertiseEtc, input.ChineseTypingSpeed, input.ChineseTypingCode, input.EnglishTypingSpeed, input.ProfessionalLicense, input.ProfessionalLicenseEtc, input.WorkSkills, input.WorkSkillsEtc, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeSkill, ResumeSkillDto>(resumeSkill);
        }

        [Authorize(ResumePermissions.ResumeSkills.Edit)]
        public virtual async Task<ResumeSkillDto> UpdateAsync(Guid id, ResumeSkillUpdateDto input)
        {

            var resumeSkill = await _resumeSkillManager.UpdateAsync(
            id,
            input.ResumeMainId, input.ComputerExpertise, input.ComputerExpertiseEtc, input.ChineseTypingSpeed, input.ChineseTypingCode, input.EnglishTypingSpeed, input.ProfessionalLicense, input.ProfessionalLicenseEtc, input.WorkSkills, input.WorkSkillsEtc, input.ExtendedInformation, input.DateA, input.DateD, input.Sort, input.Note, input.Status
            );

            return ObjectMapper.Map<ResumeSkill, ResumeSkillDto>(resumeSkill);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(ResumeSkillExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _resumeSkillRepository.GetListAsync(input.FilterText, input.ResumeMainId, input.ComputerExpertise, input.ComputerExpertiseEtc, input.ChineseTypingSpeedMin, input.ChineseTypingSpeedMax, input.ChineseTypingCode, input.EnglishTypingSpeedMin, input.EnglishTypingSpeedMax, input.ProfessionalLicense, input.ProfessionalLicenseEtc, input.WorkSkills, input.WorkSkillsEtc, input.ExtendedInformation, input.DateAMin, input.DateAMax, input.DateDMin, input.DateDMax, input.SortMin, input.SortMax, input.Note, input.Status);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<ResumeSkill>, List<ResumeSkillExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "ResumeSkills.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new ResumeSkillExcelDownloadTokenCacheItem { Token = token },
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