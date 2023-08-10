using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyJobConditions
{
    public class CompanyJobConditionManager : DomainService
    {
        private readonly ICompanyJobConditionRepository _companyJobConditionRepository;

        public CompanyJobConditionManager(ICompanyJobConditionRepository companyJobConditionRepository)
        {
            _companyJobConditionRepository = companyJobConditionRepository;
        }

        public async Task<CompanyJobCondition> CreateAsync(
        string companyMainCode, string companyJobCode, string workExperienceYearCode, string educationLevel, string majorDepartmentCategory, string languageCategory, string computerExpertise, string professionalLicense, string drvingLicense, string etcCondition, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {
            Check.NotNullOrWhiteSpace(companyMainCode, nameof(companyMainCode));
            Check.Length(companyMainCode, nameof(companyMainCode), CompanyJobConditionConsts.CompanyMainCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyJobCode, nameof(companyJobCode));
            Check.Length(companyJobCode, nameof(companyJobCode), CompanyJobConditionConsts.CompanyJobCodeMaxLength);
            Check.NotNullOrWhiteSpace(workExperienceYearCode, nameof(workExperienceYearCode));
            Check.Length(workExperienceYearCode, nameof(workExperienceYearCode), CompanyJobConditionConsts.WorkExperienceYearCodeMaxLength);
            Check.Length(educationLevel, nameof(educationLevel), CompanyJobConditionConsts.EducationLevelMaxLength);
            Check.Length(majorDepartmentCategory, nameof(majorDepartmentCategory), CompanyJobConditionConsts.MajorDepartmentCategoryMaxLength);
            Check.Length(languageCategory, nameof(languageCategory), CompanyJobConditionConsts.LanguageCategoryMaxLength);
            Check.Length(computerExpertise, nameof(computerExpertise), CompanyJobConditionConsts.ComputerExpertiseMaxLength);
            Check.Length(professionalLicense, nameof(professionalLicense), CompanyJobConditionConsts.ProfessionalLicenseMaxLength);
            Check.Length(drvingLicense, nameof(drvingLicense), CompanyJobConditionConsts.DrvingLicenseMaxLength);
            Check.Length(etcCondition, nameof(etcCondition), CompanyJobConditionConsts.EtcConditionMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobConditionConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyJobConditionConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobConditionConsts.StatusMaxLength);

            var companyJobCondition = new CompanyJobCondition(
             GuidGenerator.Create(),
             companyMainCode, companyJobCode, workExperienceYearCode, educationLevel, majorDepartmentCategory, languageCategory, computerExpertise, professionalLicense, drvingLicense, etcCondition, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobConditionRepository.InsertAsync(companyJobCondition);
        }

        public async Task<CompanyJobCondition> UpdateAsync(
            Guid id,
            string companyMainCode, string companyJobCode, string workExperienceYearCode, string educationLevel, string majorDepartmentCategory, string languageCategory, string computerExpertise, string professionalLicense, string drvingLicense, string etcCondition, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(companyMainCode, nameof(companyMainCode));
            Check.Length(companyMainCode, nameof(companyMainCode), CompanyJobConditionConsts.CompanyMainCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyJobCode, nameof(companyJobCode));
            Check.Length(companyJobCode, nameof(companyJobCode), CompanyJobConditionConsts.CompanyJobCodeMaxLength);
            Check.NotNullOrWhiteSpace(workExperienceYearCode, nameof(workExperienceYearCode));
            Check.Length(workExperienceYearCode, nameof(workExperienceYearCode), CompanyJobConditionConsts.WorkExperienceYearCodeMaxLength);
            Check.Length(educationLevel, nameof(educationLevel), CompanyJobConditionConsts.EducationLevelMaxLength);
            Check.Length(majorDepartmentCategory, nameof(majorDepartmentCategory), CompanyJobConditionConsts.MajorDepartmentCategoryMaxLength);
            Check.Length(languageCategory, nameof(languageCategory), CompanyJobConditionConsts.LanguageCategoryMaxLength);
            Check.Length(computerExpertise, nameof(computerExpertise), CompanyJobConditionConsts.ComputerExpertiseMaxLength);
            Check.Length(professionalLicense, nameof(professionalLicense), CompanyJobConditionConsts.ProfessionalLicenseMaxLength);
            Check.Length(drvingLicense, nameof(drvingLicense), CompanyJobConditionConsts.DrvingLicenseMaxLength);
            Check.Length(etcCondition, nameof(etcCondition), CompanyJobConditionConsts.EtcConditionMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobConditionConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyJobConditionConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyJobConditionConsts.StatusMaxLength);

            var companyJobCondition = await _companyJobConditionRepository.GetAsync(id);

            companyJobCondition.CompanyMainCode = companyMainCode;
            companyJobCondition.CompanyJobCode = companyJobCode;
            companyJobCondition.WorkExperienceYearCode = workExperienceYearCode;
            companyJobCondition.EducationLevel = educationLevel;
            companyJobCondition.MajorDepartmentCategory = majorDepartmentCategory;
            companyJobCondition.LanguageCategory = languageCategory;
            companyJobCondition.ComputerExpertise = computerExpertise;
            companyJobCondition.ProfessionalLicense = professionalLicense;
            companyJobCondition.DrvingLicense = drvingLicense;
            companyJobCondition.EtcCondition = etcCondition;
            companyJobCondition.ExtendedInformation = extendedInformation;
            companyJobCondition.DateA = dateA;
            companyJobCondition.DateD = dateD;
            companyJobCondition.Sort = sort;
            companyJobCondition.Note = note;
            companyJobCondition.Status = status;

            companyJobCondition.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyJobConditionRepository.UpdateAsync(companyJobCondition);
        }

    }
}