using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyJobWorkHourss
{
    public interface ICompanyJobWorkHoursRepository : IRepository<CompanyJobWorkHours, Guid>
    {
        Task<List<CompanyJobWorkHours>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string workHoursCode = null,
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
            Guid? companyJobId = null,
            string workHoursCode = null,
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