using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeLanguages
{
    public interface IResumeLanguageRepository : IRepository<ResumeLanguage, Guid>
    {
        Task<List<ResumeLanguage>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string languageCategoryCode = null,
            string levelSayCode = null,
            string levelListenCode = null,
            string levelReadCode = null,
            string levelWriteCode = null,
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
            string languageCategoryCode = null,
            string levelSayCode = null,
            string levelListenCode = null,
            string levelReadCode = null,
            string levelWriteCode = null,
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