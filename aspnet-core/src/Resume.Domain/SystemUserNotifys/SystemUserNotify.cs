using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotify : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        [CanBeNull]
        public virtual string? KeyId { get; set; }

        [CanBeNull]
        public virtual string? KeyName { get; set; }

        [NotNull]
        public virtual string NotifyTypeCode { get; set; }

        [NotNull]
        public virtual string AppName { get; set; }

        [NotNull]
        public virtual string AppCode { get; set; }

        [NotNull]
        public virtual string TitleContents { get; set; }

        [NotNull]
        public virtual string Contents { get; set; }

        public virtual bool IsRead { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public SystemUserNotify()
        {

        }

        public SystemUserNotify(Guid id, Guid userMainId, string keyId, string keyName, string notifyTypeCode, string appName, string appCode, string titleContents, string contents, bool isRead, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(keyId, nameof(keyId), SystemUserNotifyConsts.KeyIdMaxLength, 0);
            Check.Length(keyName, nameof(keyName), SystemUserNotifyConsts.KeyNameMaxLength, 0);
            Check.NotNull(notifyTypeCode, nameof(notifyTypeCode));
            Check.Length(notifyTypeCode, nameof(notifyTypeCode), SystemUserNotifyConsts.NotifyTypeCodeMaxLength, 0);
            Check.NotNull(appName, nameof(appName));
            Check.Length(appName, nameof(appName), SystemUserNotifyConsts.AppNameMaxLength, 0);
            Check.NotNull(appCode, nameof(appCode));
            Check.Length(appCode, nameof(appCode), SystemUserNotifyConsts.AppCodeMaxLength, 0);
            Check.NotNull(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), SystemUserNotifyConsts.TitleContentsMaxLength, 0);
            Check.NotNull(contents, nameof(contents));
            Check.Length(contents, nameof(contents), SystemUserNotifyConsts.ContentsMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemUserNotifyConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), SystemUserNotifyConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), SystemUserNotifyConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
            KeyId = keyId;
            KeyName = keyName;
            NotifyTypeCode = notifyTypeCode;
            AppName = appName;
            AppCode = appCode;
            TitleContents = titleContents;
            Contents = contents;
            IsRead = isRead;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}