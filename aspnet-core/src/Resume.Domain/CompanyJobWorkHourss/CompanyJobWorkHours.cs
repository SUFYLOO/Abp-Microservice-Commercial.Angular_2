using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobWorkHourss
{
    public class CompanyJobWorkHours : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [NotNull]
        public virtual string WorkHoursCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobWorkHours()
        {

        }

        public CompanyJobWorkHours(Guid id, Guid companyMainId, Guid companyJobId, string workHoursCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(workHoursCode, nameof(workHoursCode));
            Check.Length(workHoursCode, nameof(workHoursCode), CompanyJobWorkHoursConsts.WorkHoursCodeMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobWorkHoursConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobWorkHoursConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            WorkHoursCode = workHoursCode;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}