using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserVerifys
{
    public class UserVerify : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string VerifyId { get; set; }

        [NotNull]
        public virtual string VerifyCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public UserVerify()
        {

        }

        public UserVerify(string verifyId, string verifyCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Check.NotNull(verifyId, nameof(verifyId));
            Check.Length(verifyId, nameof(verifyId), UserVerifyConsts.VerifyIdMaxLength, 0);
            Check.NotNull(verifyCode, nameof(verifyCode));
            Check.Length(verifyCode, nameof(verifyCode), UserVerifyConsts.VerifyCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), UserVerifyConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserVerifyConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), UserVerifyConsts.StatusMaxLength, 0);
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