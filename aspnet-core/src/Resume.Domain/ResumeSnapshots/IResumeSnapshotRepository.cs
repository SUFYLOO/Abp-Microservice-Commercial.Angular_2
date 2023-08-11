using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeSnapshots
{
    public interface IResumeSnapshotRepository : IRepository<ResumeSnapshot, Guid>
    {
        Task<List<ResumeSnapshot>> GetListAsync(
            string filterText = null,
            Guid? userMainId = null,
            Guid? resumeMainId = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string snapshot = null,
            Guid? userCompanyBindId = null,
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
            Guid? resumeMainId = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string snapshot = null,
            Guid? userCompanyBindId = null,
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