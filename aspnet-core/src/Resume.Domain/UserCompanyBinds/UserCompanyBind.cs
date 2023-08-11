using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBind : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid? CompanyJobId { get; set; }

        public virtual Guid? CompanyInvitationsId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public UserCompanyBind()
        {

        }

        public UserCompanyBind(Guid id, Guid userMainId, Guid companyMainId, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? companyInvitationsId = null, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyBindConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyBindConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserCompanyBindConsts.NoteMaxLength, 0);
            UserMainId = userMainId;
            CompanyMainId = companyMainId;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            CompanyJobId = companyJobId;
            CompanyInvitationsId = companyInvitationsId;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}