using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.SystemColumns
{
    public class SystemColumn : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid SystemTableId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public virtual bool IsKey { get; set; }

        public virtual bool IsSensitive { get; set; }

        public virtual bool NeedMask { get; set; }

        [CanBeNull]
        public virtual string? DefaultValue { get; set; }

        public virtual bool CheckCode { get; set; }

        [CanBeNull]
        public virtual string? Related { get; set; }

        public virtual bool AllowUpdate { get; set; }

        public virtual bool AllowNull { get; set; }

        public virtual bool AllowEmpty { get; set; }

        public virtual bool AllowExport { get; set; }

        public virtual bool AllowSort { get; set; }

        [NotNull]
        public virtual string ColumnTypeCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public SystemColumn()
        {

        }

        public SystemColumn(Guid id, Guid systemTableId, string name, bool isKey, bool isSensitive, bool needMask, string defaultValue, bool checkCode, string related, bool allowUpdate, bool allowNull, bool allowEmpty, bool allowExport, bool allowSort, string columnTypeCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), SystemColumnConsts.NameMaxLength, 0);
            Check.Length(defaultValue, nameof(defaultValue), SystemColumnConsts.DefaultValueMaxLength, 0);
            Check.Length(related, nameof(related), SystemColumnConsts.RelatedMaxLength, 0);
            Check.NotNull(columnTypeCode, nameof(columnTypeCode));
            Check.Length(columnTypeCode, nameof(columnTypeCode), SystemColumnConsts.ColumnTypeCodeMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), SystemColumnConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemColumnConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), SystemColumnConsts.NoteMaxLength, 0);
            SystemTableId = systemTableId;
            Name = name;
            IsKey = isKey;
            IsSensitive = isSensitive;
            NeedMask = needMask;
            DefaultValue = defaultValue;
            CheckCode = checkCode;
            Related = related;
            AllowUpdate = allowUpdate;
            AllowNull = allowNull;
            AllowEmpty = allowEmpty;
            AllowExport = allowExport;
            AllowSort = allowSort;
            ColumnTypeCode = columnTypeCode;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}