using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareLanguages
{
    public class ShareLanguage : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ShareLanguage()
        {

        }

        public ShareLanguage(Guid id, string name, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ShareLanguageConsts.NameMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ShareLanguageConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareLanguageConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareLanguageConsts.NoteMaxLength, 0);
            Name = name;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}