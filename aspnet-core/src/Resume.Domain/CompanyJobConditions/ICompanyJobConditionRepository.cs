using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyJobConditions
{
    public interface ICompanyJobConditionRepository : IRepository<CompanyJobCondition, Guid>
    {
        Task<List<CompanyJobCondition>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCategory = null,
            string computerExpertise = null,
            string professionalLicense = null,
            string drvingLicense = null,
            string etcCondition = null,
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
            string workExperienceYearCode = null,
            string educationLevel = null,
            string majorDepartmentCategory = null,
            string languageCategory = null,
            string computerExpertise = null,
            string professionalLicense = null,
            string drvingLicense = null,
            string etcCondition = null,
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