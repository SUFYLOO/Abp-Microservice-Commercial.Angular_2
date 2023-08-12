using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareDictionarys
{
    public class ShareDictionary : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ShareLanguageId { get; set; }

        public virtual Guid ShareTagId { get; set; }

        [CanBeNull]
        public virtual string? Key1 { get; set; }

        [CanBeNull]
        public virtual string? Key2 { get; set; }

        [CanBeNull]
        public virtual string? Key3 { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ShareDictionary()
        {

        }

        public ShareDictionary(Guid id, Guid shareLanguageId, Guid shareTagId, string key1, string key2, string key3, string name, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(key1, nameof(key1), ShareDictionaryConsts.Key1MaxLength, 0);
            Check.Length(key2, nameof(key2), ShareDictionaryConsts.Key2MaxLength, 0);
            Check.Length(key3, nameof(key3), ShareDictionaryConsts.Key3MaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ShareDictionaryConsts.NameMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDictionaryConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareDictionaryConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ShareDictionaryConsts.StatusMaxLength, 0);
            ShareLanguageId = shareLanguageId;
            ShareTagId = shareTagId;
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Name = name;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}