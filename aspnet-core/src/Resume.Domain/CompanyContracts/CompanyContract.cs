using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyContracts
{
    public class CompanyContract : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        [NotNull]
        public virtual string PlanCode { get; set; }

        public virtual int PointsTotal { get; set; }

        public virtual int PointsPay { get; set; }

        public virtual int PointsGift { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyContract()
        {

        }

        public CompanyContract(Guid id, Guid companyMainId, string planCode, int pointsTotal, int pointsPay, int pointsGift, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(planCode, nameof(planCode));
            Check.Length(planCode, nameof(planCode), CompanyContractConsts.PlanCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyContractConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyContractConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyContractConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            PlanCode = planCode;
            PointsTotal = pointsTotal;
            PointsPay = pointsPay;
            PointsGift = pointsGift;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}