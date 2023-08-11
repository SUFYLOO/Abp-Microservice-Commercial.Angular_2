using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeSkills
{
    public class ResumeSkill : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [CanBeNull]
        public virtual string? ComputerSkills { get; set; }

        [CanBeNull]
        public virtual string? ComputerSkillsEtc { get; set; }

        public virtual int ChineseTypingSpeed { get; set; }

        [NotNull]
        public virtual string ChineseTypingCode { get; set; }

        public virtual int EnglishTypingSpeed { get; set; }

        [CanBeNull]
        public virtual string? ProfessionalLicense { get; set; }

        [CanBeNull]
        public virtual string? ProfessionalLicenseEtc { get; set; }

        [CanBeNull]
        public virtual string? WorkSkills { get; set; }

        [CanBeNull]
        public virtual string? WorkSkillsEtc { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ResumeSkill()
        {

        }

        public ResumeSkill(Guid id, Guid resumeMainId, string computerSkills, string computerSkillsEtc, int chineseTypingSpeed, string chineseTypingCode, int englishTypingSpeed, string professionalLicense, string professionalLicenseEtc, string workSkills, string workSkillsEtc, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.Length(computerSkills, nameof(computerSkills), ResumeSkillConsts.ComputerSkillsMaxLength, 0);
            Check.Length(computerSkillsEtc, nameof(computerSkillsEtc), ResumeSkillConsts.ComputerSkillsEtcMaxLength, 0);
            Check.NotNull(chineseTypingCode, nameof(chineseTypingCode));
            Check.Length(chineseTypingCode, nameof(chineseTypingCode), ResumeSkillConsts.ChineseTypingCodeMaxLength, 0);
            Check.Length(professionalLicense, nameof(professionalLicense), ResumeSkillConsts.ProfessionalLicenseMaxLength, 0);
            Check.Length(professionalLicenseEtc, nameof(professionalLicenseEtc), ResumeSkillConsts.ProfessionalLicenseEtcMaxLength, 0);
            Check.Length(workSkills, nameof(workSkills), ResumeSkillConsts.WorkSkillsMaxLength, 0);
            Check.Length(workSkillsEtc, nameof(workSkillsEtc), ResumeSkillConsts.WorkSkillsEtcMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ResumeSkillConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSkillConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeSkillConsts.NoteMaxLength, 0);
            ResumeMainId = resumeMainId;
            ComputerSkills = computerSkills;
            ComputerSkillsEtc = computerSkillsEtc;
            ChineseTypingSpeed = chineseTypingSpeed;
            ChineseTypingCode = chineseTypingCode;
            EnglishTypingSpeed = englishTypingSpeed;
            ProfessionalLicense = professionalLicense;
            ProfessionalLicenseEtc = professionalLicenseEtc;
            WorkSkills = workSkills;
            WorkSkillsEtc = workSkillsEtc;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}