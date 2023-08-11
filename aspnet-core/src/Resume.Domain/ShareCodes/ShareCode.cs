using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareCodes
{
    public class ShareCode : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string GroupCode { get; set; }

        [NotNull]
        public virtual string Key1 { get; set; }

        [NotNull]
        public virtual string Key2 { get; set; }

        [NotNull]
        public virtual string Key3 { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Column1 { get; set; }

        [CanBeNull]
        public virtual string? Column2 { get; set; }

        [CanBeNull]
        public virtual string? Column3 { get; set; }

        public virtual bool SystemUse { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ShareCode()
        {

        }

        public ShareCode(Guid id, string groupCode, string key1, string key2, string key3, string name, string column1, string column2, string column3, bool systemUse, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(groupCode, nameof(groupCode));
            Check.Length(groupCode, nameof(groupCode), ShareCodeConsts.GroupCodeMaxLength, 0);
            Check.NotNull(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareCodeConsts.Key1MaxLength, 0);
            Check.NotNull(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareCodeConsts.Key2MaxLength, 0);
            Check.NotNull(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareCodeConsts.Key3MaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ShareCodeConsts.NameMaxLength, 0);
            Check.Length(column1, nameof(column1), ShareCodeConsts.Column1MaxLength, 0);
            Check.Length(column2, nameof(column2), ShareCodeConsts.Column2MaxLength, 0);
            Check.Length(column3, nameof(column3), ShareCodeConsts.Column3MaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ShareCodeConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareCodeConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareCodeConsts.NoteMaxLength, 0);
            GroupCode = groupCode;
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Name = name;
            Column1 = column1;
            Column2 = column2;
            Column3 = column3;
            SystemUse = systemUse;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}