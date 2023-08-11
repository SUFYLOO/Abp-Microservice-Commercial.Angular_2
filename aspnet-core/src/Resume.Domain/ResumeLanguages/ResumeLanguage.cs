using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguage : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

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

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ResumeLanguage()
        {

        }

        public ResumeLanguage(Guid id, Guid resumeMainId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(languageCategoryCode, nameof(languageCategoryCode));
            Check.Length(languageCategoryCode, nameof(languageCategoryCode), ResumeLanguageConsts.LanguageCategoryCodeMaxLength, 0);
            Check.NotNull(levelSayCode, nameof(levelSayCode));
            Check.Length(levelSayCode, nameof(levelSayCode), ResumeLanguageConsts.LevelSayCodeMaxLength, 0);
            Check.NotNull(levelListenCode, nameof(levelListenCode));
            Check.Length(levelListenCode, nameof(levelListenCode), ResumeLanguageConsts.LevelListenCodeMaxLength, 0);
            Check.NotNull(levelReadCode, nameof(levelReadCode));
            Check.Length(levelReadCode, nameof(levelReadCode), ResumeLanguageConsts.LevelReadCodeMaxLength, 0);
            Check.NotNull(levelWriteCode, nameof(levelWriteCode));
            Check.Length(levelWriteCode, nameof(levelWriteCode), ResumeLanguageConsts.LevelWriteCodeMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ResumeLanguageConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeLanguageConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeLanguageConsts.NoteMaxLength, 0);
            ResumeMainId = resumeMainId;
            LanguageCategoryCode = languageCategoryCode;
            LevelSayCode = levelSayCode;
            LevelListenCode = levelListenCode;
            LevelReadCode = levelReadCode;
            LevelWriteCode = levelWriteCode;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}