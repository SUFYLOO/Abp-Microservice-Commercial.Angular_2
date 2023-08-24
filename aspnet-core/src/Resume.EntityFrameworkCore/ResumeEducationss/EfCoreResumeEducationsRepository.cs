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

namespace Resume.ResumeEducationss
{
    public class EfCoreResumeEducationsRepository : EfCoreRepository<ResumeDbContext, ResumeEducations, Guid>, IResumeEducationsRepository
    {
        public EfCoreResumeEducationsRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ResumeEducations>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string educationLevelCode = null,
            string schoolCode = null,
            string schoolName = null,
            bool? night = null,
            bool? working = null,
            string majorDepartmentName = null,
            string majorDepartmentCategory = null,
            string minorDepartmentName = null,
            string minorDepartmentCategory = null,
            string graduationCode = null,
            bool? domestic = null,
            string countryCode = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, resumeMainId, educationLevelCode, schoolCode, schoolName, night, working, majorDepartmentName, majorDepartmentCategory, minorDepartmentName, minorDepartmentCategory, graduationCode, domestic, countryCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ResumeEducationsConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string educationLevelCode = null,
            string schoolCode = null,
            string schoolName = null,
            bool? night = null,
            bool? working = null,
            string majorDepartmentName = null,
            string majorDepartmentCategory = null,
            string minorDepartmentName = null,
            string minorDepartmentCategory = null,
            string graduationCode = null,
            bool? domestic = null,
            string countryCode = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, resumeMainId, educationLevelCode, schoolCode, schoolName, night, working, majorDepartmentName, majorDepartmentCategory, minorDepartmentName, minorDepartmentCategory, graduationCode, domestic, countryCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ResumeEducations> ApplyFilter(
            IQueryable<ResumeEducations> query,
            string filterText,
            Guid? resumeMainId = null,
            string educationLevelCode = null,
            string schoolCode = null,
            string schoolName = null,
            bool? night = null,
            bool? working = null,
            string majorDepartmentName = null,
            string majorDepartmentCategory = null,
            string minorDepartmentName = null,
            string minorDepartmentCategory = null,
            string graduationCode = null,
            bool? domestic = null,
            string countryCode = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.EducationLevelCode.Contains(filterText) || e.SchoolCode.Contains(filterText) || e.SchoolName.Contains(filterText) || e.MajorDepartmentName.Contains(filterText) || e.MajorDepartmentCategory.Contains(filterText) || e.MinorDepartmentName.Contains(filterText) || e.MinorDepartmentCategory.Contains(filterText) || e.GraduationCode.Contains(filterText) || e.CountryCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(resumeMainId.HasValue, e => e.ResumeMainId == resumeMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(educationLevelCode), e => e.EducationLevelCode.Contains(educationLevelCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(schoolCode), e => e.SchoolCode.Contains(schoolCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(schoolName), e => e.SchoolName.Contains(schoolName))
                    .WhereIf(night.HasValue, e => e.Night == night)
                    .WhereIf(working.HasValue, e => e.Working == working)
                    .WhereIf(!string.IsNullOrWhiteSpace(majorDepartmentName), e => e.MajorDepartmentName.Contains(majorDepartmentName))
                    .WhereIf(!string.IsNullOrWhiteSpace(majorDepartmentCategory), e => e.MajorDepartmentCategory.Contains(majorDepartmentCategory))
                    .WhereIf(!string.IsNullOrWhiteSpace(minorDepartmentName), e => e.MinorDepartmentName.Contains(minorDepartmentName))
                    .WhereIf(!string.IsNullOrWhiteSpace(minorDepartmentCategory), e => e.MinorDepartmentCategory.Contains(minorDepartmentCategory))
                    .WhereIf(!string.IsNullOrWhiteSpace(graduationCode), e => e.GraduationCode.Contains(graduationCode))
                    .WhereIf(domestic.HasValue, e => e.Domestic == domestic)
                    .WhereIf(!string.IsNullOrWhiteSpace(countryCode), e => e.CountryCode.Contains(countryCode))
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