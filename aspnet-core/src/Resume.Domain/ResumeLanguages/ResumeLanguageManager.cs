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
        Guid resumeMainId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
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
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeLanguageConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeLanguageConsts.NoteMaxLength);

            var resumeLanguage = new ResumeLanguage(
             GuidGenerator.Create(),
             resumeMainId, languageCategoryCode, levelSayCode, levelListenCode, levelReadCode, levelWriteCode, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _resumeLanguageRepository.InsertAsync(resumeLanguage);
        }

        public async Task<ResumeLanguage> UpdateAsync(
            Guid id,
            Guid resumeMainId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
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
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeLanguageConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeLanguageConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeLanguageConsts.NoteMaxLength);

            var resumeLanguage = await _resumeLanguageRepository.GetAsync(id);

            resumeLanguage.ResumeMainId = resumeMainId;
            resumeLanguage.LanguageCategoryCode = languageCategoryCode;
            resumeLanguage.LevelSayCode = levelSayCode;
            resumeLanguage.LevelListenCode = levelListenCode;
            resumeLanguage.LevelReadCode = levelReadCode;
            resumeLanguage.LevelWriteCode = levelWriteCode;
            resumeLanguage.DateA = dateA;
            resumeLanguage.DateD = dateD;
            resumeLanguage.Sort = sort;
            resumeLanguage.Status = status;
            resumeLanguage.ExtendedInformation = extendedInformation;
            resumeLanguage.Note = note;

            return await _resumeLanguageRepository.UpdateAsync(resumeLanguage);
        }

    }
}