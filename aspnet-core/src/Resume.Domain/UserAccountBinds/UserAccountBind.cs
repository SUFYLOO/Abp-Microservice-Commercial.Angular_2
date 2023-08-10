using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserAccountBinds
{
    public class UserAccountBind : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        [NotNull]
        public virtual string ThirdPartyTypeCode { get; set; }

        [NotNull]
        public virtual string ThirdPartyAccountId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public UserAccountBind()
        {

        }

        public UserAccountBind(Guid id, Guid userMainId, string thirdPartyTypeCode, string thirdPartyAccountId, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(thirdPartyTypeCode, nameof(thirdPartyTypeCode));
            Check.Length(thirdPartyTypeCode, nameof(thirdPartyTypeCode), UserAccountBindConsts.ThirdPartyTypeCodeMaxLength, 0);
            Check.NotNull(thirdPartyAccountId, nameof(thirdPartyAccountId));
            Check.Length(thirdPartyAccountId, nameof(thirdPartyAccountId), UserAccountBindConsts.ThirdPartyAccountIdMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), UserAccountBindConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), UserAccountBindConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserAccountBindConsts.NoteMaxLength, 0);
            UserMainId = userMainId;
            ThirdPartyTypeCode = thirdPartyTypeCode;
            ThirdPartyAccountId = thirdPartyAccountId;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}