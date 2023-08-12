using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguageManager : DomainService
    {
        private readonly IResumeLanguageRepository _resumeLanguageRepository;

        public ResumeLanguageManager(IResumeLanguageRepository resumeLanguageRepository)
        {
            _resumeLanguageRepository = resumeLanguageRepository;
        }

        public async Task<ResumeLanguage> CreateAsync(
        Guid resumeMainId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(languageCategoryCode, nameof(languageCategoryCode));
            Check.Length(languageCategoryCode, nameof(languageCategoryCode), ResumeLanguageConsts.LanguageCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelSayCode, nameof(levelSayCode));
            Check.Length(levelSayCode, nameof(levelSayCode), ResumeLanguageConsts.LevelSayCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelListenCode, nameof(levelListenCode));
            Check.Length(levelListenCode, nameof(levelListenCode), ResumeLanguageConsts.LevelListenCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelReadCode, nameof(levelReadCode));
            Check.Length(levelReadCode, nameof(levelReadCode), ResumeLanguageConsts.LevelReadCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelWriteCode, nameof(levelWriteCode));
            Check.Length(levelWriteCode, nameof(levelWriteCode), ResumeLanguageConsts.LevelWriteCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeLanguageConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeLanguageConsts.StatusMaxLength);

            var resumeLanguage = new ResumeLanguage(
             GuidGenerator.Create(),
             resumeMainId, languageCategoryCode, levelSayCode, levelListenCode, levelReadCode, levelWriteCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeLanguageRepository.InsertAsync(resumeLanguage);
        }

        public async Task<ResumeLanguage> UpdateAsync(
            Guid id,
            Guid resumeMainId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(languageCategoryCode, nameof(languageCategoryCode));
            Check.Length(languageCategoryCode, nameof(languageCategoryCode), ResumeLanguageConsts.LanguageCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelSayCode, nameof(levelSayCode));
            Check.Length(levelSayCode, nameof(levelSayCode), ResumeLanguageConsts.LevelSayCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelListenCode, nameof(levelListenCode));
            Check.Length(levelListenCode, nameof(levelListenCode), ResumeLanguageConsts.LevelListenCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelReadCode, nameof(levelReadCode));
            Check.Length(levelReadCode, nameof(levelReadCode), ResumeLanguageConsts.LevelReadCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelWriteCode, nameof(levelWriteCode));
            Check.Length(levelWriteCode, nameof(levelWriteCode), ResumeLanguageConsts.LevelWriteCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeLanguageConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeLanguageConsts.StatusMaxLength);

            var resumeLanguage = await _resumeLanguageRepository.GetAsync(id);

            resumeLanguage.ResumeMainId = resumeMainId;
            resumeLanguage.LanguageCategoryCode = languageCategoryCode;
            resumeLanguage.LevelSayCode = levelSayCode;
            resumeLanguage.LevelListenCode = levelListenCode;
            resumeLanguage.LevelReadCode = levelReadCode;
            resumeLanguage.LevelWriteCode = levelWriteCode;
            resumeLanguage.ExtendedInformation = extendedInformation;
            resumeLanguage.DateA = dateA;
            resumeLanguage.DateD = dateD;
            resumeLanguage.Sort = sort;
            resumeLanguage.Note = note;
            resumeLanguage.Status = status;

            return await _resumeLanguageRepository.UpdateAsync(resumeLanguage);
        }

    }
}