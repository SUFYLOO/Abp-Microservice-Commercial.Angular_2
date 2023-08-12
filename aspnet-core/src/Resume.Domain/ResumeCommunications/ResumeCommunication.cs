using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeCommunications
{
    public class ResumeCommunication : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [NotNull]
        public virtual string CommunicationCategoryCode { get; set; }

        [NotNull]
        public virtual string CommunicationValue { get; set; }

        public virtual bool Main { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeCommunication()
        {

        }

        public ResumeCommunication(Guid id, Guid resumeMainId, string communicationCategoryCode, string communicationValue, bool main, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(communicationCategoryCode, nameof(communicationCategoryCode));
            Check.Length(communicationCategoryCode, nameof(communicationCategoryCode), ResumeCommunicationConsts.CommunicationCategoryCodeMaxLength, 0);
            Check.NotNull(communicationValue, nameof(communicationValue));
            Check.Length(communicationValue, nameof(communicationValue), ResumeCommunicationConsts.CommunicationValueMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeCommunicationConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeCommunicationConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeCommunicationConsts.StatusMaxLength, 0);
            ResumeMainId = resumeMainId;
            CommunicationCategoryCode = communicationCategoryCode;
            CommunicationValue = communicationValue;
            Main = main;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}