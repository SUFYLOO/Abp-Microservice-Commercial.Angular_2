using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeMains
{
    public class ResumeMainManager : DomainService
    {
        private readonly IResumeMainRepository _resumeMainRepository;

        public ResumeMainManager(IResumeMainRepository resumeMainRepository)
        {
            _resumeMainRepository = resumeMainRepository;
        }

        public async Task<ResumeMain> CreateAsync(
        Guid userMainId, string resumeName, string marriageCode, string militaryCode, string disabilityCategoryCode, string specialIdentityCode, bool main, string autobiography1 = null, string autobiography2 = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(resumeName, nameof(resumeName));
            Check.Length(resumeName, nameof(resumeName), ResumeMainConsts.ResumeNameMaxLength);
            Check.Length(marriageCode, nameof(marriageCode), ResumeMainConsts.MarriageCodeMaxLength);
            Check.Length(militaryCode, nameof(militaryCode), ResumeMainConsts.MilitaryCodeMaxLength);
            Check.Length(disabilityCategoryCode, nameof(disabilityCategoryCode), ResumeMainConsts.DisabilityCategoryCodeMaxLength);
            Check.Length(specialIdentityCode, nameof(specialIdentityCode), ResumeMainConsts.SpecialIdentityCodeMaxLength);
            Check.Length(autobiography1, nameof(autobiography1), ResumeMainConsts.Autobiography1MaxLength);
            Check.Length(autobiography2, nameof(autobiography2), ResumeMainConsts.Autobiography2MaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeMainConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeMainConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeMainConsts.StatusMaxLength);

            var resumeMain = new ResumeMain(
             GuidGenerator.Create(),
             userMainId, resumeName, marriageCode, militaryCode, disabilityCategoryCode, specialIdentityCode, main, autobiography1, autobiography2, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeMainRepository.InsertAsync(resumeMain);
        }

        public async Task<ResumeMain> UpdateAsync(
            Guid id,
            Guid userMainId, string resumeName, string marriageCode, string militaryCode, string disabilityCategoryCode, string specialIdentityCode, bool main, string autobiography1 = null, string autobiography2 = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(resumeName, nameof(resumeName));
            Check.Length(resumeName, nameof(resumeName), ResumeMainConsts.ResumeNameMaxLength);
            Check.Length(marriageCode, nameof(marriageCode), ResumeMainConsts.MarriageCodeMaxLength);
            Check.Length(militaryCode, nameof(militaryCode), ResumeMainConsts.MilitaryCodeMaxLength);
            Check.Length(disabilityCategoryCode, nameof(disabilityCategoryCode), ResumeMainConsts.DisabilityCategoryCodeMaxLength);
            Check.Length(specialIdentityCode, nameof(specialIdentityCode), ResumeMainConsts.SpecialIdentityCodeMaxLength);
            Check.Length(autobiography1, nameof(autobiography1), ResumeMainConsts.Autobiography1MaxLength);
            Check.Length(autobiography2, nameof(autobiography2), ResumeMainConsts.Autobiography2MaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeMainConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeMainConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeMainConsts.StatusMaxLength);

            var resumeMain = await _resumeMainRepository.GetAsync(id);

            resumeMain.UserMainId = userMainId;
            resumeMain.ResumeName = resumeName;
            resumeMain.MarriageCode = marriageCode;
            resumeMain.MilitaryCode = militaryCode;
            resumeMain.DisabilityCategoryCode = disabilityCategoryCode;
            resumeMain.SpecialIdentityCode = specialIdentityCode;
            resumeMain.Main = main;
            resumeMain.Autobiography1 = autobiography1;
            resumeMain.Autobiography2 = autobiography2;
            resumeMain.ExtendedInformation = extendedInformation;
            resumeMain.DateA = dateA;
            resumeMain.DateD = dateD;
            resumeMain.Sort = sort;
            resumeMain.Note = note;
            resumeMain.Status = status;

            return await _resumeMainRepository.UpdateAsync(resumeMain);
        }

    }
}