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

namespace Resume.SystemUserNotifys
{
    public class EfCoreSystemUserNotifyRepository : EfCoreRepository<ResumeDbContext, SystemUserNotify, Guid>, ISystemUserNotifyRepository
    {
        public EfCoreSystemUserNotifyRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<SystemUserNotify>> GetListAsync(
            string filterText = null,
            Guid? userMainId = null,
            string keyId = null,
            string keyName = null,
            string notifyTypeCode = null,
            string appName = null,
            string appCode = null,
            string titleContents = null,
            string contents = null,
            bool? isRead = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userMainId, keyId, keyName, notifyTypeCode, appName, appCode, titleContents, contents, isRead, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? SystemUserNotifyConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? userMainId = null,
            string keyId = null,
            string keyName = null,
            string notifyTypeCode = null,
            string appName = null,
            string appCode = null,
            string titleContents = null,
            string contents = null,
            bool? isRead = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userMainId, keyId, keyName, notifyTypeCode, appName, appCode, titleContents, contents, isRead, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<SystemUserNotify> ApplyFilter(
            IQueryable<SystemUserNotify> query,
            string filterText,
            Guid? userMainId = null,
            string keyId = null,
            string keyName = null,
            string notifyTypeCode = null,
            string appName = null,
            string appCode = null,
            string titleContents = null,
            string contents = null,
            bool? isRead = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.KeyId.Contains(filterText) || e.KeyName.Contains(filterText) || e.NotifyTypeCode.Contains(filterText) || e.AppName.Contains(filterText) || e.AppCode.Contains(filterText) || e.TitleContents.Contains(filterText) || e.Contents.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(userMainId.HasValue, e => e.UserMainId == userMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(keyId), e => e.KeyId.Contains(keyId))
                    .WhereIf(!string.IsNullOrWhiteSpace(keyName), e => e.KeyName.Contains(keyName))
                    .WhereIf(!string.IsNullOrWhiteSpace(notifyTypeCode), e => e.NotifyTypeCode.Contains(notifyTypeCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(appName), e => e.AppName.Contains(appName))
                    .WhereIf(!string.IsNullOrWhiteSpace(appCode), e => e.AppCode.Contains(appCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(titleContents), e => e.TitleContents.Contains(titleContents))
                    .WhereIf(!string.IsNullOrWhiteSpace(contents), e => e.Contents.Contains(contents))
                    .WhereIf(isRead.HasValue, e => e.IsRead == isRead)
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