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

namespace Resume.UserMains
{
    public class EfCoreUserMainRepository : EfCoreRepository<ResumeDbContext, UserMain, Guid>, IUserMainRepository
    {
        public EfCoreUserMainRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<UserMain>> GetListAsync(
            string filterText = null,
            Guid? userId = null,
            string name = null,
            string anonymousName = null,
            string loginAccountCode = null,
            string loginMobilePhoneUpdate = null,
            string loginMobilePhone = null,
            string loginEmailUpdate = null,
            string loginEmail = null,
            string loginIdentityNo = null,
            string password = null,
            int? systemUserRoleKeysMin = null,
            int? systemUserRoleKeysMax = null,
            bool? allowSearch = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            string extendedInformation = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            bool? matching = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, userId, name, anonymousName, loginAccountCode, loginMobilePhoneUpdate, loginMobilePhone, loginEmailUpdate, loginEmail, loginIdentityNo, password, systemUserRoleKeysMin, systemUserRoleKeysMax, allowSearch, dateAMin, dateAMax, extendedInformation, dateDMin, dateDMax, sortMin, sortMax, note, status, matching);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? UserMainConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? userId = null,
            string name = null,
            string anonymousName = null,
            string loginAccountCode = null,
            string loginMobilePhoneUpdate = null,
            string loginMobilePhone = null,
            string loginEmailUpdate = null,
            string loginEmail = null,
            string loginIdentityNo = null,
            string password = null,
            int? systemUserRoleKeysMin = null,
            int? systemUserRoleKeysMax = null,
            bool? allowSearch = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            string extendedInformation = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            bool? matching = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, userId, name, anonymousName, loginAccountCode, loginMobilePhoneUpdate, loginMobilePhone, loginEmailUpdate, loginEmail, loginIdentityNo, password, systemUserRoleKeysMin, systemUserRoleKeysMax, allowSearch, dateAMin, dateAMax, extendedInformation, dateDMin, dateDMax, sortMin, sortMax, note, status, matching);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<UserMain> ApplyFilter(
            IQueryable<UserMain> query,
            string filterText,
            Guid? userId = null,
            string name = null,
            string anonymousName = null,
            string loginAccountCode = null,
            string loginMobilePhoneUpdate = null,
            string loginMobilePhone = null,
            string loginEmailUpdate = null,
            string loginEmail = null,
            string loginIdentityNo = null,
            string password = null,
            int? systemUserRoleKeysMin = null,
            int? systemUserRoleKeysMax = null,
            bool? allowSearch = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            string extendedInformation = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            bool? matching = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.AnonymousName.Contains(filterText) || e.LoginAccountCode.Contains(filterText) || e.LoginMobilePhoneUpdate.Contains(filterText) || e.LoginMobilePhone.Contains(filterText) || e.LoginEmailUpdate.Contains(filterText) || e.LoginEmail.Contains(filterText) || e.LoginIdentityNo.Contains(filterText) || e.Password.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(userId.HasValue, e => e.UserId == userId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(anonymousName), e => e.AnonymousName.Contains(anonymousName))
                    .WhereIf(!string.IsNullOrWhiteSpace(loginAccountCode), e => e.LoginAccountCode.Contains(loginAccountCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(loginMobilePhoneUpdate), e => e.LoginMobilePhoneUpdate.Contains(loginMobilePhoneUpdate))
                    .WhereIf(!string.IsNullOrWhiteSpace(loginMobilePhone), e => e.LoginMobilePhone.Contains(loginMobilePhone))
                    .WhereIf(!string.IsNullOrWhiteSpace(loginEmailUpdate), e => e.LoginEmailUpdate.Contains(loginEmailUpdate))
                    .WhereIf(!string.IsNullOrWhiteSpace(loginEmail), e => e.LoginEmail.Contains(loginEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(loginIdentityNo), e => e.LoginIdentityNo.Contains(loginIdentityNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(password), e => e.Password.Contains(password))
                    .WhereIf(systemUserRoleKeysMin.HasValue, e => e.SystemUserRoleKeys >= systemUserRoleKeysMin.Value)
                    .WhereIf(systemUserRoleKeysMax.HasValue, e => e.SystemUserRoleKeys <= systemUserRoleKeysMax.Value)
                    .WhereIf(allowSearch.HasValue, e => e.AllowSearch == allowSearch)
                    .WhereIf(dateAMin.HasValue, e => e.DateA >= dateAMin.Value)
                    .WhereIf(dateAMax.HasValue, e => e.DateA <= dateAMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(extendedInformation), e => e.ExtendedInformation.Contains(extendedInformation))
                    .WhereIf(dateDMin.HasValue, e => e.DateD >= dateDMin.Value)
                    .WhereIf(dateDMax.HasValue, e => e.DateD <= dateDMax.Value)
                    .WhereIf(sortMin.HasValue, e => e.Sort >= sortMin.Value)
                    .WhereIf(sortMax.HasValue, e => e.Sort <= sortMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.Contains(note))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status))
                    .WhereIf(matching.HasValue, e => e.Matching == matching);
        }
    }
}