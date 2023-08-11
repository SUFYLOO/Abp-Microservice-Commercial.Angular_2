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

namespace Resume.ShareDefaults
{
    public class EfCoreShareDefaultRepository : EfCoreRepository<ResumeDbContext, ShareDefault, Guid>, IShareDefaultRepository
    {
        public EfCoreShareDefaultRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ShareDefault>> GetListAsync(
            string filterText = null,
            string groupCode = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
            string fieldKey = null,
            string fieldValue = null,
            string columnTypeCode = null,
            string formTypeCode = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, groupCode, key1, key2, key3, name, fieldKey, fieldValue, columnTypeCode, formTypeCode, systemUse, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShareDefaultConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string groupCode = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
            string fieldKey = null,
            string fieldValue = null,
            string columnTypeCode = null,
            string formTypeCode = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, groupCode, key1, key2, key3, name, fieldKey, fieldValue, columnTypeCode, formTypeCode, systemUse, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShareDefault> ApplyFilter(
            IQueryable<ShareDefault> query,
            string filterText,
            string groupCode = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
            string fieldKey = null,
            string fieldValue = null,
            string columnTypeCode = null,
            string formTypeCode = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.GroupCode.Contains(filterText) || e.Key1.Contains(filterText) || e.Key2.Contains(filterText) || e.Key3.Contains(filterText) || e.Name.Contains(filterText) || e.FieldKey.Contains(filterText) || e.FieldValue.Contains(filterText) || e.ColumnTypeCode.Contains(filterText) || e.FormTypeCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(groupCode), e => e.GroupCode.Contains(groupCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(key1), e => e.Key1.Contains(key1))
                    .WhereIf(!string.IsNullOrWhiteSpace(key2), e => e.Key2.Contains(key2))
                    .WhereIf(!string.IsNullOrWhiteSpace(key3), e => e.Key3.Contains(key3))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(fieldKey), e => e.FieldKey.Contains(fieldKey))
                    .WhereIf(!string.IsNullOrWhiteSpace(fieldValue), e => e.FieldValue.Contains(fieldValue))
                    .WhereIf(!string.IsNullOrWhiteSpace(columnTypeCode), e => e.ColumnTypeCode.Contains(columnTypeCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(formTypeCode), e => e.FormTypeCode.Contains(formTypeCode))
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