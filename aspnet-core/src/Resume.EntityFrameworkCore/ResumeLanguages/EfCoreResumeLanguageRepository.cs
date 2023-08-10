using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Resume.EntityFrameworkCore;

namespace Resume.ResumeLanguages
{
    public class EfCoreResumeLanguageRepository : EfCoreRepository<ResumeDbContext, ResumeLanguage, Guid>, IResumeLanguageRepository
    {
        public EfCoreResumeLanguageRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ResumeLanguage>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, resumeMainId, languageCategoryCode, levelSayCode, levelListenCode, levelReadCode, levelWriteCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ResumeLanguageConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, resumeMainId, languageCategoryCode, levelSayCode, levelListenCode, levelReadCode, levelWriteCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ResumeLanguage> ApplyFilter(
            IQueryable<ResumeLanguage> query,
            string filterText,
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
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.LanguageCategoryCode.Contains(filterText) || e.LevelSayCode.Contains(filterText) || e.LevelListenCode.Contains(filterText) || e.LevelReadCode.Contains(filterText) || e.LevelWriteCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(resumeMainId.HasValue, e => e.ResumeMainId == resumeMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(languageCategoryCode), e => e.LanguageCategoryCode.Contains(languageCategoryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(levelSayCode), e => e.LevelSayCode.Contains(levelSayCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(levelListenCode), e => e.LevelListenCode.Contains(levelListenCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(levelReadCode), e => e.LevelReadCode.Contains(levelReadCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(levelWriteCode), e => e.LevelWriteCode.Contains(levelWriteCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(extendedInformation), e => e.ExtendedInformation.Contains(extendedInformation))
                    .WhereIf(dateAMin.HasValue, e => e.DateA >= dateAMin.Value)
                    .WhereIf(dateAMax.HasValue, e => e.DateA <= dateAMax.Value)
                    .WhereIf(dateDMin.HasValue, e => e.DateD >= dateDMin.Value)
                    .WhereIf(dateDMax.HasValue, e => e.DateD <= dateDMax.Value)
                    .WhereIf(sortMin.HasValue, e => e.Sort >= sortMin.Value)
                    .WhereIf(sortMax.HasValue, e => e.Sort <= sortMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.Contains(note))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}