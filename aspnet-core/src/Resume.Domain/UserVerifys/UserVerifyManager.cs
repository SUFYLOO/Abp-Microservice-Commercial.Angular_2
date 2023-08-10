using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.UserVerifys
{
    public class UserVerifyManager : DomainService
    {
        private readonly IUserVerifyRepository _userVerifyRepository;

        public UserVerifyManager(IUserVerifyRepository userVerifyRepository)
        {
            _userVerifyRepository = userVerifyRepository;
        }

        public async Task<UserVerify> CreateAsync(
        string verifyId, string verifyCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), UserVerifyConsts.VerifyIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), UserVerifyConsts.VerifyCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserVerifyConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserVerifyConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserVerifyConsts.NoteMaxLength);

            var userVerify = new UserVerify(

             verifyId, verifyCode, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _userVerifyRepository.InsertAsync(userVerify);
        }

        public async Task<UserVerify> UpdateAsync(
            long id,
            string verifyId, string verifyCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), UserVerifyConsts.VerifyIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), UserVerifyConsts.VerifyCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserVerifyConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserVerifyConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserVerifyConsts.NoteMaxLength);

            var userVerify = await _userVerifyRepository.GetAsync(id);

            userVerify.VerifyId = verifyId;
            userVerify.VerifyCode = verifyCode;
            userVerify.DateA = dateA;
            userVerify.DateD = dateD;
            userVerify.Sort = sort;
            userVerify.Status = status;
            userVerify.ExtendedInformation = extendedInformation;
            userVerify.Note = note;

            return await _userVerifyRepository.UpdateAsync(userVerify);
        }

    }
}