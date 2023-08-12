using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobs
{
    public class CompanyJob : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string JobTypeCode { get; set; }

        public virtual bool JobOpen { get; set; }

        [NotNull]
        public virtual string MailTplId { get; set; }

        [NotNull]
        public virtual string SMSTplId { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJob()
        {

        }

        public CompanyJob(Guid id, Guid companyMainId, string name, string jobTypeCode, bool jobOpen, string mailTplId, string sMSTplId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobConsts.NameMaxLength, 0);
            Check.NotNull(jobTypeCode, nameof(jobTypeCode));
            Check.Length(jobTypeCode, nameof(jobTypeCode), CompanyJobConsts.JobTypeCodeMaxLength, 0);
            Check.NotNull(mailTplId, nameof(mailTplId));
            Check.Length(mailTplId, nameof(mailTplId), CompanyJobConsts.MailTplIdMaxLength, 0);
            Check.NotNull(sMSTplId, nameof(sMSTplId));
            Check.Length(sMSTplId, nameof(sMSTplId), CompanyJobConsts.SMSTplIdMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            Name = name;
            JobTypeCode = jobTypeCode;
            JobOpen = jobOpen;
            MailTplId = mailTplId;
            SMSTplId = sMSTplId;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}