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

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeDrvingLicense()
        {

        }

        public ResumeDrvingLicense(Guid id, Guid resumeMainId, string drvingLicenseCode, bool haveDrvingLicense, bool haveCar, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(drvingLicenseCode, nameof(drvingLicenseCode));
            Check.Length(drvingLicenseCode, nameof(drvingLicenseCode), ResumeDrvingLicenseConsts.DrvingLicenseCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDrvingLicenseConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeDrvingLicenseConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeDrvingLicenseConsts.StatusMaxLength, 0);
            ResumeMainId = resumeMainId;
            DrvingLicenseCode = drvingLicenseCode;
            HaveDrvingLicense = haveDrvingLicense;
            HaveCar = haveCar;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}