using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJob : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        public virtual Guid ResumeExperiencesId { get; set; }

        [NotNull]
        public virtual string JobType { get; set; }

        public virtual int Year { get; set; }

        public virtual int Month { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeExperiencesJob()
        {

        }

        public ResumeExperiencesJob(Guid id, Guid resumeMainId, Guid resumeExperiencesId, string jobType, int year, int month, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(jobType, nameof(jobType));
            Check.Length(jobType, nameof(jobType), ResumeExperiencesJobConsts.JobTypeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeExperiencesJobConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeExperiencesJobConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeExperiencesJobConsts.StatusMaxLength, 0);
            ResumeMainId = resumeMainId;
            ResumeExperiencesId = resumeExperiencesId;
            JobType = jobType;
            Year = year;
            Month = month;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}