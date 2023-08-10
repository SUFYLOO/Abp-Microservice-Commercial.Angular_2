using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyUsers
{
    public interface ICompanyUserRepository : IRepository<CompanyUser, Guid>
    {
        Task<List<CompanyUser>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? userMainId = null,
            string jobName = null,
            string officePhone = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            bool? matchingReceive = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? userMainId = null,
            string jobName = null,
            string officePhone = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            bool? matchingReceive = null,
            CancellationToken cancellationToken = default);
    }
}