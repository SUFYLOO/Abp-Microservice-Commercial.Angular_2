using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareTags
{
    public class ShareTag : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string ColorCode { get; set; }

        [NotNull]
        public virtual string Key1 { get; set; }

        [NotNull]
        public virtual string Key2 { get; set; }

        [NotNull]
        public virtual string Key3 { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string TagCategoryCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ShareTag()
        {

        }

        public ShareTag(Guid id, string colorCode, string key1, string key2, string key3, string name, string tagCategoryCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(colorCode, nameof(colorCode));
            Check.Length(colorCode, nameof(colorCode), ShareTagConsts.ColorCodeMaxLength, 0);
            Check.NotNull(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareTagConsts.Key1MaxLength, 0);
            Check.NotNull(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareTagConsts.Key2MaxLength, 0);
            Check.NotNull(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareTagConsts.Key3MaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ShareTagConsts.NameMaxLength, 0);
            Check.NotNull(tagCategoryCode, nameof(tagCategoryCode));
            Check.Length(tagCategoryCode, nameof(tagCategoryCode), ShareTagConsts.TagCategoryCodeMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ShareTagConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareTagConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareTagConsts.NoteMaxLength, 0);
            ColorCode = colorCode;
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Name = name;
            TagCategoryCode = tagCategoryCode;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}