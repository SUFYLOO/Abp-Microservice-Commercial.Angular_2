using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyMains
{
    public interface ICompanyMainRepository : IRepository<CompanyMain, Guid>
    {
        Task<List<CompanyMain>> GetListAsync(
            string filterText = null,
            string name = null,
            string compilation = null,
            string officePhone = null,
            string faxPhone = null,
            string address = null,
            string principal = null,
            bool? allowSearch = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            string note = null,
            int? sortMin = null,
            int? sortMax = null,
            string status = null,
            string industryCategory = null,
            string companyUrl = null,
            int? capitalAmountMin = null,
            int? capitalAmountMax = null,
            bool? hideCapitalAmount = null,
            string companyScaleCode = null,
            bool? hidePrincipal = null,
            Guid? companyUserId = null,
            string companyProfile = null,
            string businessPhilosophy = null,
            string operatingItems = null,
            string welfareSystem = null,
            bool? matching = null,
            bool? contractPass = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string compilation = null,
            string officePhone = null,
            string faxPhone = null,
            string address = null,
            string principal = null,
            bool? allowSearch = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            string note = null,
            int? sortMin = null,
            int? sortMax = null,
            string status = null,
            string industryCategory = null,
            string companyUrl = null,
            int? capitalAmountMin = null,
            int? capitalAmountMax = null,
            bool? hideCapitalAmount = null,
            string companyScaleCode = null,
            bool? hidePrincipal = null,
            Guid? companyUserId = null,
            string companyProfile = null,
            string businessPhilosophy = null,
            string operatingItems = null,
            string welfareSystem = null,
            bool? matching = null,
            bool? contractPass = null,
            CancellationToken cancellationToken = default);
    }
}