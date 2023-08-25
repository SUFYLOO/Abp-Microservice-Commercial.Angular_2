using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyJobLanguageConditions
{
    public class CompanyJobLanguageConditionManager : DomainService
    {
        private readonly ICompanyJobLanguageConditionRepository _companyJobLanguageConditionRepository;

        public CompanyJobLanguageConditionManager(ICompanyJobLanguageConditionRepository companyJobLanguageConditionRepository)
        {
            _companyJobLanguageConditionRepository = companyJobLanguageConditionRepository;
        }

        public async Task<CompanyJobLanguageCondition> CreateAsync(
        Guid companyMainId, Guid companyJobId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(languageCategoryCode, nameof(languageCategoryCode));
            Check.Length(languageCategoryCode, nameof(languageCategoryCode), CompanyJobLanguageConditionConsts.LanguageCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelSayCode, nameof(levelSayCode));
            Check.Length(levelSayCode, nameof(levelSayCode), CompanyJobLanguageConditionConsts.LevelSayCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelListenCode, nameof(levelListenCode));
            Check.Length(levelListenCode, nameof(levelListenCode), CompanyJobLanguageConditionConsts.LevelListenCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelReadCode, nameof(levelReadCode));
            Check.Length(levelReadCode, nameof(levelReadCode), CompanyJobLanguageConditionConsts.LevelReadCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelWriteCode, nameof(levelWriteCode));
            Check.Length(levelWriteCode, nameof(levelWriteCode), CompanyJobLanguageConditionConsts.LevelWriteCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobLanguageConditionConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobLanguageConditionConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobLanguageConditionConsts.StatusMaxLength);

            var companyJobLanguageCondition = new CompanyJobLanguageCondition(
             GuidGenerator.Create(),
             companyMainId, companyJobId, languageCategoryCode, levelSayCode, levelListenCode, levelReadCode, levelWriteCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobLanguageConditionRepository.InsertAsync(companyJobLanguageCondition);
        }

        public async Task<CompanyJobLanguageCondition> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string languageCategoryCode, string levelSayCode, string levelListenCode, string levelReadCode, string levelWriteCode, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(languageCategoryCode, nameof(languageCategoryCode));
            Check.Length(languageCategoryCode, nameof(languageCategoryCode), CompanyJobLanguageConditionConsts.LanguageCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelSayCode, nameof(levelSayCode));
            Check.Length(levelSayCode, nameof(levelSayCode), CompanyJobLanguageConditionConsts.LevelSayCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelListenCode, nameof(levelListenCode));
            Check.Length(levelListenCode, nameof(levelListenCode), CompanyJobLanguageConditionConsts.LevelListenCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelReadCode, nameof(levelReadCode));
            Check.Length(levelReadCode, nameof(levelReadCode), CompanyJobLanguageConditionConsts.LevelReadCodeMaxLength);
            Check.NotNullOrWhiteSpace(levelWriteCode, nameof(levelWriteCode));
            Check.Length(levelWriteCode, nameof(levelWriteCode), CompanyJobLanguageConditionConsts.LevelWriteCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobLanguageConditionConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobLanguageConditionConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobLanguageConditionConsts.StatusMaxLength);

            var companyJobLanguageCondition = await _companyJobLanguageConditionRepository.GetAsync(id);

            companyJobLanguageCondition.CompanyMainId = companyMainId;
            companyJobLanguageCondition.CompanyJobId = companyJobId;
            companyJobLanguageCondition.LanguageCategoryCode = languageCategoryCode;
            companyJobLanguageCondition.LevelSayCode = levelSayCode;
            companyJobLanguageCondition.LevelListenCode = levelListenCode;
            companyJobLanguageCondition.LevelReadCode = levelReadCode;
            companyJobLanguageCondition.LevelWriteCode = levelWriteCode;
            companyJobLanguageCondition.ExtendedInformation = extendedInformation;
            companyJobLanguageCondition.DateA = dateA;
            companyJobLanguageCondition.DateD = dateD;
            companyJobLanguageCondition.Sort = sort;
            companyJobLanguageCondition.Note = note;
            companyJobLanguageCondition.Status = status;

            return await _companyJobLanguageConditionRepository.UpdateAsync(companyJobLanguageCondition);
        }

    }
}