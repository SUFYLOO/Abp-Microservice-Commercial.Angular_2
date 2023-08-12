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
        Guid userMainId, string thirdPartyTypeCode, string thirdPartyAccountId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(thirdPartyTypeCode, nameof(thirdPartyTypeCode));
            Check.Length(thirdPartyTypeCode, nameof(thirdPartyTypeCode), UserAccountBindConsts.ThirdPartyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(thirdPartyAccountId, nameof(thirdPartyAccountId));
            Check.Length(thirdPartyAccountId, nameof(thirdPartyAccountId), UserAccountBindConsts.ThirdPartyAccountIdMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserAccountBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserAccountBindConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserAccountBindConsts.StatusMaxLength);

            var userAccountBind = new UserAccountBind(
             GuidGenerator.Create(),
             userMainId, thirdPartyTypeCode, thirdPartyAccountId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userAccountBindRepository.InsertAsync(userAccountBind);
        }

        public async Task<UserAccountBind> UpdateAsync(
            Guid id,
            Guid userMainId, string thirdPartyTypeCode, string thirdPartyAccountId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(thirdPartyTypeCode, nameof(thirdPartyTypeCode));
            Check.Length(thirdPartyTypeCode, nameof(thirdPartyTypeCode), UserAccountBindConsts.ThirdPartyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(thirdPartyAccountId, nameof(thirdPartyAccountId));
            Check.Length(thirdPartyAccountId, nameof(thirdPartyAccountId), UserAccountBindConsts.ThirdPartyAccountIdMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserAccountBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserAccountBindConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserAccountBindConsts.StatusMaxLength);

            var userAccountBind = await _userAccountBindRepository.GetAsync(id);

            userAccountBind.UserMainId = userMainId;
            userAccountBind.ThirdPartyTypeCode = thirdPartyTypeCode;
            userAccountBind.ThirdPartyAccountId = thirdPartyAccountId;
            userAccountBind.ExtendedInformation = extendedInformation;
            userAccountBind.DateA = dateA;
            userAccountBind.DateD = dateD;
            userAccountBind.Sort = sort;
            userAccountBind.Note = note;
            userAccountBind.Status = status;

            return await _userAccountBindRepository.UpdateAsync(userAccountBind);
        }

    }
}