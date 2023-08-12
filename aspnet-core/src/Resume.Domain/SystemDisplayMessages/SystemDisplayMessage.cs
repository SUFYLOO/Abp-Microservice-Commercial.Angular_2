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

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public SystemDisplayMessage()
        {

        }

        public SystemDisplayMessage(Guid id, string displayTypeCode, string titleContents, string contents, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(displayTypeCode, nameof(displayTypeCode));
            Check.Length(displayTypeCode, nameof(displayTypeCode), SystemDisplayMessageConsts.DisplayTypeCodeMaxLength, 0);
            Check.NotNull(titleContents, nameof(titleContents));
            Check.Length(titleContents, nameof(titleContents), SystemDisplayMessageConsts.TitleContentsMaxLength, 0);
            Check.NotNull(contents, nameof(contents));
            Check.Length(contents, nameof(contents), SystemDisplayMessageConsts.ContentsMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemDisplayMessageConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), SystemDisplayMessageConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), SystemDisplayMessageConsts.StatusMaxLength, 0);
            DisplayTypeCode = displayTypeCode;
            TitleContents = titleContents;
            Contents = contents;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}