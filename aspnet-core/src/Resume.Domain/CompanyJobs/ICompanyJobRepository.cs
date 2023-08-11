using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyJobs
{
    public interface ICompanyJobRepository : IRepository<CompanyJob, Guid>
    {
        Task<List<CompanyJob>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            string name = null,
            string jobTypeCode = null,
            bool? jobOpen = null,
            string mailTplId = null,
            string sMSTplId = null,
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
            Guid? companyMainId = null,
            string name = null,
            string jobTypeCode = null,
            bool? jobOpen = null,
            string mailTplId = null,
            string sMSTplId = null,
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