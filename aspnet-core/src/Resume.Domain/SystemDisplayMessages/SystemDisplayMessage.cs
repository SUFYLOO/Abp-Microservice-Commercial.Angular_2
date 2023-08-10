using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessage : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string DisplayTypeCode { get; set; }

        [NotNull]
        public virtual string TitleContents { get; set; }

        [NotNull]
        public virtual string Contents { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public SystemDisplayMessage()
        {

        }

        public SystemDisplayMessage(Guid id, string displayTypeCode, string titleContents, string contents, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(displayTypeCode, nameof(displayTypeCode));
            Check.Length(displayTypeCode, nameof(displayTypeCode), SystemDisplayMessageConsts.DisplayTypeCodeMaxLength, 0);
            Check.NotNull(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), SystemDisplayMessageConsts.TitleContentsMaxLength, 0);
            Check.NotNull(contents, nameof(contents));
            Check.Length(contents, nameof(contents), SystemDisplayMessageConsts.ContentsMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), SystemDisplayMessageConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemDisplayMessageConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), SystemDisplayMessageConsts.NoteMaxLength, 0);
            DisplayTypeCode = displayTypeCode;
            TitleContents = titleContents;
            Contents = contents;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}