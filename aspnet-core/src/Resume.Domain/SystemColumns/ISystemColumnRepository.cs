using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.SystemColumns
{
    public interface ISystemColumnRepository : IRepository<SystemColumn, Guid>
    {
        Task<List<SystemColumn>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}