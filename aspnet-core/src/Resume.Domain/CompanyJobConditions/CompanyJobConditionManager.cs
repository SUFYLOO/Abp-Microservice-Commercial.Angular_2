using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

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
        Guid companyMainId, Guid companyJobId, string workExperienceYearCode, string educationLevel, string majorDepartmentCategory, string languageCategory, string computerExpertise, string professionalLicense, string drvingLicense, string etcCondition, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
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
            Check.Length(note, nameof(note), CompanyJobConditionConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobConditionConsts.StatusMaxLength);

            var companyJobCondition = new CompanyJobCondition(
             GuidGenerator.Create(),
             companyMainId, companyJobId, workExperienceYearCode, educationLevel, majorDepartmentCategory, languageCategory, computerExpertise, professionalLicense, drvingLicense, etcCondition, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobConditionRepository.InsertAsync(companyJobCondition);
        }

        public async Task<CompanyJobCondition> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string workExperienceYearCode, string educationLevel, string majorDepartmentCategory, string languageCategory, string computerExpertise, string professionalLicense, string drvingLicense, string etcCondition, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
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
            Check.Length(note, nameof(note), CompanyJobConditionConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobConditionConsts.StatusMaxLength);

            var companyJobCondition = await _companyJobConditionRepository.GetAsync(id);

            companyJobCondition.CompanyMainId = companyMainId;
            companyJobCondition.CompanyJobId = companyJobId;
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

            return await _companyJobConditionRepository.UpdateAsync(companyJobCondition);
        }

    }
}