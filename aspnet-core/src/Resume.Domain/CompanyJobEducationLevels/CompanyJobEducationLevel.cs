using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevel : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [CanBeNull]
        public virtual string? EducationLevelCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobEducationLevel()
        {

        }

        public CompanyJobEducationLevel(Guid id, Guid companyMainId, Guid companyJobId, string educationLevelCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(educationLevelCode, nameof(educationLevelCode), CompanyJobEducationLevelConsts.EducationLevelCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobEducationLevelConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobEducationLevelConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobEducationLevelConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            EducationLevelCode = educationLevelCode;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}