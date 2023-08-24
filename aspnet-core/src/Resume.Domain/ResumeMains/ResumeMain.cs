using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeMains
{
    public class ResumeMain : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        [NotNull]
        public virtual string ResumeName { get; set; }

        [CanBeNull]
        public virtual string? MarriageCode { get; set; }

        [CanBeNull]
        public virtual string? MilitaryCode { get; set; }

        [CanBeNull]
        public virtual string? DisabilityCategoryCode { get; set; }

        [CanBeNull]
        public virtual string? SpecialIdentityCode { get; set; }

        public virtual bool Main { get; set; }

        [CanBeNull]
        public virtual string? Autobiography1 { get; set; }

        [CanBeNull]
        public virtual string? Autobiography2 { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeMain()
        {

        }

        public ResumeMain(Guid id, Guid userMainId, string resumeName, string marriageCode, string militaryCode, string disabilityCategoryCode, string specialIdentityCode, bool main, string autobiography1 = null, string autobiography2 = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(resumeName, nameof(resumeName));
            Check.Length(resumeName, nameof(resumeName), ResumeMainConsts.ResumeNameMaxLength, 0);
            Check.Length(marriageCode, nameof(marriageCode), ResumeMainConsts.MarriageCodeMaxLength, 0);
            Check.Length(militaryCode, nameof(militaryCode), ResumeMainConsts.MilitaryCodeMaxLength, 0);
            Check.Length(disabilityCategoryCode, nameof(disabilityCategoryCode), ResumeMainConsts.DisabilityCategoryCodeMaxLength, 0);
            Check.Length(specialIdentityCode, nameof(specialIdentityCode), ResumeMainConsts.SpecialIdentityCodeMaxLength, 0);
            Check.Length(autobiography1, nameof(autobiography1), ResumeMainConsts.Autobiography1MaxLength, 0);
            Check.Length(autobiography2, nameof(autobiography2), ResumeMainConsts.Autobiography2MaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeMainConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeMainConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeMainConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
            ResumeName = resumeName;
            MarriageCode = marriageCode;
            MilitaryCode = militaryCode;
            DisabilityCategoryCode = disabilityCategoryCode;
            SpecialIdentityCode = specialIdentityCode;
            Main = main;
            Autobiography1 = autobiography1;
            Autobiography2 = autobiography2;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}