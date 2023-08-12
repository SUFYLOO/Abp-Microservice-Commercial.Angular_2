using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyUsers
{
    public class CompanyUser : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid UserMainId { get; set; }

        [CanBeNull]
        public virtual string? JobName { get; set; }

        [CanBeNull]
        public virtual string? OfficePhone { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public virtual bool? MatchingReceive { get; set; }

        public CompanyUser()
        {

        }

        public CompanyUser(Guid id, Guid companyMainId, Guid userMainId, string jobName = null, string officePhone = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, bool? matchingReceive = null)
        {

            Id = id;
            Check.Length(jobName, nameof(jobName), CompanyUserConsts.JobNameMaxLength, 0);
            Check.Length(officePhone, nameof(officePhone), CompanyUserConsts.OfficePhoneMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyUserConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyUserConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyUserConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            UserMainId = userMainId;
            JobName = jobName;
            OfficePhone = officePhone;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
            MatchingReceive = matchingReceive;
        }

    }
}