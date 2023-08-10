using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.UserMains
{
    public interface IUserMainRepository : IRepository<UserMain, Guid>
    {
        Task<List<UserMain>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}