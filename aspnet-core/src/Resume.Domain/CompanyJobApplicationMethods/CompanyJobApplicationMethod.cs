using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethod : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [CanBeNull]
        public virtual string? OrgDept { get; set; }

        [CanBeNull]
        public virtual string? OrgContactPerson { get; set; }

        [CanBeNull]
        public virtual string? OrgContactMail { get; set; }

        public virtual int ToRespondDay { get; set; }

        public virtual bool ToRespond { get; set; }

        public virtual bool SystemSendResume { get; set; }

        public virtual bool DisplayMail { get; set; }

        [CanBeNull]
        public virtual string? Telephone { get; set; }

        [CanBeNull]
        public virtual string? Personally { get; set; }

        [CanBeNull]
        public virtual string? PersonallyAddress { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public CompanyJobApplicationMethod()
        {

        }

        public CompanyJobApplicationMethod(Guid id, Guid companyMainId, Guid companyJobId, string orgDept, string orgContactPerson, string orgContactMail, int toRespondDay, bool toRespond, bool systemSendResume, bool displayMail, string telephone, string personally, string personallyAddress, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {

            Id = id;
            Check.Length(orgDept, nameof(orgDept), CompanyJobApplicationMethodConsts.OrgDeptMaxLength, 0);
            Check.Length(orgContactPerson, nameof(orgContactPerson), CompanyJobApplicationMethodConsts.OrgContactPersonMaxLength, 0);
            Check.Length(orgContactMail, nameof(orgContactMail), CompanyJobApplicationMethodConsts.OrgContactMailMaxLength, 0);
            Check.Length(telephone, nameof(telephone), CompanyJobApplicationMethodConsts.TelephoneMaxLength, 0);
            Check.Length(personally, nameof(personally), CompanyJobApplicationMethodConsts.PersonallyMaxLength, 0);
            Check.Length(personallyAddress, nameof(personallyAddress), CompanyJobApplicationMethodConsts.PersonallyAddressMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobApplicationMethodConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobApplicationMethodConsts.NoteMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobApplicationMethodConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            OrgDept = orgDept;
            OrgContactPerson = orgContactPerson;
            OrgContactMail = orgContactMail;
            ToRespondDay = toRespondDay;
            ToRespond = toRespond;
            SystemSendResume = systemSendResume;
            DisplayMail = displayMail;
            Telephone = telephone;
            Personally = personally;
            PersonallyAddress = personallyAddress;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}