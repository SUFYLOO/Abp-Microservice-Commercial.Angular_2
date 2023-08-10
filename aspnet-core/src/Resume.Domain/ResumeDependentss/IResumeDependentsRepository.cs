using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeDependentss
{
    public interface IResumeDependentsRepository : IRepository<ResumeDependents, Guid>
    {
        Task<List<ResumeDependents>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string name = null,
            string identityNo = null,
            string kinshipCode = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string address = null,
            string mobilePhone = null,
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
            Guid? resumeMainId = null,
            string name = null,
            string identityNo = null,
            string kinshipCode = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string address = null,
            string mobilePhone = null,
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