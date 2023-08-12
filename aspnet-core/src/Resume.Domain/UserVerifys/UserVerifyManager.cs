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
        string verifyId, string verifyCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), UserVerifyConsts.VerifyIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), UserVerifyConsts.VerifyCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserVerifyConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserVerifyConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserVerifyConsts.StatusMaxLength);

            var userVerify = new UserVerify(

             verifyId, verifyCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userVerifyRepository.InsertAsync(userVerify);
        }

        public async Task<UserVerify> UpdateAsync(
            long id,
            string verifyId, string verifyCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), UserVerifyConsts.VerifyIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), UserVerifyConsts.VerifyCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserVerifyConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserVerifyConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserVerifyConsts.StatusMaxLength);

            var userVerify = await _userVerifyRepository.GetAsync(id);

            userVerify.VerifyId = verifyId;
            userVerify.VerifyCode = verifyCode;
            userVerify.ExtendedInformation = extendedInformation;
            userVerify.DateA = dateA;
            userVerify.DateD = dateD;
            userVerify.Sort = sort;
            userVerify.Note = note;
            userVerify.Status = status;

            return await _userVerifyRepository.UpdateAsync(userVerify);
        }

    }
}