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
        public virtual string? ComputerExpertise { get; set; }

        [CanBeNull]
        public virtual string? ComputerExpertiseEtc { get; set; }

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

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeSkill()
        {

        }

        public ResumeSkill(Guid id, Guid resumeMainId, string computerExpertise, string computerExpertiseEtc, int chineseTypingSpeed, string chineseTypingCode, int englishTypingSpeed, string professionalLicense, string professionalLicenseEtc, string workSkills, string workSkillsEtc, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.Length(computerExpertise, nameof(computerExpertise), ResumeSkillConsts.ComputerExpertiseMaxLength, 0);
            Check.Length(computerExpertiseEtc, nameof(computerExpertiseEtc), ResumeSkillConsts.ComputerExpertiseEtcMaxLength, 0);
            Check.NotNull(chineseTypingCode, nameof(chineseTypingCode));
            Check.Length(chineseTypingCode, nameof(chineseTypingCode), ResumeSkillConsts.ChineseTypingCodeMaxLength, 0);
            Check.Length(professionalLicense, nameof(professionalLicense), ResumeSkillConsts.ProfessionalLicenseMaxLength, 0);
            Check.Length(professionalLicenseEtc, nameof(professionalLicenseEtc), ResumeSkillConsts.ProfessionalLicenseEtcMaxLength, 0);
            Check.Length(workSkills, nameof(workSkills), ResumeSkillConsts.WorkSkillsMaxLength, 0);
            Check.Length(workSkillsEtc, nameof(workSkillsEtc), ResumeSkillConsts.WorkSkillsEtcMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSkillConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeSkillConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeSkillConsts.StatusMaxLength, 0);
            ResumeMainId = resumeMainId;
            ComputerExpertise = computerExpertise;
            ComputerExpertiseEtc = computerExpertiseEtc;
            ChineseTypingSpeed = chineseTypingSpeed;
            ChineseTypingCode = chineseTypingCode;
            EnglishTypingSpeed = englishTypingSpeed;
            ProfessionalLicense = professionalLicense;
            ProfessionalLicenseEtc = professionalLicenseEtc;
            WorkSkills = workSkills;
            WorkSkillsEtc = workSkillsEtc;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}