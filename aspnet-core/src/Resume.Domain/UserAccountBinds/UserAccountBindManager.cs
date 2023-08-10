using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.UserAccountBinds
{
    public class UserAccountBindManager : DomainService
    {
        private readonly IUserAccountBindRepository _userAccountBindRepository;

        public UserAccountBindManager(IUserAccountBindRepository userAccountBindRepository)
        {
            _userAccountBindRepository = userAccountBindRepository;
        }

        public async Task<UserAccountBind> CreateAsync(
        Guid userMainId, string thirdPartyTypeCode, string thirdPartyAccountId, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(thirdPartyTypeCode, nameof(thirdPartyTypeCode));
            Check.Length(thirdPartyTypeCode, nameof(thirdPartyTypeCode), UserAccountBindConsts.ThirdPartyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(thirdPartyAccountId, nameof(thirdPartyAccountId));
            Check.Length(thirdPartyAccountId, nameof(thirdPartyAccountId), UserAccountBindConsts.ThirdPartyAccountIdMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserAccountBindConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserAccountBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserAccountBindConsts.NoteMaxLength);

            var userAccountBind = new UserAccountBind(
             GuidGenerator.Create(),
             userMainId, thirdPartyTypeCode, thirdPartyAccountId, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _userAccountBindRepository.InsertAsync(userAccountBind);
        }

        public async Task<UserAccountBind> UpdateAsync(
            Guid id,
            Guid userMainId, string thirdPartyTypeCode, string thirdPartyAccountId, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(thirdPartyTypeCode, nameof(thirdPartyTypeCode));
            Check.Length(thirdPartyTypeCode, nameof(thirdPartyTypeCode), UserAccountBindConsts.ThirdPartyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(thirdPartyAccountId, nameof(thirdPartyAccountId));
            Check.Length(thirdPartyAccountId, nameof(thirdPartyAccountId), UserAccountBindConsts.ThirdPartyAccountIdMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserAccountBindConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserAccountBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserAccountBindConsts.NoteMaxLength);

            var userAccountBind = await _userAccountBindRepository.GetAsync(id);

            userAccountBind.UserMainId = userMainId;
            userAccountBind.ThirdPartyTypeCode = thirdPartyTypeCode;
            userAccountBind.ThirdPartyAccountId = thirdPartyAccountId;
            userAccountBind.DateA = dateA;
            userAccountBind.DateD = dateD;
            userAccountBind.Sort = sort;
            userAccountBind.Status = status;
            userAccountBind.ExtendedInformation = extendedInformation;
            userAccountBind.Note = note;

            return await _userAccountBindRepository.UpdateAsync(userAccountBind);
        }

    }
}