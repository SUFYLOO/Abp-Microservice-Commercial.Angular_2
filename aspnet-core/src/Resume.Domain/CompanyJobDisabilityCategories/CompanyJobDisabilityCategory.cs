using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategory : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [NotNull]
        public virtual string DisabilityCategoryCode { get; set; }

        [CanBeNull]
        public virtual string? DisabilityLevelCode { get; set; }

        public virtual bool DisabilityCertifiedDocumentsNeed { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobDisabilityCategory()
        {

        }

        public CompanyJobDisabilityCategory(Guid id, Guid companyMainId, Guid companyJobId, string disabilityCategoryCode, string disabilityLevelCode, bool disabilityCertifiedDocumentsNeed, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(disabilityCategoryCode, nameof(disabilityCategoryCode));
            Check.Length(disabilityCategoryCode, nameof(disabilityCategoryCode), CompanyJobDisabilityCategoryConsts.DisabilityCategoryCodeMaxLength, 0);
            Check.Length(disabilityLevelCode, nameof(disabilityLevelCode), CompanyJobDisabilityCategoryConsts.DisabilityLevelCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobDisabilityCategoryConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobDisabilityCategoryConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobDisabilityCategoryConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            DisabilityCategoryCode = disabilityCategoryCode;
            DisabilityLevelCode = disabilityLevelCode;
            DisabilityCertifiedDocumentsNeed = disabilityCertifiedDocumentsNeed;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}