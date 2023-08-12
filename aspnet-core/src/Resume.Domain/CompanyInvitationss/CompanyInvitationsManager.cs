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
        Guid companyMainId, bool openAllJob, string userMainName, string userMainLoginMobilePhone, string userMainLoginEmail, string userMainLoginIdentityNo, string sendTypeCode, string sendStatusCode, string resumeFlowStageCode, bool isRead, Guid? companyJobId = null, Guid? userMainId = null, Guid? userCompanyBindId = null, Guid? resumeSnapshotId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
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
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyInvitationsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyInvitationsConsts.StatusMaxLength);

            var companyInvitations = new CompanyInvitations(
             GuidGenerator.Create(),
             companyMainId, openAllJob, userMainName, userMainLoginMobilePhone, userMainLoginEmail, userMainLoginIdentityNo, sendTypeCode, sendStatusCode, resumeFlowStageCode, isRead, companyJobId, userMainId, userCompanyBindId, resumeSnapshotId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyInvitationsRepository.InsertAsync(companyInvitations);
        }

        public async Task<CompanyInvitations> UpdateAsync(
            Guid id,
            Guid companyMainId, bool openAllJob, string userMainName, string userMainLoginMobilePhone, string userMainLoginEmail, string userMainLoginIdentityNo, string sendTypeCode, string sendStatusCode, string resumeFlowStageCode, bool isRead, Guid? companyJobId = null, Guid? userMainId = null, Guid? userCompanyBindId = null, Guid? resumeSnapshotId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
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
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyInvitationsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyInvitationsConsts.StatusMaxLength);

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
            companyInvitations.CompanyJobId = companyJobId;
            companyInvitations.UserMainId = userMainId;
            companyInvitations.UserCompanyBindId = userCompanyBindId;
            companyInvitations.ResumeSnapshotId = resumeSnapshotId;
            companyInvitations.ExtendedInformation = extendedInformation;
            companyInvitations.DateA = dateA;
            companyInvitations.DateD = dateD;
            companyInvitations.Sort = sort;
            companyInvitations.Note = note;
            companyInvitations.Status = status;

            return await _companyInvitationsRepository.UpdateAsync(companyInvitations);
        }

    }
}