using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeSkills
{
    public class ResumeSkillManager : DomainService
    {
        private readonly IResumeSkillRepository _resumeSkillRepository;

        public ResumeSkillManager(IResumeSkillRepository resumeSkillRepository)
        {
            _resumeSkillRepository = resumeSkillRepository;
        }

        public async Task<ResumeSkill> CreateAsync(
        Guid resumeMainId, string computerSkills, string computerSkillsEtc, int chineseTypingSpeed, string chineseTypingCode, int englishTypingSpeed, string professionalLicense, string professionalLicenseEtc, string workSkills, string workSkillsEtc, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.Length(computerSkills, nameof(computerSkills), ResumeSkillConsts.ComputerSkillsMaxLength);
            Check.Length(computerSkillsEtc, nameof(computerSkillsEtc), ResumeSkillConsts.ComputerSkillsEtcMaxLength);
            Check.NotNullOrWhiteSpace(chineseTypingCode, nameof(chineseTypingCode));
            Check.Length(chineseTypingCode, nameof(chineseTypingCode), ResumeSkillConsts.ChineseTypingCodeMaxLength);
            Check.Length(professionalLicense, nameof(professionalLicense), ResumeSkillConsts.ProfessionalLicenseMaxLength);
            Check.Length(professionalLicenseEtc, nameof(professionalLicenseEtc), ResumeSkillConsts.ProfessionalLicenseEtcMaxLength);
            Check.Length(workSkills, nameof(workSkills), ResumeSkillConsts.WorkSkillsMaxLength);
            Check.Length(workSkillsEtc, nameof(workSkillsEtc), ResumeSkillConsts.WorkSkillsEtcMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeSkillConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSkillConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSkillConsts.NoteMaxLength);

            var resumeSkill = new ResumeSkill(
             GuidGenerator.Create(),
             resumeMainId, computerSkills, computerSkillsEtc, chineseTypingSpeed, chineseTypingCode, englishTypingSpeed, professionalLicense, professionalLicenseEtc, workSkills, workSkillsEtc, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _resumeSkillRepository.InsertAsync(resumeSkill);
        }

        public async Task<ResumeSkill> UpdateAsync(
            Guid id,
            Guid resumeMainId, string computerSkills, string computerSkillsEtc, int chineseTypingSpeed, string chineseTypingCode, int englishTypingSpeed, string professionalLicense, string professionalLicenseEtc, string workSkills, string workSkillsEtc, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.Length(computerSkills, nameof(computerSkills), ResumeSkillConsts.ComputerSkillsMaxLength);
            Check.Length(computerSkillsEtc, nameof(computerSkillsEtc), ResumeSkillConsts.ComputerSkillsEtcMaxLength);
            Check.NotNullOrWhiteSpace(chineseTypingCode, nameof(chineseTypingCode));
            Check.Length(chineseTypingCode, nameof(chineseTypingCode), ResumeSkillConsts.ChineseTypingCodeMaxLength);
            Check.Length(professionalLicense, nameof(professionalLicense), ResumeSkillConsts.ProfessionalLicenseMaxLength);
            Check.Length(professionalLicenseEtc, nameof(professionalLicenseEtc), ResumeSkillConsts.ProfessionalLicenseEtcMaxLength);
            Check.Length(workSkills, nameof(workSkills), ResumeSkillConsts.WorkSkillsMaxLength);
            Check.Length(workSkillsEtc, nameof(workSkillsEtc), ResumeSkillConsts.WorkSkillsEtcMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeSkillConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSkillConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSkillConsts.NoteMaxLength);

            var resumeSkill = await _resumeSkillRepository.GetAsync(id);

            resumeSkill.ResumeMainId = resumeMainId;
            resumeSkill.ComputerSkills = computerSkills;
            resumeSkill.ComputerSkillsEtc = computerSkillsEtc;
            resumeSkill.ChineseTypingSpeed = chineseTypingSpeed;
            resumeSkill.ChineseTypingCode = chineseTypingCode;
            resumeSkill.EnglishTypingSpeed = englishTypingSpeed;
            resumeSkill.ProfessionalLicense = professionalLicense;
            resumeSkill.ProfessionalLicenseEtc = professionalLicenseEtc;
            resumeSkill.WorkSkills = workSkills;
            resumeSkill.WorkSkillsEtc = workSkillsEtc;
            resumeSkill.DateA = dateA;
            resumeSkill.DateD = dateD;
            resumeSkill.Sort = sort;
            resumeSkill.Status = status;
            resumeSkill.ExtendedInformation = extendedInformation;
            resumeSkill.Note = note;

            return await _resumeSkillRepository.UpdateAsync(resumeSkill);
        }

    }
}