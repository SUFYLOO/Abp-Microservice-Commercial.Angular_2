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

namespace Resume.SystemColumns
{
    public class EfCoreSystemColumnRepository : EfCoreRepository<ResumeDbContext, SystemColumn, Guid>, ISystemColumnRepository
    {
        public EfCoreSystemColumnRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<SystemColumn>> GetListAsync(
            string filterText = null,
            Guid? systemTableId = null,
            string name = null,
            bool? isKey = null,
            bool? isSensitive = null,
            bool? needMask = null,
            string defaultValue = null,
            bool? checkCode = null,
            string related = null,
            bool? allowUpdate = null,
            bool? allowNull = null,
            bool? allowEmpty = null,
            bool? allowExport = null,
            bool? allowSort = null,
            string columnTypeCode = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, systemTableId, name, isKey, isSensitive, needMask, defaultValue, checkCode, related, allowUpdate, allowNull, allowEmpty, allowExport, allowSort, columnTypeCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? SystemColumnConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? systemTableId = null,
            string name = null,
            bool? isKey = null,
            bool? isSensitive = null,
            bool? needMask = null,
            string defaultValue = null,
            bool? checkCode = null,
            string related = null,
            bool? allowUpdate = null,
            bool? allowNull = null,
            bool? allowEmpty = null,
            bool? allowExport = null,
            bool? allowSort = null,
            string columnTypeCode = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, systemTableId, name, isKey, isSensitive, needMask, defaultValue, checkCode, related, allowUpdate, allowNull, allowEmpty, allowExport, allowSort, columnTypeCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<SystemColumn> ApplyFilter(
            IQueryable<SystemColumn> query,
            string filterText,
            Guid? systemTableId = null,
            string name = null,
            bool? isKey = null,
            bool? isSensitive = null,
            bool? needMask = null,
            string defaultValue = null,
            bool? checkCode = null,
            string related = null,
            bool? allowUpdate = null,
            bool? allowNull = null,
            bool? allowEmpty = null,
            bool? allowExport = null,
            bool? allowSort = null,
            string columnTypeCode = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.DefaultValue.Contains(filterText) || e.Related.Contains(filterText) || e.ColumnTypeCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(systemTableId.HasValue, e => e.SystemTableId == systemTableId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(isKey.HasValue, e => e.IsKey == isKey)
                    .WhereIf(isSensitive.HasValue, e => e.IsSensitive == isSensitive)
                    .WhereIf(needMask.HasValue, e => e.NeedMask == needMask)
                    .WhereIf(!string.IsNullOrWhiteSpace(defaultValue), e => e.DefaultValue.Contains(defaultValue))
                    .WhereIf(checkCode.HasValue, e => e.CheckCode == checkCode)
                    .WhereIf(!string.IsNullOrWhiteSpace(related), e => e.Related.Contains(related))
                    .WhereIf(allowUpdate.HasValue, e => e.AllowUpdate == allowUpdate)
                    .WhereIf(allowNull.HasValue, e => e.AllowNull == allowNull)
                    .WhereIf(allowEmpty.HasValue, e => e.AllowEmpty == allowEmpty)
                    .WhereIf(allowExport.HasValue, e => e.AllowExport == allowExport)
                    .WhereIf(allowSort.HasValue, e => e.AllowSort == allowSort)
                    .WhereIf(!string.IsNullOrWhiteSpace(columnTypeCode), e => e.ColumnTypeCode.Contains(columnTypeCode))
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