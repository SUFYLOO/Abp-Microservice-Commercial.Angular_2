using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.SystemValidates
{
    public class SystemValidate : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Param { get; set; }

        public virtual DateTime DateOpen { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public SystemValidate()
        {

        }

        public SystemValidate(Guid id, string param, DateTime dateOpen, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(param, nameof(param));
            Check.Length(param, nameof(param), SystemValidateConsts.ParamMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), SystemValidateConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), SystemValidateConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), SystemValidateConsts.StatusMaxLength, 0);
            Param = param;
            DateOpen = dateOpen;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}