using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeExperiencess
{
    public interface IResumeExperiencesRepository : IRepository<ResumeExperiences, Guid>
    {
        Task<List<ResumeExperiences>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string name = null,
            string workNatureCode = null,
            bool? hideCompanyName = null,
            string industryCategoryCode = null,
            string jobName = null,
            string jobType = null,
            bool? working = null,
            string workPlaceCode = null,
            bool? hideWorkSalary = null,
            string salaryPayTypeCode = null,
            string currencyTypeCode = null,
            decimal? salary1Min = null,
            decimal? salary1Max = null,
            decimal? salary2Min = null,
            decimal? salary2Max = null,
            string companyScaleCode = null,
            string companyManagementNumberCode = null,
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
            string workNatureCode = null,
            bool? hideCompanyName = null,
            string industryCategoryCode = null,
            string jobName = null,
            string jobType = null,
            bool? working = null,
            string workPlaceCode = null,
            bool? hideWorkSalary = null,
            string salaryPayTypeCode = null,
            string currencyTypeCode = null,
            decimal? salary1Min = null,
            decimal? salary1Max = null,
            decimal? salary2Min = null,
            decimal? salary2Max = null,
            string companyScaleCode = null,
            string companyManagementNumberCode = null,
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