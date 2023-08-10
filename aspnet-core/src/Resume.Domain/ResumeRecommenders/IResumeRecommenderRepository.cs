using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeRecommenders
{
    public interface IResumeRecommenderRepository : IRepository<ResumeRecommender, Guid>
    {
        Task<List<ResumeRecommender>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string name = null,
            string companyName = null,
            string jobName = null,
            string mobilePhone = null,
            string officePhone = null,
            string email = null,
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
            string companyName = null,
            string jobName = null,
            string mobilePhone = null,
            string officePhone = null,
            string email = null,
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