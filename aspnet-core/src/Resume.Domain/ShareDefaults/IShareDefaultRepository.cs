using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ShareDefaults
{
    public interface IShareDefaultRepository : IRepository<ShareDefault, Guid>
    {
        Task<List<ShareDefault>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}