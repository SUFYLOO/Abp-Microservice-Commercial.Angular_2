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

namespace Resume.SystemPages
{
    public class EfCoreSystemPageRepository : EfCoreRepository<ResumeDbContext, SystemPage, Guid>, ISystemPageRepository
    {
        public EfCoreSystemPageRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<SystemPage>> GetListAsync(
            string filterText = null,
            string typeCode = null,
            string filePath = null,
            string fileName = null,
            string fileTitle = null,
            string systemUserRoleKeys = null,
            string parentCode = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, typeCode, filePath, fileName, fileTitle, systemUserRoleKeys, parentCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? SystemPageConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string typeCode = null,
            string filePath = null,
            string fileName = null,
            string fileTitle = null,
            string systemUserRoleKeys = null,
            string parentCode = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, typeCode, filePath, fileName, fileTitle, systemUserRoleKeys, parentCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<SystemPage> ApplyFilter(
            IQueryable<SystemPage> query,
            string filterText,
            string typeCode = null,
            string filePath = null,
            string fileName = null,
            string fileTitle = null,
            string systemUserRoleKeys = null,
            string parentCode = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.TypeCode.Contains(filterText) || e.FilePath.Contains(filterText) || e.FileName.Contains(filterText) || e.FileTitle.Contains(filterText) || e.SystemUserRoleKeys.Contains(filterText) || e.ParentCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(typeCode), e => e.TypeCode.Contains(typeCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(filePath), e => e.FilePath.Contains(filePath))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileName), e => e.FileName.Contains(fileName))
                    .WhereIf(!string.IsNullOrWhiteSpace(fileTitle), e => e.FileTitle.Contains(fileTitle))
                    .WhereIf(!string.IsNullOrWhiteSpace(systemUserRoleKeys), e => e.SystemUserRoleKeys.Contains(systemUserRoleKeys))
                    .WhereIf(!string.IsNullOrWhiteSpace(parentCode), e => e.ParentCode.Contains(parentCode))
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