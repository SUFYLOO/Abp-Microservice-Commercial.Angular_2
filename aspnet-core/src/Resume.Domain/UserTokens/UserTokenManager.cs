using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.UserTokens
{
    public class UserTokenManager : DomainService
    {
        private readonly IUserTokenRepository _userTokenRepository;

        public UserTokenManager(IUserTokenRepository userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }

        public async Task<UserToken> CreateAsync(
        Guid userMainId, string tokenOld, string tokenNew, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(tokenOld, nameof(tokenOld));
            Check.NotNullOrWhiteSpace(tokenNew, nameof(tokenNew));
            Check.Length(extendedInformation, nameof(extendedInformation), UserTokenConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserTokenConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserTokenConsts.StatusMaxLength);

            var userToken = new UserToken(
             GuidGenerator.Create(),
             userMainId, tokenOld, tokenNew, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userTokenRepository.InsertAsync(userToken);
        }

        public async Task<UserToken> UpdateAsync(
            Guid id,
            Guid userMainId, string tokenOld, string tokenNew, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(tokenOld, nameof(tokenOld));
            Check.NotNullOrWhiteSpace(tokenNew, nameof(tokenNew));
            Check.Length(extendedInformation, nameof(extendedInformation), UserTokenConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserTokenConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserTokenConsts.StatusMaxLength);

            var userToken = await _userTokenRepository.GetAsync(id);

            userToken.UserMainId = userMainId;
            userToken.TokenOld = tokenOld;
            userToken.TokenNew = tokenNew;
            userToken.ExtendedInformation = extendedInformation;
            userToken.DateA = dateA;
            userToken.DateD = dateD;
            userToken.Sort = sort;
            userToken.Note = note;
            userToken.Status = status;

            userToken.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _userTokenRepository.UpdateAsync(userToken);
        }

    }
}