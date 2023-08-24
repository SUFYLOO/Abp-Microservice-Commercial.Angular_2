using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareExtendeds
{
    public class ShareExtended : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Key1 { get; set; }

        [CanBeNull]
        public virtual string? Key2 { get; set; }

        [CanBeNull]
        public virtual string? Key3 { get; set; }

        [CanBeNull]
        public virtual string? Key4 { get; set; }

        [CanBeNull]
        public virtual string? Key5 { get; set; }

        public virtual Guid? KeyId { get; set; }

        [CanBeNull]
        public virtual string? FieldValue { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ShareExtended()
        {

        }

        public ShareExtended(Guid id, string key1, string key2, string key3, string key4, string key5, string fieldValue, Guid? keyId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(key1, nameof(key1), ShareExtendedConsts.Key1MaxLength, 0);
            Check.Length(key2, nameof(key2), ShareExtendedConsts.Key2MaxLength, 0);
            Check.Length(key3, nameof(key3), ShareExtendedConsts.Key3MaxLength, 0);
            Check.Length(key4, nameof(key4), ShareExtendedConsts.Key4MaxLength, 0);
            Check.Length(key5, nameof(key5), ShareExtendedConsts.Key5MaxLength, 0);
            Check.Length(fieldValue, nameof(fieldValue), ShareExtendedConsts.FieldValueMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareExtendedConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareExtendedConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ShareExtendedConsts.StatusMaxLength, 0);
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Key4 = key4;
            Key5 = key5;
            FieldValue = fieldValue;
            KeyId = keyId;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}