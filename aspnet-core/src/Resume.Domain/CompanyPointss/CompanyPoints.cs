using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyPointss
{
    public class CompanyPoints : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        [CanBeNull]
        public virtual string? CompanyPointsTypeCode { get; set; }

        public virtual int Points { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public CompanyPoints()
        {

        }

        public CompanyPoints(Guid id, Guid companyMainId, string companyPointsTypeCode, int points, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {

            Id = id;
            Check.Length(companyPointsTypeCode, nameof(companyPointsTypeCode), CompanyPointsConsts.CompanyPointsTypeCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyPointsConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyPointsConsts.NoteMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), CompanyPointsConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyPointsTypeCode = companyPointsTypeCode;
            Points = points;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}