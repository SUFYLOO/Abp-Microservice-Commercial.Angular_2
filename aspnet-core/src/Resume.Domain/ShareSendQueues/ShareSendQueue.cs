using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ShareSendQueues
{
    public class ShareSendQueue : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Key1 { get; set; }

        [NotNull]
        public virtual string Key2 { get; set; }

        [NotNull]
        public virtual string Key3 { get; set; }

        [NotNull]
        public virtual string SendTypeCode { get; set; }

        [CanBeNull]
        public virtual string? FromAddr { get; set; }

        [NotNull]
        public virtual string ToAddr { get; set; }

        [CanBeNull]
        public virtual string? TitleContents { get; set; }

        [NotNull]
        public virtual string Contents { get; set; }

        public virtual int Retry { get; set; }

        public virtual bool Sucess { get; set; }

        public virtual bool Suspend { get; set; }

        public virtual DateTime DateSend { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ShareSendQueue()
        {

        }

        public ShareSendQueue(Guid id, string key1, string key2, string key3, string sendTypeCode, string fromAddr, string toAddr, string titleContents, string contents, int retry, bool sucess, bool suspend, DateTime dateSend, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(key1, nameof(key1));
            Check.Length(key1, nameof(key1), ShareSendQueueConsts.Key1MaxLength, 0);
            Check.NotNull(key2, nameof(key2));
            Check.Length(key2, nameof(key2), ShareSendQueueConsts.Key2MaxLength, 0);
            Check.NotNull(key3, nameof(key3));
            Check.Length(key3, nameof(key3), ShareSendQueueConsts.Key3MaxLength, 0);
            Check.NotNull(sendTypeCode, nameof(sendTypeCode));
            Check.Length(sendTypeCode, nameof(sendTypeCode), ShareSendQueueConsts.SendTypeCodeMaxLength, 0);
            Check.Length(fromAddr, nameof(fromAddr), ShareSendQueueConsts.FromAddrMaxLength, 0);
            Check.NotNull(toAddr, nameof(toAddr));
            Check.Length(toAddr, nameof(toAddr), ShareSendQueueConsts.ToAddrMaxLength, 0);
            Check.Length(titleContents, nameof(titleContents), ShareSendQueueConsts.TitleContentsMaxLength, 0);
            Check.NotNull(contents, nameof(contents));
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ShareSendQueueConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ShareSendQueueConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ShareSendQueueConsts.NoteMaxLength, 0);
            Key1 = key1;
            Key2 = key2;
            Key3 = key3;
            SendTypeCode = sendTypeCode;
            FromAddr = fromAddr;
            ToAddr = toAddr;
            TitleContents = titleContents;
            Contents = contents;
            Retry = retry;
            Sucess = sucess;
            Suspend = suspend;
            DateSend = dateSend;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}