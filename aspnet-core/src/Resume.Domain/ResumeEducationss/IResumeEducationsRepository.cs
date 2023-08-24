using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeEducationss
{
    public interface IResumeEducationsRepository : IRepository<ResumeEducations, Guid>
    {
        Task<List<ResumeEducations>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string educationLevelCode = null,
            string schoolCode = null,
            string schoolName = null,
            bool? night = null,
            bool? working = null,
            string majorDepartmentName = null,
            string majorDepartmentCategory = null,
            string minorDepartmentName = null,
            string minorDepartmentCategory = null,
            string graduationCode = null,
            bool? domestic = null,
            string countryCode = null,
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
            string educationLevelCode = null,
            string schoolCode = null,
            string schoolName = null,
            bool? night = null,
            bool? working = null,
            string majorDepartmentName = null,
            string majorDepartmentCategory = null,
            string minorDepartmentName = null,
            string minorDepartmentCategory = null,
            string graduationCode = null,
            bool? domestic = null,
            string countryCode = null,
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