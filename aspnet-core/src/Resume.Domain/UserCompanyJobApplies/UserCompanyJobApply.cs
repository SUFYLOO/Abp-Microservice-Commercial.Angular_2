using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobApply : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public UserCompanyJobApply()
        {

        }

        public UserCompanyJobApply(Guid id, Guid userMainId, Guid companyJobId, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {

            Id = id;
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobApplyConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserCompanyJobApplyConsts.NoteMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyJobApplyConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
            CompanyJobId = companyJobId;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}