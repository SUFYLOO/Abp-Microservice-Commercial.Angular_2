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
            string companyMainCode = null,
            string companyJobCode = null,
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCategory = null,
            string computerExpertise = null,
            string professionalLicense = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyMainCode, companyJobCode, workExperienceYearCode, educationLevel, majorDepartmentCategory, languageCategory, computerExpertise, professionalLicense, drvingLicense, etcCondition, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyJobConditionConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string companyMainCode = null,
            string companyJobCode = null,
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCategory = null,
            string computerExpertise = null,
            string professionalLicense = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyMainCode, companyJobCode, workExperienceYearCode, educationLevel, majorDepartmentCategory, languageCategory, computerExpertise, professionalLicense, drvingLicense, etcCondition, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyJobCondition> ApplyFilter(
            IQueryable<CompanyJobCondition> query,
            string filterText,
            string companyMainCode = null,
            string companyJobCode = null,
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCategory = null,
            string computerExpertise = null,
            string professionalLicense = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.CompanyMainCode.Contains(filterText) || e.CompanyJobCode.Contains(filterText) || e.WorkExperienceYearCode.Contains(filterText) || e.EducationLevel.Contains(filterText) || e.MajorDepartmentCategory.Contains(filterText) || e.LanguageCategory.Contains(filterText) || e.ComputerExpertise.Contains(filterText) || e.ProfessionalLicense.Contains(filterText) || e.DrvingLicense.Contains(filterText) || e.EtcCondition.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyMainCode), e => e.CompanyMainCode.Contains(companyMainCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyJobCode), e => e.CompanyJobCode.Contains(companyJobCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(workExperienceYearCode), e => e.WorkExperienceYearCode.Contains(workExperienceYearCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(educationLevel), e => e.EducationLevel.Contains(educationLevel))
                    .WhereIf(!string.IsNullOrWhiteSpace(majorDepartmentCategory), e => e.MajorDepartmentCategory.Contains(majorDepartmentCategory))
                    .WhereIf(!string.IsNullOrWhiteSpace(languageCategory), e => e.LanguageCategory.Contains(languageCategory))
                    .WhereIf(!string.IsNullOrWhiteSpace(computerExpertise), e => e.ComputerExpertise.Contains(computerExpertise))
                    .WhereIf(!string.IsNullOrWhiteSpace(professionalLicense), e => e.ProfessionalLicense.Contains(professionalLicense))
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