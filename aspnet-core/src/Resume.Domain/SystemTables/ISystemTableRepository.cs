using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.SystemTables
{
    public interface ISystemTableRepository : IRepository<SystemTable, Guid>
    {
        Task<List<SystemTable>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}