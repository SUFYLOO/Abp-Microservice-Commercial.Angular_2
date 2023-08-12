using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeWorkss
{
    public class ResumeWorks : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Link { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeWorks()
        {

        }

        public ResumeWorks(Guid id, Guid resumeMainId, string name, string link, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ResumeWorksConsts.NameMaxLength, 0);
            Check.Length(link, nameof(link), ResumeWorksConsts.LinkMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeWorksConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeWorksConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeWorksConsts.StatusMaxLength, 0);
            ResumeMainId = resumeMainId;
            Name = name;
            Link = link;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}