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

namespace Resume.SystemTables
{
    public class EfCoreSystemTableRepository : EfCoreRepository<ResumeDbContext, SystemTable, Guid>, ISystemTableRepository
    {
        public EfCoreSystemTableRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<SystemTable>> GetListAsync(
            string filterText = null,
            string name = null,
            bool? allowInsert = null,
            bool? allowUpdate = null,
            bool? allowDelete = null,
            bool? allowSelect = null,
            bool? allowExport = null,
            bool? allowImport = null,
            bool? allowPage = null,
            bool? allowSort = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, allowInsert, allowUpdate, allowDelete, allowSelect, allowExport, allowImport, allowPage, allowSort, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? SystemTableConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            bool? allowInsert = null,
            bool? allowUpdate = null,
            bool? allowDelete = null,
            bool? allowSelect = null,
            bool? allowExport = null,
            bool? allowImport = null,
            bool? allowPage = null,
            bool? allowSort = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, allowInsert, allowUpdate, allowDelete, allowSelect, allowExport, allowImport, allowPage, allowSort, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<SystemTable> ApplyFilter(
            IQueryable<SystemTable> query,
            string filterText,
            string name = null,
            bool? allowInsert = null,
            bool? allowUpdate = null,
            bool? allowDelete = null,
            bool? allowSelect = null,
            bool? allowExport = null,
            bool? allowImport = null,
            bool? allowPage = null,
            bool? allowSort = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(allowInsert.HasValue, e => e.AllowInsert == allowInsert)
                    .WhereIf(allowUpdate.HasValue, e => e.AllowUpdate == allowUpdate)
                    .WhereIf(allowDelete.HasValue, e => e.AllowDelete == allowDelete)
                    .WhereIf(allowSelect.HasValue, e => e.AllowSelect == allowSelect)
                    .WhereIf(allowExport.HasValue, e => e.AllowExport == allowExport)
                    .WhereIf(allowImport.HasValue, e => e.AllowImport == allowImport)
                    .WhereIf(allowPage.HasValue, e => e.AllowPage == allowPage)
                    .WhereIf(allowSort.HasValue, e => e.AllowSort == allowSort)
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