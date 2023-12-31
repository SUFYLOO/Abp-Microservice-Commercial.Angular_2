using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFavManager : DomainService
    {
        private readonly IUserCompanyJobFavRepository _userCompanyJobFavRepository;

        public UserCompanyJobFavManager(IUserCompanyJobFavRepository userCompanyJobFavRepository)
        {
            _userCompanyJobFavRepository = userCompanyJobFavRepository;
        }

        public async Task<UserCompanyJobFav> CreateAsync(
        Guid userMainId, Guid companyJobId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobFavConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserCompanyJobFavConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserCompanyJobFavConsts.StatusMaxLength);

            var userCompanyJobFav = new UserCompanyJobFav(
             GuidGenerator.Create(),
             userMainId, companyJobId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userCompanyJobFavRepository.InsertAsync(userCompanyJobFav);
        }

        public async Task<UserCompanyJobFav> UpdateAsync(
            Guid id,
            Guid userMainId, Guid companyJobId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobFavConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserCompanyJobFavConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserCompanyJobFavConsts.StatusMaxLength);

            var userCompanyJobFav = await _userCompanyJobFavRepository.GetAsync(id);

            userCompanyJobFav.UserMainId = userMainId;
            userCompanyJobFav.CompanyJobId = companyJobId;
            userCompanyJobFav.ExtendedInformation = extendedInformation;
            userCompanyJobFav.DateA = dateA;
            userCompanyJobFav.DateD = dateD;
            userCompanyJobFav.Sort = sort;
            userCompanyJobFav.Note = note;
            userCompanyJobFav.Status = status;

            return await _userCompanyJobFavRepository.UpdateAsync(userCompanyJobFav);
        }

    }
}