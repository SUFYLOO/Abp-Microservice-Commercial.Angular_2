using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeSnapshots
{
    public class ResumeSnapshot : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid? CompanyJobId { get; set; }

        [NotNull]
        public virtual string Snapshot { get; set; }

        public virtual Guid? UserCompanyBindId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ResumeSnapshot()
        {

        }

        public ResumeSnapshot(Guid id, Guid userMainId, Guid resumeMainId, Guid companyMainId, string snapshot, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? userCompanyBindId = null, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(snapshot, nameof(snapshot));
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ResumeSnapshotConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSnapshotConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeSnapshotConsts.NoteMaxLength, 0);
            UserMainId = userMainId;
            ResumeMainId = resumeMainId;
            CompanyMainId = companyMainId;
            Snapshot = snapshot;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            CompanyJobId = companyJobId;
            UserCompanyBindId = userCompanyBindId;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}