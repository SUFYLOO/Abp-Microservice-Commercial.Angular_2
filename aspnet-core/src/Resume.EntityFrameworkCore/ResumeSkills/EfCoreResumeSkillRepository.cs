using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Resume.EntityFrameworkCore;

namespace Resume.ResumeSkills
{
    public class EfCoreResumeSkillRepository : EfCoreRepository<ResumeDbContext, ResumeSkill, Guid>, IResumeSkillRepository
    {
        public EfCoreResumeSkillRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ResumeSkill>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string computerExpertise = null,
            string computerExpertiseEtc = null,
            int? chineseTypingSpeedMin = null,
            int? chineseTypingSpeedMax = null,
            string chineseTypingCode = null,
            int? englishTypingSpeedMin = null,
            int? englishTypingSpeedMax = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, resumeMainId, computerExpertise, computerExpertiseEtc, chineseTypingSpeedMin, chineseTypingSpeedMax, chineseTypingCode, englishTypingSpeedMin, englishTypingSpeedMax, professionalLicense, professionalLicenseEtc, workSkills, workSkillsEtc, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ResumeSkillConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string computerExpertise = null,
            string computerExpertiseEtc = null,
            int? chineseTypingSpeedMin = null,
            int? chineseTypingSpeedMax = null,
            string chineseTypingCode = null,
            int? englishTypingSpeedMin = null,
            int? englishTypingSpeedMax = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, resumeMainId, computerExpertise, computerExpertiseEtc, chineseTypingSpeedMin, chineseTypingSpeedMax, chineseTypingCode, englishTypingSpeedMin, englishTypingSpeedMax, professionalLicense, professionalLicenseEtc, workSkills, workSkillsEtc, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ResumeSkill> ApplyFilter(
            IQueryable<ResumeSkill> query,
            string filterText,
            Guid? resumeMainId = null,
            string computerExpertise = null,
            string computerExpertiseEtc = null,
            int? chineseTypingSpeedMin = null,
            int? chineseTypingSpeedMax = null,
            string chineseTypingCode = null,
            int? englishTypingSpeedMin = null,
            int? englishTypingSpeedMax = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ComputerExpertise.Contains(filterText) || e.ComputerExpertiseEtc.Contains(filterText) || e.ChineseTypingCode.Contains(filterText) || e.ProfessionalLicense.Contains(filterText) || e.ProfessionalLicenseEtc.Contains(filterText) || e.WorkSkills.Contains(filterText) || e.WorkSkillsEtc.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(resumeMainId.HasValue, e => e.ResumeMainId == resumeMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(computerExpertise), e => e.ComputerExpertise.Contains(computerExpertise))
                    .WhereIf(!string.IsNullOrWhiteSpace(computerExpertiseEtc), e => e.ComputerExpertiseEtc.Contains(computerExpertiseEtc))
                    .WhereIf(chineseTypingSpeedMin.HasValue, e => e.ChineseTypingSpeed >= chineseTypingSpeedMin.Value)
                    .WhereIf(chineseTypingSpeedMax.HasValue, e => e.ChineseTypingSpeed <= chineseTypingSpeedMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(chineseTypingCode), e => e.ChineseTypingCode.Contains(chineseTypingCode))
                    .WhereIf(englishTypingSpeedMin.HasValue, e => e.EnglishTypingSpeed >= englishTypingSpeedMin.Value)
                    .WhereIf(englishTypingSpeedMax.HasValue, e => e.EnglishTypingSpeed <= englishTypingSpeedMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(professionalLicense), e => e.ProfessionalLicense.Contains(professionalLicense))
                    .WhereIf(!string.IsNullOrWhiteSpace(professionalLicenseEtc), e => e.ProfessionalLicenseEtc.Contains(professionalLicenseEtc))
                    .WhereIf(!string.IsNullOrWhiteSpace(workSkills), e => e.WorkSkills.Contains(workSkills))
                    .WhereIf(!string.IsNullOrWhiteSpace(workSkillsEtc), e => e.WorkSkillsEtc.Contains(workSkillsEtc))
                    .WhereIf(!string.IsNullOrWhiteSpace(extendedInformation), e => e.ExtendedInformation.Contains(extendedInformation))
                    .WhereIf(dateAMin.HasValue, e => e.DateA >= dateAMin.Value)
                    .WhereIf(dateAMax.HasValue, e => e.DateA <= dateAMax.Value)
                    .WhereIf(dateDMin.HasValue, e => e.DateD >= dateDMin.Value)
                    .WhereIf(dateDMax.HasValue, e => e.DateD <= dateDMax.Value)
                    .WhereIf(sortMin.HasValue, e => e.Sort >= sortMin.Value)
                    .WhereIf(sortMax.HasValue, e => e.Sort <= sortMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.Contains(note))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}