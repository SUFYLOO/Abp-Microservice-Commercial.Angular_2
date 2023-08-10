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

namespace Resume.ResumeDependentss
{
    public class EfCoreResumeDependentsRepository : EfCoreRepository<ResumeDbContext, ResumeDependents, Guid>, IResumeDependentsRepository
    {
        public EfCoreResumeDependentsRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ResumeDependents>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string name = null,
            string identityNo = null,
            string kinshipCode = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string address = null,
            string mobilePhone = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, resumeMainId, name, identityNo, kinshipCode, birthDateMin, birthDateMax, address, mobilePhone, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ResumeDependentsConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string name = null,
            string identityNo = null,
            string kinshipCode = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string address = null,
            string mobilePhone = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, resumeMainId, name, identityNo, kinshipCode, birthDateMin, birthDateMax, address, mobilePhone, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ResumeDependents> ApplyFilter(
            IQueryable<ResumeDependents> query,
            string filterText,
            Guid? resumeMainId = null,
            string name = null,
            string identityNo = null,
            string kinshipCode = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string address = null,
            string mobilePhone = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.IdentityNo.Contains(filterText) || e.KinshipCode.Contains(filterText) || e.Address.Contains(filterText) || e.MobilePhone.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(resumeMainId.HasValue, e => e.ResumeMainId == resumeMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(identityNo), e => e.IdentityNo.Contains(identityNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(kinshipCode), e => e.KinshipCode.Contains(kinshipCode))
                    .WhereIf(birthDateMin.HasValue, e => e.BirthDate >= birthDateMin.Value)
                    .WhereIf(birthDateMax.HasValue, e => e.BirthDate <= birthDateMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(mobilePhone), e => e.MobilePhone.Contains(mobilePhone))
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