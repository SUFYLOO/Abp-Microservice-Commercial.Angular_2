using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.SystemPages
{
    public interface ISystemPageRepository : IRepository<SystemPage, Guid>
    {
        Task<List<SystemPage>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}