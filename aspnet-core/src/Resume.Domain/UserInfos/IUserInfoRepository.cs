using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.UserInfos
{
    public interface IUserInfoRepository : IRepository<UserInfo, Guid>
    {
        Task<List<UserInfo>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}