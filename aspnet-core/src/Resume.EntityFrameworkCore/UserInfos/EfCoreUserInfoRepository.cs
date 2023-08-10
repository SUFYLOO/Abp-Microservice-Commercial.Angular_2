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

namespace Resume.UserInfos
{
    public class EfCoreUserInfoRepository : EfCoreRepository<ResumeDbContext, UserInfo, Guid>, IUserInfoRepository
    {
        public EfCoreUserInfoRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<UserInfo>> GetListAsync(
            string filterText = null,
            Guid? userMainId = null,
            string nameC = null,
            string nameE = null,
            string identityNo = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string sexCode = null,
            string bloodCode = null,
            string placeOfBirthCode = null,
            string passportNo = null,
            string nationalityCode = null,
            string residenceNo = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userMainId, nameC, nameE, identityNo, birthDateMin, birthDateMax, sexCode, bloodCode, placeOfBirthCode, passportNo, nationalityCode, residenceNo, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? UserInfoConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? userMainId = null,
            string nameC = null,
            string nameE = null,
            string identityNo = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string sexCode = null,
            string bloodCode = null,
            string placeOfBirthCode = null,
            string passportNo = null,
            string nationalityCode = null,
            string residenceNo = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userMainId, nameC, nameE, identityNo, birthDateMin, birthDateMax, sexCode, bloodCode, placeOfBirthCode, passportNo, nationalityCode, residenceNo, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<UserInfo> ApplyFilter(
            IQueryable<UserInfo> query,
            string filterText,
            Guid? userMainId = null,
            string nameC = null,
            string nameE = null,
            string identityNo = null,
            DateTime? birthDateMin = null,
            DateTime? birthDateMax = null,
            string sexCode = null,
            string bloodCode = null,
            string placeOfBirthCode = null,
            string passportNo = null,
            string nationalityCode = null,
            string residenceNo = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.NameC.Contains(filterText) || e.NameE.Contains(filterText) || e.IdentityNo.Contains(filterText) || e.SexCode.Contains(filterText) || e.BloodCode.Contains(filterText) || e.PlaceOfBirthCode.Contains(filterText) || e.PassportNo.Contains(filterText) || e.NationalityCode.Contains(filterText) || e.ResidenceNo.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(userMainId.HasValue, e => e.UserMainId == userMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(nameC), e => e.NameC.Contains(nameC))
                    .WhereIf(!string.IsNullOrWhiteSpace(nameE), e => e.NameE.Contains(nameE))
                    .WhereIf(!string.IsNullOrWhiteSpace(identityNo), e => e.IdentityNo.Contains(identityNo))
                    .WhereIf(birthDateMin.HasValue, e => e.BirthDate >= birthDateMin.Value)
                    .WhereIf(birthDateMax.HasValue, e => e.BirthDate <= birthDateMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(sexCode), e => e.SexCode.Contains(sexCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(bloodCode), e => e.BloodCode.Contains(bloodCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(placeOfBirthCode), e => e.PlaceOfBirthCode.Contains(placeOfBirthCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(passportNo), e => e.PassportNo.Contains(passportNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(nationalityCode), e => e.NationalityCode.Contains(nationalityCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(residenceNo), e => e.ResidenceNo.Contains(residenceNo))
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