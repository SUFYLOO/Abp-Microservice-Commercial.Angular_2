using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareDefaults
{
    public class ShareDefault : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string GroupCode { get; set; }

        [CanBeNull]
        public virtual string? Key1 { get; set; }

        [CanBeNull]
        public virtual string? Key2 { get; set; }

        [CanBeNull]
        public virtual string? Key3 { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string FieldKey { get; set; }

        [CanBeNull]
        public virtual string? FieldValue { get; set; }

        [NotNull]
        public virtual string ColumnTypeCode { get; set; }

        [NotNull]
        public virtual string FormTypeCode { get; set; }

        public virtual bool SystemUse { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ShareDefault()
        {

        }

        public ShareDefault(Guid id, string groupCode, string key1, string key2, string key3, string name, string fieldKey, string fieldValue, string columnTypeCode, string formTypeCode, bool systemUse, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(groupCode, nameof(groupCode));
            Check.Length(groupCode, nameof(groupCode), ShareDefaultConsts.GroupCodeMaxLength, 0);
            Check.Length(key1, nameof(key1), ShareDefaultConsts.Key1MaxLength, 0);
            Check.Length(key2, nameof(key2), ShareDefaultConsts.Key2MaxLength, 0);
            Check.Length(key3, nameof(key3), ShareDefaultConsts.Key3MaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ShareDefaultConsts.NameMaxLength, 0);
            Check.NotNull(fieldKey, nameof(fieldKey));
            Check.Length(fieldKey, nameof(fieldKey), ShareDefaultConsts.FieldKeyMaxLength, 0);
            Check.Length(fieldValue, nameof(fieldValue), ShareDefaultConsts.FieldValueMaxLength, 0);
            Check.NotNull(columnTypeCode, nameof(columnTypeCode));
            Check.Length(columnTypeCode, nameof(columnTypeCode), ShareDefaultConsts.ColumnTypeCodeMaxLength, 0);
            Check.NotNull(formTypeCode, nameof(formTypeCode));
            Check.Length(formTypeCode, nameof(formTypeCode), ShareDefaultConsts.FormTypeCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareDefaultConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareDefaultConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ShareDefaultConsts.StatusMaxLength, 0);
            GroupCode = groupCode;
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Name = name;
            FieldKey = fieldKey;
            FieldValue = fieldValue;
            ColumnTypeCode = columnTypeCode;
            FormTypeCode = formTypeCode;
            SystemUse = systemUse;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}