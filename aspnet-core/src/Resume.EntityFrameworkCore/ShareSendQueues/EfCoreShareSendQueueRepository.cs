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

namespace Resume.ShareSendQueues
{
    public class EfCoreShareSendQueueRepository : EfCoreRepository<ResumeDbContext, ShareSendQueue, Guid>, IShareSendQueueRepository
    {
        public EfCoreShareSendQueueRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ShareSendQueue>> GetListAsync(
            string filterText = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string sendTypeCode = null,
            string fromAddr = null,
            string toAddr = null,
            string titleContents = null,
            string contents = null,
            int? retryMin = null,
            int? retryMax = null,
            bool? sucess = null,
            bool? suspend = null,
            DateTime? dateSendMin = null,
            DateTime? dateSendMax = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, key1, key2, key3, sendTypeCode, fromAddr, toAddr, titleContents, contents, retryMin, retryMax, sucess, suspend, dateSendMin, dateSendMax, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ShareSendQueueConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string sendTypeCode = null,
            string fromAddr = null,
            string toAddr = null,
            string titleContents = null,
            string contents = null,
            int? retryMin = null,
            int? retryMax = null,
            bool? sucess = null,
            bool? suspend = null,
            DateTime? dateSendMin = null,
            DateTime? dateSendMax = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, key1, key2, key3, sendTypeCode, fromAddr, toAddr, titleContents, contents, retryMin, retryMax, sucess, suspend, dateSendMin, dateSendMax, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ShareSendQueue> ApplyFilter(
            IQueryable<ShareSendQueue> query,
            string filterText,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string sendTypeCode = null,
            string fromAddr = null,
            string toAddr = null,
            string titleContents = null,
            string contents = null,
            int? retryMin = null,
            int? retryMax = null,
            bool? sucess = null,
            bool? suspend = null,
            DateTime? dateSendMin = null,
            DateTime? dateSendMax = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Key1.Contains(filterText) || e.Key2.Contains(filterText) || e.Key3.Contains(filterText) || e.SendTypeCode.Contains(filterText) || e.FromAddr.Contains(filterText) || e.ToAddr.Contains(filterText) || e.TitleContents.Contains(filterText) || e.Contents.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(key1), e => e.Key1.Contains(key1))
                    .WhereIf(!string.IsNullOrWhiteSpace(key2), e => e.Key2.Contains(key2))
                    .WhereIf(!string.IsNullOrWhiteSpace(key3), e => e.Key3.Contains(key3))
                    .WhereIf(!string.IsNullOrWhiteSpace(sendTypeCode), e => e.SendTypeCode.Contains(sendTypeCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(fromAddr), e => e.FromAddr.Contains(fromAddr))
                    .WhereIf(!string.IsNullOrWhiteSpace(toAddr), e => e.ToAddr.Contains(toAddr))
                    .WhereIf(!string.IsNullOrWhiteSpace(titleContents), e => e.TitleContents.Contains(titleContents))
                    .WhereIf(!string.IsNullOrWhiteSpace(contents), e => e.Contents.Contains(contents))
                    .WhereIf(retryMin.HasValue, e => e.Retry >= retryMin.Value)
                    .WhereIf(retryMax.HasValue, e => e.Retry <= retryMax.Value)
                    .WhereIf(sucess.HasValue, e => e.Sucess == sucess)
                    .WhereIf(suspend.HasValue, e => e.Suspend == suspend)
                    .WhereIf(dateSendMin.HasValue, e => e.DateSend >= dateSendMin.Value)
                    .WhereIf(dateSendMax.HasValue, e => e.DateSend <= dateSendMax.Value)
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