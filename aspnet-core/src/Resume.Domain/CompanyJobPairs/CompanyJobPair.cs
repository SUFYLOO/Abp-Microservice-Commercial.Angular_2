using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPair : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? PairCondition { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobPair()
        {

        }

        public CompanyJobPair(Guid id, Guid companyMainId, string name, string pairCondition, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobPairConsts.NameMaxLength, 0);
            Check.Length(pairCondition, nameof(pairCondition), CompanyJobPairConsts.PairConditionMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPairConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobPairConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobPairConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            Name = name;
            PairCondition = pairCondition;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}