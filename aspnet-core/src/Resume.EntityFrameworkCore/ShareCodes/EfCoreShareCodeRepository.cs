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

namespace Resume.ShareCodes
{
    public class EfCoreShareCodeRepository : EfCoreRepository<ResumeDbContext, ShareCode, Guid>, IShareCodeRepository
    {
        public EfCoreShareCodeRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ShareCode>> GetListAsync(
            string filterText = null,
            string groupCode = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
            string column1 = null,
            string column2 = null,
            string column3 = null,
            bool? systemUse = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, groupCode, key1, key2, key3, name, column1, column2, column3, systemUse, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShareCodeConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string groupCode = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
            string column1 = null,
            string column2 = null,
            string column3 = null,
            bool? systemUse = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, groupCode, key1, key2, key3, name, column1, column2, column3, systemUse, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShareCode> ApplyFilter(
            IQueryable<ShareCode> query,
            string filterText,
            string groupCode = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
            string column1 = null,
            string column2 = null,
            string column3 = null,
            bool? systemUse = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.GroupCode.Contains(filterText) || e.Key1.Contains(filterText) || e.Key2.Contains(filterText) || e.Key3.Contains(filterText) || e.Name.Contains(filterText) || e.Column1.Contains(filterText) || e.Column2.Contains(filterText) || e.Column3.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(groupCode), e => e.GroupCode.Contains(groupCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(key1), e => e.Key1.Contains(key1))
                    .WhereIf(!string.IsNullOrWhiteSpace(key2), e => e.Key2.Contains(key2))
                    .WhereIf(!string.IsNullOrWhiteSpace(key3), e => e.Key3.Contains(key3))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(column1), e => e.Column1.Contains(column1))
                    .WhereIf(!string.IsNullOrWhiteSpace(column2), e => e.Column2.Contains(column2))
                    .WhereIf(!string.IsNullOrWhiteSpace(column3), e => e.Column3.Contains(column3))
                    .WhereIf(systemUse.HasValue, e => e.SystemUse == systemUse)
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