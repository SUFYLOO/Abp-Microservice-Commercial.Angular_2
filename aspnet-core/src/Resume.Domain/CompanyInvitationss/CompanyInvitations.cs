using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyInvitationss
{
    public class CompanyInvitations : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid? CompanyJobId { get; set; }

        public virtual bool OpenAllJob { get; set; }

        public virtual Guid? UserMainId { get; set; }

        [CanBeNull]
        public virtual string? UserMainName { get; set; }

        [CanBeNull]
        public virtual string? UserMainLoginMobilePhone { get; set; }

        [CanBeNull]
        public virtual string? UserMainLoginEmail { get; set; }

        [CanBeNull]
        public virtual string? UserMainLoginIdentityNo { get; set; }

        [NotNull]
        public virtual string SendTypeCode { get; set; }

        [NotNull]
        public virtual string SendStatusCode { get; set; }

        [NotNull]
        public virtual string ResumeFlowStageCode { get; set; }

        public virtual bool IsRead { get; set; }

        public virtual Guid? UserCompanyBindId { get; set; }

        public virtual Guid? ResumeSnapshotId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyInvitations()
        {

        }

        public CompanyInvitations(Guid id, Guid companyMainId, bool openAllJob, string userMainName, string userMainLoginMobilePhone, string userMainLoginEmail, string userMainLoginIdentityNo, string sendTypeCode, string sendStatusCode, string resumeFlowStageCode, bool isRead, Guid? companyJobId = null, Guid? userMainId = null, Guid? userCompanyBindId = null, Guid? resumeSnapshotId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(userMainName, nameof(userMainName), CompanyInvitationsConsts.UserMainNameMaxLength, 0);
            Check.Length(userMainLoginMobilePhone, nameof(userMainLoginMobilePhone), CompanyInvitationsConsts.UserMainLoginMobilePhoneMaxLength, 0);
            Check.Length(userMainLoginEmail, nameof(userMainLoginEmail), CompanyInvitationsConsts.UserMainLoginEmailMaxLength, 0);
            Check.Length(userMainLoginIdentityNo, nameof(userMainLoginIdentityNo), CompanyInvitationsConsts.UserMainLoginIdentityNoMaxLength, 0);
            Check.NotNull(sendTypeCode, nameof(sendTypeCode));
            Check.Length(sendTypeCode, nameof(sendTypeCode), CompanyInvitationsConsts.SendTypeCodeMaxLength, 0);
            Check.NotNull(sendStatusCode, nameof(sendStatusCode));
            Check.Length(sendStatusCode, nameof(sendStatusCode), CompanyInvitationsConsts.SendStatusCodeMaxLength, 0);
            Check.NotNull(resumeFlowStageCode, nameof(resumeFlowStageCode));
            Check.Length(resumeFlowStageCode, nameof(resumeFlowStageCode), CompanyInvitationsConsts.ResumeFlowStageCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyInvitationsConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyInvitationsConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            OpenAllJob = openAllJob;
            UserMainName = userMainName;
            UserMainLoginMobilePhone = userMainLoginMobilePhone;
            UserMainLoginEmail = userMainLoginEmail;
            UserMainLoginIdentityNo = userMainLoginIdentityNo;
            SendTypeCode = sendTypeCode;
            SendStatusCode = sendStatusCode;
            ResumeFlowStageCode = resumeFlowStageCode;
            IsRead = isRead;
            CompanyJobId = companyJobId;
            UserMainId = userMainId;
            UserCompanyBindId = userCompanyBindId;
            ResumeSnapshotId = resumeSnapshotId;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}