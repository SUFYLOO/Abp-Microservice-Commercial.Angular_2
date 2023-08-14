using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobOrganizationUnits
{
    public class CompanyJobOrganizationUnit : Entity<Guid>
    {
        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        public virtual Guid OrganizationUnitId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobOrganizationUnit()
        {

        }

        public CompanyJobOrganizationUnit(Guid id, Guid companyMainId, Guid companyJobId, Guid organizationUnitId, string extendedInformation, string note, string status, DateTime? dateA = null, DateTime? dateD = null, int? sort = null)
        {

            Id = id;
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobOrganizationUnitConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobOrganizationUnitConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobOrganizationUnitConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            OrganizationUnitId = organizationUnitId;
            ExtendedInformation = extendedInformation;
            Note = note;
            Status = status;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
        }

    }
}