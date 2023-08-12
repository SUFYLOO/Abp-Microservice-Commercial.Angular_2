using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareMessageTpls
{
    public class ShareMessageTpl : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Key1 { get; set; }

        [CanBeNull]
        public virtual string? Key2 { get; set; }

        [NotNull]
        public virtual string Key3 { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Statement { get; set; }

        [NotNull]
        public virtual string TitleContents { get; set; }

        [CanBeNull]
        public virtual string? ContentMail { get; set; }

        [CanBeNull]
        public virtual string? ContentSMS { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ShareMessageTpl()
        {

        }

        public ShareMessageTpl(Guid id, string key1, string key2, string key3, string name, string statement, string titleContents, string contentMail, string contentSMS, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(key1, nameof(key1), ShareMessageTplConsts.Key1MaxLength, 0);
            Check.Length(key2, nameof(key2), ShareMessageTplConsts.Key2MaxLength, 0);
            Check.NotNull(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareMessageTplConsts.Key3MaxLength, 0);
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ShareMessageTplConsts.NameMaxLength, 0);
            Check.Length(statement, nameof(statement), ShareMessageTplConsts.StatementMaxLength, 0);
            Check.NotNull(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), ShareMessageTplConsts.TitleContentsMaxLength, 0);
            Check.Length(contentSMS, nameof(contentSMS), ShareMessageTplConsts.ContentSMSMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareMessageTplConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareMessageTplConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ShareMessageTplConsts.StatusMaxLength, 0);
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            Name = name;
            Statement = statement;
            TitleContents = titleContents;
            ContentMail = contentMail;
            ContentSMS = contentSMS;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}