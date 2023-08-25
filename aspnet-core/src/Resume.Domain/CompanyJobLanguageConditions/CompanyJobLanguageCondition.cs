using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobLanguageConditions
{
    public class CompanyJobLanguageCondition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [NotNull]
        public virtual string LanguageCategoryCode { get; set; }

        [NotNull]
        public virtual string LevelSayCode { get; set; }

        [NotNull]
        public virtual string LevelListenCode { get; set; }

        [NotNull]
        public virtual string LevelReadCode { get; set; }

        [NotNull]
        public virtual string LevelWriteCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobLanguageCondition()
        {

        }

        public CompanyJobLanguageCondition(Guid id, Guid companyMainId, Guid companyJobId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(languageCategoryCode, nameof(languageCategoryCode));
            Check.Length(languageCategoryCode, nameof(languageCategoryCode), CompanyJobLanguageConditionConsts.LanguageCategoryCodeMaxLength, 0);
            Check.NotNull(levelSayCode, nameof(levelSayCode));
            Check.Length(levelSayCode, nameof(levelSayCode), CompanyJobLanguageConditionConsts.LevelSayCodeMaxLength, 0);
            Check.NotNull(levelListenCode, nameof(levelListenCode));
            Check.Length(levelListenCode, nameof(levelListenCode), CompanyJobLanguageConditionConsts.LevelListenCodeMaxLength, 0);
            Check.NotNull(levelReadCode, nameof(levelReadCode));
            Check.Length(levelReadCode, nameof(levelReadCode), CompanyJobLanguageConditionConsts.LevelReadCodeMaxLength, 0);
            Check.NotNull(levelWriteCode, nameof(levelWriteCode));
            Check.Length(levelWriteCode, nameof(levelWriteCode), CompanyJobLanguageConditionConsts.LevelWriteCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobLanguageConditionConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobLanguageConditionConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobLanguageConditionConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            LanguageCategoryCode = languageCategoryCode;
            LevelSayCode = levelSayCode;
            LevelListenCode = levelListenCode;
            LevelReadCode = levelReadCode;
            LevelWriteCode = levelWriteCode;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}