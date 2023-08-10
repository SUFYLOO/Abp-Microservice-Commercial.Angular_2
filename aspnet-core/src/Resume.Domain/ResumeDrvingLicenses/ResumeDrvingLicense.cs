using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicense : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [NotNull]
        public virtual string DrvingLicenseCode { get; set; }

        public virtual bool HaveDrvingLicense { get; set; }

        public virtual bool HaveCar { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ResumeDrvingLicense()
        {

        }

        public ResumeDrvingLicense(Guid id, Guid resumeMainId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ResumeDrvingLicenseConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDrvingLicenseConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeDrvingLicenseConsts.NoteMaxLength, 0);
            ResumeMainId = resumeMainId;
            DrvingLicenseCode = drvingLicenseCode;
            HaveDrvingLicense = haveDrvingLicense;
            HaveCar = haveCar;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}