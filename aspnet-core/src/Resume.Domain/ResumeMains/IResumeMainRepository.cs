using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeMains
{
    public interface IResumeMainRepository : IRepository<ResumeMain, Guid>
    {
        Task<List<ResumeMain>> GetListAsync(
            string filterText = null,
            Guid? userMainId = null,
            string resumeName = null,
            string marriageCode = null,
            string militaryCode = null,
            string disabilityCategoryCode = null,
            string specialIdentityCode = null,
            bool? main = null,
            string autobiography1 = null,
            string autobiography2 = null,
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
            Guid? userMainId = null,
            string resumeName = null,
            string marriageCode = null,
            string militaryCode = null,
            string disabilityCategoryCode = null,
            string specialIdentityCode = null,
            bool? main = null,
            string autobiography1 = null,
            string autobiography2 = null,
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