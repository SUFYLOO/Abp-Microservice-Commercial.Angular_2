using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.UserInfos
{
    public class UserInfoManager : DomainService
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoManager(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task<UserInfo> CreateAsync(
        Guid userMainId, string nameC, string nameE, string identityNo, string sexCode, string bloodCode, string placeOfBirthCode, string passportNo, string nationalityCode, string residenceNo, DateTime? birthDate = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(nameC, nameof(nameC));
            Check.Length(nameC, nameof(nameC), UserInfoConsts.NameCMaxLength);
            Check.Length(nameE, nameof(nameE), UserInfoConsts.NameEMaxLength);
            Check.Length(identityNo, nameof(identityNo), UserInfoConsts.IdentityNoMaxLength);
            Check.Length(sexCode, nameof(sexCode), UserInfoConsts.SexCodeMaxLength);
            Check.Length(bloodCode, nameof(bloodCode), UserInfoConsts.BloodCodeMaxLength);
            Check.Length(placeOfBirthCode, nameof(placeOfBirthCode), UserInfoConsts.PlaceOfBirthCodeMaxLength);
            Check.Length(passportNo, nameof(passportNo), UserInfoConsts.PassportNoMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), UserInfoConsts.NationalityCodeMaxLength);
            Check.Length(residenceNo, nameof(residenceNo), UserInfoConsts.ResidenceNoMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserInfoConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserInfoConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserInfoConsts.StatusMaxLength);

            var userInfo = new UserInfo(
             GuidGenerator.Create(),
             userMainId, nameC, nameE, identityNo, sexCode, bloodCode, placeOfBirthCode, passportNo, nationalityCode, residenceNo, birthDate, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userInfoRepository.InsertAsync(userInfo);
        }

        public async Task<UserInfo> UpdateAsync(
            Guid id,
            Guid userMainId, string nameC, string nameE, string identityNo, string sexCode, string bloodCode, string placeOfBirthCode, string passportNo, string nationalityCode, string residenceNo, DateTime? birthDate = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(nameC, nameof(nameC));
            Check.Length(nameC, nameof(nameC), UserInfoConsts.NameCMaxLength);
            Check.Length(nameE, nameof(nameE), UserInfoConsts.NameEMaxLength);
            Check.Length(identityNo, nameof(identityNo), UserInfoConsts.IdentityNoMaxLength);
            Check.Length(sexCode, nameof(sexCode), UserInfoConsts.SexCodeMaxLength);
            Check.Length(bloodCode, nameof(bloodCode), UserInfoConsts.BloodCodeMaxLength);
            Check.Length(placeOfBirthCode, nameof(placeOfBirthCode), UserInfoConsts.PlaceOfBirthCodeMaxLength);
            Check.Length(passportNo, nameof(passportNo), UserInfoConsts.PassportNoMaxLength);
            Check.Length(nationalityCode, nameof(nationalityCode), UserInfoConsts.NationalityCodeMaxLength);
            Check.Length(residenceNo, nameof(residenceNo), UserInfoConsts.ResidenceNoMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserInfoConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserInfoConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserInfoConsts.StatusMaxLength);

            var userInfo = await _userInfoRepository.GetAsync(id);

            userInfo.UserMainId = userMainId;
            userInfo.NameC = nameC;
            userInfo.NameE = nameE;
            userInfo.IdentityNo = identityNo;
            userInfo.SexCode = sexCode;
            userInfo.BloodCode = bloodCode;
            userInfo.PlaceOfBirthCode = placeOfBirthCode;
            userInfo.PassportNo = passportNo;
            userInfo.NationalityCode = nationalityCode;
            userInfo.ResidenceNo = residenceNo;
            userInfo.BirthDate = birthDate;
            userInfo.ExtendedInformation = extendedInformation;
            userInfo.DateA = dateA;
            userInfo.DateD = dateD;
            userInfo.Sort = sort;
            userInfo.Note = note;
            userInfo.Status = status;

            return await _userInfoRepository.UpdateAsync(userInfo);
        }

    }
}