using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.UserMains
{
    public class UserMainManager : DomainService
    {
        private readonly IUserMainRepository _userMainRepository;

        public UserMainManager(IUserMainRepository userMainRepository)
        {
            _userMainRepository = userMainRepository;
        }

        public async Task<UserMain> CreateAsync(
        Guid userId, string name, string loginAccountCode, string loginMobilePhoneUpdate, string loginMobilePhone, string loginEmailUpdate, string loginEmail, string loginIdentityNo, string password, int systemUserRoleKeys, bool allowSearch, DateTime dateA, DateTime dateD, int sort, string status, bool matching, string anonymousName = null, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), UserMainConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(loginAccountCode, nameof(loginAccountCode));
            Check.Length(loginAccountCode, nameof(loginAccountCode), UserMainConsts.LoginAccountCodeMaxLength);
            Check.Length(loginMobilePhoneUpdate, nameof(loginMobilePhoneUpdate), UserMainConsts.LoginMobilePhoneUpdateMaxLength);
            Check.Length(loginMobilePhone, nameof(loginMobilePhone), UserMainConsts.LoginMobilePhoneMaxLength);
            Check.Length(loginEmailUpdate, nameof(loginEmailUpdate), UserMainConsts.LoginEmailUpdateMaxLength);
            Check.Length(loginEmail, nameof(loginEmail), UserMainConsts.LoginEmailMaxLength);
            Check.Length(loginIdentityNo, nameof(loginIdentityNo), UserMainConsts.LoginIdentityNoMaxLength);
            Check.NotNullOrWhiteSpace(password, nameof(password));
            Check.Length(password, nameof(password), UserMainConsts.PasswordMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserMainConsts.StatusMaxLength);
            Check.Length(anonymousName, nameof(anonymousName), UserMainConsts.AnonymousNameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserMainConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserMainConsts.NoteMaxLength);

            var userMain = new UserMain(
             GuidGenerator.Create(),
             userId, name, loginAccountCode, loginMobilePhoneUpdate, loginMobilePhone, loginEmailUpdate, loginEmail, loginIdentityNo, password, systemUserRoleKeys, allowSearch, dateA, dateD, sort, status, matching, anonymousName, extendedInformation, note
             );

            return await _userMainRepository.InsertAsync(userMain);
        }

        public async Task<UserMain> UpdateAsync(
            Guid id,
            Guid userId, string name, string loginAccountCode, string loginMobilePhoneUpdate, string loginMobilePhone, string loginEmailUpdate, string loginEmail, string loginIdentityNo, string password, int systemUserRoleKeys, bool allowSearch, DateTime dateA, DateTime dateD, int sort, string status, bool matching, string anonymousName = null, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), UserMainConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(loginAccountCode, nameof(loginAccountCode));
            Check.Length(loginAccountCode, nameof(loginAccountCode), UserMainConsts.LoginAccountCodeMaxLength);
            Check.Length(loginMobilePhoneUpdate, nameof(loginMobilePhoneUpdate), UserMainConsts.LoginMobilePhoneUpdateMaxLength);
            Check.Length(loginMobilePhone, nameof(loginMobilePhone), UserMainConsts.LoginMobilePhoneMaxLength);
            Check.Length(loginEmailUpdate, nameof(loginEmailUpdate), UserMainConsts.LoginEmailUpdateMaxLength);
            Check.Length(loginEmail, nameof(loginEmail), UserMainConsts.LoginEmailMaxLength);
            Check.Length(loginIdentityNo, nameof(loginIdentityNo), UserMainConsts.LoginIdentityNoMaxLength);
            Check.NotNullOrWhiteSpace(password, nameof(password));
            Check.Length(password, nameof(password), UserMainConsts.PasswordMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserMainConsts.StatusMaxLength);
            Check.Length(anonymousName, nameof(anonymousName), UserMainConsts.AnonymousNameMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserMainConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserMainConsts.NoteMaxLength);

            var userMain = await _userMainRepository.GetAsync(id);

            userMain.UserId = userId;
            userMain.Name = name;
            userMain.LoginAccountCode = loginAccountCode;
            userMain.LoginMobilePhoneUpdate = loginMobilePhoneUpdate;
            userMain.LoginMobilePhone = loginMobilePhone;
            userMain.LoginEmailUpdate = loginEmailUpdate;
            userMain.LoginEmail = loginEmail;
            userMain.LoginIdentityNo = loginIdentityNo;
            userMain.Password = password;
            userMain.SystemUserRoleKeys = systemUserRoleKeys;
            userMain.AllowSearch = allowSearch;
            userMain.DateA = dateA;
            userMain.DateD = dateD;
            userMain.Sort = sort;
            userMain.Status = status;
            userMain.Matching = matching;
            userMain.AnonymousName = anonymousName;
            userMain.ExtendedInformation = extendedInformation;
            userMain.Note = note;

            return await _userMainRepository.UpdateAsync(userMain);
        }

    }
}