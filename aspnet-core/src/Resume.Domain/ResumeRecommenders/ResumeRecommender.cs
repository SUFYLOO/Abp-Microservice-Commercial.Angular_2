using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommender : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? CompanyName { get; set; }

        [CanBeNull]
        public virtual string? JobName { get; set; }

        [CanBeNull]
        public virtual string? MobilePhone { get; set; }

        [CanBeNull]
        public virtual string? OfficePhone { get; set; }

        [CanBeNull]
        public virtual string? Email { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeRecommender()
        {

        }

        public ResumeRecommender(Guid id, Guid resumeMainId, string name, string companyName = null, string jobName = null, string mobilePhone = null, string officePhone = null, string email = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ResumeRecommenderConsts.NameMaxLength, 0);
            Check.Length(companyName, nameof(companyName), ResumeRecommenderConsts.CompanyNameMaxLength, 0);
            Check.Length(jobName, nameof(jobName), ResumeRecommenderConsts.JobNameMaxLength, 0);
            Check.Length(mobilePhone, nameof(mobilePhone), ResumeRecommenderConsts.MobilePhoneMaxLength, 0);
            Check.Length(officePhone, nameof(officePhone), ResumeRecommenderConsts.OfficePhoneMaxLength, 0);
            Check.Length(email, nameof(email), ResumeRecommenderConsts.EmailMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeRecommenderConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeRecommenderConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeRecommenderConsts.StatusMaxLength, 0);
            ResumeMainId = resumeMainId;
            Name = name;
            CompanyName = companyName;
            JobName = jobName;
            MobilePhone = mobilePhone;
            OfficePhone = officePhone;
            Email = email;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}