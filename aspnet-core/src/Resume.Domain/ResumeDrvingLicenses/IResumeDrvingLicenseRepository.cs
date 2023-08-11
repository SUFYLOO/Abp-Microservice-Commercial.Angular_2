using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeDrvingLicenses
{
    public interface IResumeDrvingLicenseRepository : IRepository<ResumeDrvingLicense, Guid>
    {
        Task<List<ResumeDrvingLicense>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string drvingLicenseCode = null,
            bool? haveDrvingLicense = null,
            bool? haveCar = null,
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
            string drvingLicenseCode = null,
            bool? haveDrvingLicense = null,
            bool? haveCar = null,
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