using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPair : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid UserMainId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? PairCondition { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public UserCompanyJobPair()
        {

        }

        public UserCompanyJobPair(Guid id, Guid userMainId, string name, string pairCondition, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), UserCompanyJobPairConsts.NameMaxLength, 0);
            Check.Length(pairCondition, nameof(pairCondition), UserCompanyJobPairConsts.PairConditionMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), UserCompanyJobPairConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), UserCompanyJobPairConsts.NoteMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), UserCompanyJobPairConsts.StatusMaxLength, 0);
            UserMainId = userMainId;
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