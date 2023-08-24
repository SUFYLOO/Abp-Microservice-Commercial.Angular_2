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

namespace Resume.CompanyJobConditions
{
    public class EfCoreCompanyJobConditionRepository : EfCoreRepository<ResumeDbContext, CompanyJobCondition, Guid>, ICompanyJobConditionRepository
    {
        public EfCoreCompanyJobConditionRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<CompanyJobCondition>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCondition = null,
            string computerExpertiseEtc = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string drvingLicense = null,
            string etcCondition = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyMainId, companyJobId, workExperienceYearCode, educationLevel, majorDepartmentCategory, languageCondition, computerExpertiseEtc, professionalLicense, professionalLicenseEtc, workSkills, workSkillsEtc, drvingLicense, etcCondition, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyJobConditionConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCondition = null,
            string computerExpertiseEtc = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string drvingLicense = null,
            string etcCondition = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyMainId, companyJobId, workExperienceYearCode, educationLevel, majorDepartmentCategory, languageCondition, computerExpertiseEtc, professionalLicense, professionalLicenseEtc, workSkills, workSkillsEtc, drvingLicense, etcCondition, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyJobCondition> ApplyFilter(
            IQueryable<CompanyJobCondition> query,
            string filterText,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCondition = null,
            string computerExpertiseEtc = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string drvingLicense = null,
            string etcCondition = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.WorkExperienceYearCode.Contains(filterText) || e.EducationLevel.Contains(filterText) || e.MajorDepartmentCategory.Contains(filterText) || e.LanguageCondition.Contains(filterText) || e.ComputerExpertiseEtc.Contains(filterText) || e.ProfessionalLicense.Contains(filterText) || e.ProfessionalLicenseEtc.Contains(filterText) || e.WorkSkills.Contains(filterText) || e.WorkSkillsEtc.Contains(filterText) || e.DrvingLicense.Contains(filterText) || e.EtcCondition.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(companyMainId.HasValue, e => e.CompanyMainId == companyMainId)
                    .WhereIf(companyJobId.HasValue, e => e.CompanyJobId == companyJobId)
                    .WhereIf(!string.IsNullOrWhiteSpace(workExperienceYearCode), e => e.WorkExperienceYearCode.Contains(workExperienceYearCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(educationLevel), e => e.EducationLevel.Contains(educationLevel))
                    .WhereIf(!string.IsNullOrWhiteSpace(majorDepartmentCategory), e => e.MajorDepartmentCategory.Contains(majorDepartmentCategory))
                    .WhereIf(!string.IsNullOrWhiteSpace(languageCondition), e => e.LanguageCondition.Contains(languageCondition))
                    .WhereIf(!string.IsNullOrWhiteSpace(computerExpertiseEtc), e => e.ComputerExpertiseEtc.Contains(computerExpertiseEtc))
                    .WhereIf(!string.IsNullOrWhiteSpace(professionalLicense), e => e.ProfessionalLicense.Contains(professionalLicense))
                    .WhereIf(!string.IsNullOrWhiteSpace(professionalLicenseEtc), e => e.ProfessionalLicenseEtc.Contains(professionalLicenseEtc))
                    .WhereIf(!string.IsNullOrWhiteSpace(workSkills), e => e.WorkSkills.Contains(workSkills))
                    .WhereIf(!string.IsNullOrWhiteSpace(workSkillsEtc), e => e.WorkSkillsEtc.Contains(workSkillsEtc))
                    .WhereIf(!string.IsNullOrWhiteSpace(drvingLicense), e => e.DrvingLicense.Contains(drvingLicense))
                    .WhereIf(!string.IsNullOrWhiteSpace(etcCondition), e => e.EtcCondition.Contains(etcCondition))
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