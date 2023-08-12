using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodeManager : DomainService
    {
        private readonly ICompanyInvitationsCodeRepository _companyInvitationsCodeRepository;

        public CompanyInvitationsCodeManager(ICompanyInvitationsCodeRepository companyInvitationsCodeRepository)
        {
            _companyInvitationsCodeRepository = companyInvitationsCodeRepository;
        }

        public async Task<CompanyInvitationsCode> CreateAsync(
        Guid companyMainId, Guid companyJobId, string companyInvitationId, string verifyId, string verifyCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(companyInvitationId, nameof(companyInvitationId));
            Check.Length(companyInvitationId, nameof(companyInvitationId), CompanyInvitationsCodeConsts.CompanyInvitationIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), CompanyInvitationsCodeConsts.VerifyIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), CompanyInvitationsCodeConsts.VerifyCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsCodeConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyInvitationsCodeConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyInvitationsCodeConsts.StatusMaxLength);

            var companyInvitationsCode = new CompanyInvitationsCode(
             GuidGenerator.Create(),
             companyMainId, companyJobId, companyInvitationId, verifyId, verifyCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyInvitationsCodeRepository.InsertAsync(companyInvitationsCode);
        }

        public async Task<CompanyInvitationsCode> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string companyInvitationId, string verifyId, string verifyCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(companyInvitationId, nameof(companyInvitationId));
            Check.Length(companyInvitationId, nameof(companyInvitationId), CompanyInvitationsCodeConsts.CompanyInvitationIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), CompanyInvitationsCodeConsts.VerifyIdMaxLength);
            Check.NotNullOrWhiteSpace(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), CompanyInvitationsCodeConsts.VerifyCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsCodeConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyInvitationsCodeConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyInvitationsCodeConsts.StatusMaxLength);

            var companyInvitationsCode = await _companyInvitationsCodeRepository.GetAsync(id);

            companyInvitationsCode.CompanyMainId = companyMainId;
            companyInvitationsCode.CompanyJobId = companyJobId;
            companyInvitationsCode.CompanyInvitationId = companyInvitationId;
            companyInvitationsCode.VerifyId = verifyId;
            companyInvitationsCode.VerifyCode = verifyCode;
            companyInvitationsCode.ExtendedInformation = extendedInformation;
            companyInvitationsCode.DateA = dateA;
            companyInvitationsCode.DateD = dateD;
            companyInvitationsCode.Sort = sort;
            companyInvitationsCode.Note = note;
            companyInvitationsCode.Status = status;

            companyInvitationsCode.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyInvitationsCodeRepository.UpdateAsync(companyInvitationsCode);
        }

    }
}