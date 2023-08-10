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

namespace Resume.ShareUploads
{
    public class EfCoreShareUploadRepository : EfCoreRepository<ResumeDbContext, ShareUpload, Guid>, IShareUploadRepository
    {
        public EfCoreShareUploadRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ShareUpload>> GetListAsync(
            string filterText = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string uploadName = null,
            string serverName = null,
            string type = null,
            int? sizeMin = null,
            int? sizeMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, key1, key2, key3, uploadName, serverName, type, sizeMin, sizeMax, systemUse, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShareUploadConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string uploadName = null,
            string serverName = null,
            string type = null,
            int? sizeMin = null,
            int? sizeMax = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, key1, key2, key3, uploadName, serverName, type, sizeMin, sizeMax, systemUse, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShareUpload> ApplyFilter(
            IQueryable<ShareUpload> query,
            string filterText,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string uploadName = null,
            string serverName = null,
            string type = null,
            int? sizeMin = null,
            int? sizeMax = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Key1.Contains(filterText) || e.Key2.Contains(filterText) || e.Key3.Contains(filterText) || e.UploadName.Contains(filterText) || e.ServerName.Contains(filterText) || e.Type.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(key1), e => e.Key1.Contains(key1))
                    .WhereIf(!string.IsNullOrWhiteSpace(key2), e => e.Key2.Contains(key2))
                    .WhereIf(!string.IsNullOrWhiteSpace(key3), e => e.Key3.Contains(key3))
                    .WhereIf(!string.IsNullOrWhiteSpace(uploadName), e => e.UploadName.Contains(uploadName))
                    .WhereIf(!string.IsNullOrWhiteSpace(serverName), e => e.ServerName.Contains(serverName))
                    .WhereIf(!string.IsNullOrWhiteSpace(type), e => e.Type.Contains(type))
                    .WhereIf(sizeMin.HasValue, e => e.Size >= sizeMin.Value)
                    .WhereIf(sizeMax.HasValue, e => e.Size <= sizeMax.Value)
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