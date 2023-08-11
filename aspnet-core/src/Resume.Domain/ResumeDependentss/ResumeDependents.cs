using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeDependentss
{
    public class ResumeDependents : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? IdentityNo { get; set; }

        [NotNull]
        public virtual string KinshipCode { get; set; }

        public virtual DateTime BirthDate { get; set; }

        [CanBeNull]
        public virtual string? Address { get; set; }

        [CanBeNull]
        public virtual string? MobilePhone { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ResumeDependents()
        {

        }

        public ResumeDependents(Guid id, Guid resumeMainId, string name, string identityNo, string kinshipCode, DateTime birthDate, DateTime dateA, DateTime dateD, int sort, string status, string address = null, string mobilePhone = null, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ResumeDependentsConsts.NameMaxLength, 0);
            Check.Length(identityNo, nameof(identityNo), ResumeDependentsConsts.IdentityNoMaxLength, 0);
            Check.NotNull(kinshipCode, nameof(kinshipCode));
            Check.Length(kinshipCode, nameof(kinshipCode), ResumeDependentsConsts.KinshipCodeMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ResumeDependentsConsts.StatusMaxLength, 0);
            Check.Length(address, nameof(address), ResumeDependentsConsts.AddressMaxLength, 0);
            Check.Length(mobilePhone, nameof(mobilePhone), ResumeDependentsConsts.MobilePhoneMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeDependentsConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeDependentsConsts.NoteMaxLength, 0);
            ResumeMainId = resumeMainId;
            Name = name;
            IdentityNo = identityNo;
            KinshipCode = kinshipCode;
            BirthDate = birthDate;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            Address = address;
            MobilePhone = mobilePhone;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}