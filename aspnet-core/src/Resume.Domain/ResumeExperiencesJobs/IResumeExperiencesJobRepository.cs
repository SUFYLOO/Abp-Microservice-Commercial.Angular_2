using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeExperiencesJobs
{
    public interface IResumeExperiencesJobRepository : IRepository<ResumeExperiencesJob, Guid>
    {
        Task<List<ResumeExperiencesJob>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            Guid? resumeExperiencesId = null,
            string jobType = null,
            int? yearMin = null,
            int? yearMax = null,
            int? monthMin = null,
            int? monthMax = null,
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
            Guid? resumeExperiencesId = null,
            string jobType = null,
            int? yearMin = null,
            int? yearMax = null,
            int? monthMin = null,
            int? monthMax = null,
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