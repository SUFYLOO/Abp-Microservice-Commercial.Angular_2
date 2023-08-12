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

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public UserAccountBind()
        {

        }

        public UserAccountBind(Guid id, Guid userMainId, string thirdPartyTypeCode, string thirdPartyAccountId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(thirdPartyTypeCode, nameof(thirdPartyTypeCode));
            Check.Length(thirdPartyTypeCode, nameof(thirdPartyTypeCode), UserAccountBindConsts.ThirdPartyTypeCodeMaxLength, 0);
            Check.NotNull(thirdPartyAccountId, nameof(thirdPartyAccountId));
            Check.Length(thirdPartyAccountId, nameof(thirdPartyAccountId), UserAccountBindConsts.ThirdPartyAccountIdMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), UserAccountBindConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserAccountBindConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), UserAccountBindConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
            ThirdPartyTypeCode = thirdPartyTypeCode;
            ThirdPartyAccountId = thirdPartyAccountId;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}