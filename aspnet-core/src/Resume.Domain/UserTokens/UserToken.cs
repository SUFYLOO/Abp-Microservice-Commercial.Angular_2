using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserTokens
{
    public class UserToken : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        [NotNull]
        public virtual string TokenOld { get; set; }

        [NotNull]
        public virtual string TokenNew { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public UserToken()
        {

        }

        public UserToken(Guid id, Guid userMainId, string tokenOld, string tokenNew, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(tokenOld, nameof(tokenOld));
            Check.NotNull(tokenNew, nameof(tokenNew));
            Check.Length(extendedInformation, nameof(extendedInformation), UserTokenConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserTokenConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), UserTokenConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
            TokenOld = tokenOld;
            TokenNew = tokenNew;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}