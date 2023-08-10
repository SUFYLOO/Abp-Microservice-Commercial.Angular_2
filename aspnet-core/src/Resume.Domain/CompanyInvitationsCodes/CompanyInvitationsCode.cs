using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCode : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [NotNull]
        public virtual string CompanyInvitationId { get; set; }

        [NotNull]
        public virtual string VerifyId { get; set; }

        [NotNull]
        public virtual string VerifyCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public CompanyInvitationsCode()
        {

        }

        public CompanyInvitationsCode(Guid id, Guid companyMainId, Guid companyJobId, string companyInvitationId, string verifyId, string verifyCode, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {

            Id = id;
            Check.NotNull(companyInvitationId, nameof(companyInvitationId));
            Check.Length(companyInvitationId, nameof(companyInvitationId), CompanyInvitationsCodeConsts.CompanyInvitationIdMaxLength, 0);
            Check.NotNull(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), CompanyInvitationsCodeConsts.VerifyIdMaxLength, 0);
            Check.NotNull(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), CompanyInvitationsCodeConsts.VerifyCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyInvitationsCodeConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyInvitationsCodeConsts.NoteMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), CompanyInvitationsCodeConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            CompanyInvitationId = companyInvitationId;
            VerifyId = verifyId;
            VerifyCode = verifyCode;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}