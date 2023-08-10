using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyContracts
{
    public interface ICompanyContractRepository : IRepository<CompanyContract, Guid>
    {
        Task<List<CompanyContract>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            string planCode = null,
            int? pointsTotalMin = null,
            int? pointsTotalMax = null,
            int? pointsPayMin = null,
            int? pointsPayMax = null,
            int? pointsGiftMin = null,
            int? pointsGiftMax = null,
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
            string planCode = null,
            int? pointsTotalMin = null,
            int? pointsTotalMax = null,
            int? pointsPayMin = null,
            int? pointsPayMax = null,
            int? pointsGiftMin = null,
            int? pointsGiftMax = null,
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