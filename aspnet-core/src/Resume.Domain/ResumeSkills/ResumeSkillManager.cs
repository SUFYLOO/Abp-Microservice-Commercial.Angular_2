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
        Guid resumeMainId, string computerSkills, string computerSkillsEtc, int chineseTypingSpeed, string chineseTypingCode, int englishTypingSpeed, string professionalLicense, string professionalLicenseEtc, string workSkills, string workSkillsEtc, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(computerSkills, nameof(computerSkills), ResumeSkillConsts.ComputerSkillsMaxLength);
            Check.Length(computerSkillsEtc, nameof(computerSkillsEtc), ResumeSkillConsts.ComputerSkillsEtcMaxLength);
            Check.NotNullOrWhiteSpace(chineseTypingCode, nameof(chineseTypingCode));
            Check.Length(chineseTypingCode, nameof(chineseTypingCode), ResumeSkillConsts.ChineseTypingCodeMaxLength);
            Check.Length(professionalLicense, nameof(professionalLicense), ResumeSkillConsts.ProfessionalLicenseMaxLength);
            Check.Length(professionalLicenseEtc, nameof(professionalLicenseEtc), ResumeSkillConsts.ProfessionalLicenseEtcMaxLength);
            Check.Length(workSkills, nameof(workSkills), ResumeSkillConsts.WorkSkillsMaxLength);
            Check.Length(workSkillsEtc, nameof(workSkillsEtc), ResumeSkillConsts.WorkSkillsEtcMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSkillConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSkillConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeSkillConsts.StatusMaxLength);

            var resumeSkill = new ResumeSkill(
             GuidGenerator.Create(),
             resumeMainId, computerSkills, computerSkillsEtc, chineseTypingSpeed, chineseTypingCode, englishTypingSpeed, professionalLicense, professionalLicenseEtc, workSkills, workSkillsEtc, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeSkillRepository.InsertAsync(resumeSkill);
        }

        public async Task<ResumeSkill> UpdateAsync(
            Guid id,
            Guid resumeMainId, string computerSkills, string computerSkillsEtc, int chineseTypingSpeed, string chineseTypingCode, int englishTypingSpeed, string professionalLicense, string professionalLicenseEtc, string workSkills, string workSkillsEtc, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
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
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSkillConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSkillConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeSkillConsts.StatusMaxLength);

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
            resumeSkill.ExtendedInformation = extendedInformation;
            resumeSkill.DateA = dateA;
            resumeSkill.DateD = dateD;
            resumeSkill.Sort = sort;
            resumeSkill.Note = note;
            resumeSkill.Status = status;

            return await _resumeSkillRepository.UpdateAsync(resumeSkill);
        }

    }
}