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

namespace Resume.CompanyContracts
{
    public class EfCoreCompanyContractRepository : EfCoreRepository<ResumeDbContext, CompanyContract, Guid>, ICompanyContractRepository
    {
        public EfCoreCompanyContractRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<CompanyContract>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            string planCode = null,
            int? pointsTotalMin = null,
            int? pointsTotalMax = null,
            int? pointsPayMin = null,
            int? pointsPayMax = null,
            int? pointsGiftMin = null,
            int? pointsGiftMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyMainId, planCode, pointsTotalMin, pointsTotalMax, pointsPayMin, pointsPayMax, pointsGiftMin, pointsGiftMax, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyContractConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? companyMainId = null,
            string planCode = null,
            int? pointsTotalMin = null,
            int? pointsTotalMax = null,
            int? pointsPayMin = null,
            int? pointsPayMax = null,
            int? pointsGiftMin = null,
            int? pointsGiftMax = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyMainId, planCode, pointsTotalMin, pointsTotalMax, pointsPayMin, pointsPayMax, pointsGiftMin, pointsGiftMax, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyContract> ApplyFilter(
            IQueryable<CompanyContract> query,
            string filterText,
            Guid? companyMainId = null,
            string planCode = null,
            int? pointsTotalMin = null,
            int? pointsTotalMax = null,
            int? pointsPayMin = null,
            int? pointsPayMax = null,
            int? pointsGiftMin = null,
            int? pointsGiftMax = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.PlanCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(companyMainId.HasValue, e => e.CompanyMainId == companyMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(planCode), e => e.PlanCode.Contains(planCode))
                    .WhereIf(pointsTotalMin.HasValue, e => e.PointsTotal >= pointsTotalMin.Value)
                    .WhereIf(pointsTotalMax.HasValue, e => e.PointsTotal <= pointsTotalMax.Value)
                    .WhereIf(pointsPayMin.HasValue, e => e.PointsPay >= pointsPayMin.Value)
                    .WhereIf(pointsPayMax.HasValue, e => e.PointsPay <= pointsPayMax.Value)
                    .WhereIf(pointsGiftMin.HasValue, e => e.PointsGift >= pointsGiftMin.Value)
                    .WhereIf(pointsGiftMax.HasValue, e => e.PointsGift <= pointsGiftMax.Value)
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