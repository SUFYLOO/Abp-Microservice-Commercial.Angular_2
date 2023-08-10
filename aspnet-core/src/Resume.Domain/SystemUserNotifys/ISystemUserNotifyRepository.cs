using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.SystemUserNotifys
{
    public interface ISystemUserNotifyRepository : IRepository<SystemUserNotify, Guid>
    {
        Task<List<SystemUserNotify>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}