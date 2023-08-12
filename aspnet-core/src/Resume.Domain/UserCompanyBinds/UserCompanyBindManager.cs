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
        Guid userMainId, Guid companyMainId, Guid? companyJobId = null, Guid? companyInvitationsId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserCompanyBindConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserCompanyBindConsts.StatusMaxLength);

            var userCompanyBind = new UserCompanyBind(
             GuidGenerator.Create(),
             userMainId, companyMainId, companyJobId, companyInvitationsId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _userCompanyBindRepository.InsertAsync(userCompanyBind);
        }

        public async Task<UserCompanyBind> UpdateAsync(
            Guid id,
            Guid userMainId, Guid companyMainId, Guid? companyJobId = null, Guid? companyInvitationsId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyBindConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), UserCompanyBindConsts.NoteMaxLength);
            Check.Length(status, nameof(status), UserCompanyBindConsts.StatusMaxLength);

            var userCompanyBind = await _userCompanyBindRepository.GetAsync(id);

            userCompanyBind.UserMainId = userMainId;
            userCompanyBind.CompanyMainId = companyMainId;
            userCompanyBind.CompanyJobId = companyJobId;
            userCompanyBind.CompanyInvitationsId = companyInvitationsId;
            userCompanyBind.ExtendedInformation = extendedInformation;
            userCompanyBind.DateA = dateA;
            userCompanyBind.DateD = dateD;
            userCompanyBind.Sort = sort;
            userCompanyBind.Note = note;
            userCompanyBind.Status = status;

            return await _userCompanyBindRepository.UpdateAsync(userCompanyBind);
        }

    }
}