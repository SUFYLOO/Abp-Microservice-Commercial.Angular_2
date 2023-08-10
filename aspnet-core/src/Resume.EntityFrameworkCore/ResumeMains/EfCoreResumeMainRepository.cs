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

namespace Resume.ResumeMains
{
    public class EfCoreResumeMainRepository : EfCoreRepository<ResumeDbContext, ResumeMain, Guid>, IResumeMainRepository
    {
        public EfCoreResumeMainRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ResumeMain>> GetListAsync(
            string filterText = null,
            Guid? userMainId = null,
            string resumeName = null,
            string marriageCode = null,
            string militaryCode = null,
            string disabilityCategoryCode = null,
            string specialIdentityCode = null,
            bool? main = null,
            string autobiography1 = null,
            string autobiography2 = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userMainId, resumeName, marriageCode, militaryCode, disabilityCategoryCode, specialIdentityCode, main, autobiography1, autobiography2, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ResumeMainConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? userMainId = null,
            string resumeName = null,
            string marriageCode = null,
            string militaryCode = null,
            string disabilityCategoryCode = null,
            string specialIdentityCode = null,
            bool? main = null,
            string autobiography1 = null,
            string autobiography2 = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userMainId, resumeName, marriageCode, militaryCode, disabilityCategoryCode, specialIdentityCode, main, autobiography1, autobiography2, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ResumeMain> ApplyFilter(
            IQueryable<ResumeMain> query,
            string filterText,
            Guid? userMainId = null,
            string resumeName = null,
            string marriageCode = null,
            string militaryCode = null,
            string disabilityCategoryCode = null,
            string specialIdentityCode = null,
            bool? main = null,
            string autobiography1 = null,
            string autobiography2 = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.ResumeName.Contains(filterText) || e.MarriageCode.Contains(filterText) || e.MilitaryCode.Contains(filterText) || e.DisabilityCategoryCode.Contains(filterText) || e.SpecialIdentityCode.Contains(filterText) || e.Autobiography1.Contains(filterText) || e.Autobiography2.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(userMainId.HasValue, e => e.UserMainId == userMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(resumeName), e => e.ResumeName.Contains(resumeName))
                    .WhereIf(!string.IsNullOrWhiteSpace(marriageCode), e => e.MarriageCode.Contains(marriageCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(militaryCode), e => e.MilitaryCode.Contains(militaryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(disabilityCategoryCode), e => e.DisabilityCategoryCode.Contains(disabilityCategoryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(specialIdentityCode), e => e.SpecialIdentityCode.Contains(specialIdentityCode))
                    .WhereIf(main.HasValue, e => e.Main == main)
                    .WhereIf(!string.IsNullOrWhiteSpace(autobiography1), e => e.Autobiography1.Contains(autobiography1))
                    .WhereIf(!string.IsNullOrWhiteSpace(autobiography2), e => e.Autobiography2.Contains(autobiography2))
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