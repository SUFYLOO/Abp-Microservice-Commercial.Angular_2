using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBindManager : DomainService
    {
        private readonly IUserCompanyBindRepository _userCompanyBindRepository;

        public UserCompanyBindManager(IUserCompanyBindRepository userCompanyBindRepository)
        {
            _userCompanyBindRepository = userCompanyBindRepository;
        }

        public async Task<UserCompanyBind> CreateAsync(
        Guid userMainId, Guid companyMainId, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? companyInvitationsId = null, string extendedInformation = null, string note = null)
        {
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyBindConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserCompanyBindConsts.NoteMaxLength);

            var userCompanyBind = new UserCompanyBind(
             GuidGenerator.Create(),
             userMainId, companyMainId, dateA, dateD, sort, status, companyJobId, companyInvitationsId, extendedInformation, note
             );

            return await _userCompanyBindRepository.InsertAsync(userCompanyBind);
        }

        public async Task<UserCompanyBind> UpdateAsync(
            Guid id,
            Guid userMainId, Guid companyMainId, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? companyInvitationsId = null, string extendedInformation = null, string note = null
        )
        {
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyBindConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserCompanyBindConsts.NoteMaxLength);

            var userCompanyBind = await _userCompanyBindRepository.GetAsync(id);

            userCompanyBind.UserMainId = userMainId;
            userCompanyBind.CompanyMainId = companyMainId;
            userCompanyBind.DateA = dateA;
            userCompanyBind.DateD = dateD;
            userCompanyBind.Sort = sort;
            userCompanyBind.Status = status;
            userCompanyBind.CompanyJobId = companyJobId;
            userCompanyBind.CompanyInvitationsId = companyInvitationsId;
            userCompanyBind.ExtendedInformation = extendedInformation;
            userCompanyBind.Note = note;

            return await _userCompanyBindRepository.UpdateAsync(userCompanyBind);
        }

    }
}