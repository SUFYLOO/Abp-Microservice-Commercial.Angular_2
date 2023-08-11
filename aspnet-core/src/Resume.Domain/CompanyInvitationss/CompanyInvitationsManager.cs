using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyInvitationss
{
    public class CompanyInvitationsManager : DomainService
    {
        private readonly ICompanyInvitationsRepository _companyInvitationsRepository;

        public CompanyInvitationsManager(ICompanyInvitationsRepository companyInvitationsRepository)
        {
            _companyInvitationsRepository = companyInvitationsRepository;
        }

        public async Task<CompanyInvitations> CreateAsync(
        Guid companyMainId, bool openAllJob, string userMainName, string userMainLoginMobilePhone, string userMainLoginEmail, string userMainLoginIdentityNo, string sendTypeCode, string sendStatusCode, string resumeFlowStageCode, bool isRead, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? userMainId = null, Guid? userCompanyBindId = null, Guid? resumeSnapshotId = null, string extendedInformation = null, string note = null)
        {
            Check.Length(userMainName, nameof(userMainName), CompanyInvitationsConsts.UserMainNameMaxLength);
            Check.Length(userMainLoginMobilePhone, nameof(userMainLoginMobilePhone), CompanyInvitationsConsts.UserMainLoginMobilePhoneMaxLength);
            Check.Length(userMainLoginEmail, nameof(userMainLoginEmail), CompanyInvitationsConsts.UserMainLoginEmailMaxLength);
            Check.Length(userMainLoginIdentityNo, nameof(userMainLoginIdentityNo), CompanyInvitationsConsts.UserMainLoginIdentityNoMaxLength);
            Check.NotNullOrWhiteSpace(sendTypeCode, nameof(sendTypeCode));
            Check.Length(sendTypeCode, nameof(sendTypeCode), CompanyInvitationsConsts.SendTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(sendStatusCode, nameof(sendStatusCode));
            Check.Length(sendStatusCode, nameof(sendStatusCode), CompanyInvitationsConsts.SendStatusCodeMaxLength);
            Check.NotNullOrWhiteSpace(resumeFlowStageCode, nameof(resumeFlowStageCode));
            Check.Length(resumeFlowStageCode, nameof(resumeFlowStageCode), CompanyInvitationsConsts.ResumeFlowStageCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyInvitationsConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyInvitationsConsts.NoteMaxLength);

            var companyInvitations = new CompanyInvitations(
             GuidGenerator.Create(),
             companyMainId, openAllJob, userMainName, userMainLoginMobilePhone, userMainLoginEmail, userMainLoginIdentityNo, sendTypeCode, sendStatusCode, resumeFlowStageCode, isRead, dateA, dateD, sort, status, companyJobId, userMainId, userCompanyBindId, resumeSnapshotId, extendedInformation, note
             );

            return await _companyInvitationsRepository.InsertAsync(companyInvitations);
        }

        public async Task<CompanyInvitations> UpdateAsync(
            Guid id,
            Guid companyMainId, bool openAllJob, string userMainName, string userMainLoginMobilePhone, string userMainLoginEmail, string userMainLoginIdentityNo, string sendTypeCode, string sendStatusCode, string resumeFlowStageCode, bool isRead, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? userMainId = null, Guid? userCompanyBindId = null, Guid? resumeSnapshotId = null, string extendedInformation = null, string note = null
        )
        {
            Check.Length(userMainName, nameof(userMainName), CompanyInvitationsConsts.UserMainNameMaxLength);
            Check.Length(userMainLoginMobilePhone, nameof(userMainLoginMobilePhone), CompanyInvitationsConsts.UserMainLoginMobilePhoneMaxLength);
            Check.Length(userMainLoginEmail, nameof(userMainLoginEmail), CompanyInvitationsConsts.UserMainLoginEmailMaxLength);
            Check.Length(userMainLoginIdentityNo, nameof(userMainLoginIdentityNo), CompanyInvitationsConsts.UserMainLoginIdentityNoMaxLength);
            Check.NotNullOrWhiteSpace(sendTypeCode, nameof(sendTypeCode));
            Check.Length(sendTypeCode, nameof(sendTypeCode), CompanyInvitationsConsts.SendTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(sendStatusCode, nameof(sendStatusCode));
            Check.Length(sendStatusCode, nameof(sendStatusCode), CompanyInvitationsConsts.SendStatusCodeMaxLength);
            Check.NotNullOrWhiteSpace(resumeFlowStageCode, nameof(resumeFlowStageCode));
            Check.Length(resumeFlowStageCode, nameof(resumeFlowStageCode), CompanyInvitationsConsts.ResumeFlowStageCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyInvitationsConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyInvitationsConsts.NoteMaxLength);

            var companyInvitations = await _companyInvitationsRepository.GetAsync(id);

            companyInvitations.CompanyMainId = companyMainId;
            companyInvitations.OpenAllJob = openAllJob;
            companyInvitations.UserMainName = userMainName;
            companyInvitations.UserMainLoginMobilePhone = userMainLoginMobilePhone;
            companyInvitations.UserMainLoginEmail = userMainLoginEmail;
            companyInvitations.UserMainLoginIdentityNo = userMainLoginIdentityNo;
            companyInvitations.SendTypeCode = sendTypeCode;
            companyInvitations.SendStatusCode = sendStatusCode;
            companyInvitations.ResumeFlowStageCode = resumeFlowStageCode;
            companyInvitations.IsRead = isRead;
            companyInvitations.DateA = dateA;
            companyInvitations.DateD = dateD;
            companyInvitations.Sort = sort;
            companyInvitations.Status = status;
            companyInvitations.CompanyJobId = companyJobId;
            companyInvitations.UserMainId = userMainId;
            companyInvitations.UserCompanyBindId = userCompanyBindId;
            companyInvitations.ResumeSnapshotId = resumeSnapshotId;
            companyInvitations.ExtendedInformation = extendedInformation;
            companyInvitations.Note = note;

            return await _companyInvitationsRepository.UpdateAsync(companyInvitations);
        }

    }
}