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

namespace Resume.ResumeSnapshots
{
    public class EfCoreResumeSnapshotRepository : EfCoreRepository<ResumeDbContext, ResumeSnapshot, Guid>, IResumeSnapshotRepository
    {
        public EfCoreResumeSnapshotRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ResumeSnapshot>> GetListAsync(
            string filterText = null,
            Guid? userMainId = null,
            Guid? resumeMainId = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string snapshot = null,
            Guid? userCompanyBindId = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userMainId, resumeMainId, companyMainId, companyJobId, snapshot, userCompanyBindId, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ResumeSnapshotConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? userMainId = null,
            Guid? resumeMainId = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string snapshot = null,
            Guid? userCompanyBindId = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userMainId, resumeMainId, companyMainId, companyJobId, snapshot, userCompanyBindId, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ResumeSnapshot> ApplyFilter(
            IQueryable<ResumeSnapshot> query,
            string filterText,
            Guid? userMainId = null,
            Guid? resumeMainId = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string snapshot = null,
            Guid? userCompanyBindId = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Snapshot.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(userMainId.HasValue, e => e.UserMainId == userMainId)
                    .WhereIf(resumeMainId.HasValue, e => e.ResumeMainId == resumeMainId)
                    .WhereIf(companyMainId.HasValue, e => e.CompanyMainId == companyMainId)
                    .WhereIf(companyJobId.HasValue, e => e.CompanyJobId == companyJobId)
                    .WhereIf(!string.IsNullOrWhiteSpace(snapshot), e => e.Snapshot.Contains(snapshot))
                    .WhereIf(userCompanyBindId.HasValue, e => e.UserCompanyBindId == userCompanyBindId)
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