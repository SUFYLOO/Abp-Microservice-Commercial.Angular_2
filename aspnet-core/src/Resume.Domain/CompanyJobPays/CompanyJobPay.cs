using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPay : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [NotNull]
        public virtual string JobPayTypeCode { get; set; }

        public virtual DateTime? DateReal { get; set; }

        public virtual bool IsCancel { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public CompanyJobPay()
        {

        }

        public CompanyJobPay(Guid id, Guid companyMainId, Guid companyJobId, string jobPayTypeCode, bool isCancel, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, DateTime? dateReal = null)
        {

            Id = id;
            Check.NotNull(jobPayTypeCode, nameof(jobPayTypeCode));
            Check.Length(jobPayTypeCode, nameof(jobPayTypeCode), CompanyJobPayConsts.JobPayTypeCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobPayConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobPayConsts.NoteMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobPayConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            JobPayTypeCode = jobPayTypeCode;
            IsCancel = isCancel;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
            DateReal = dateReal;
        }

    }
}