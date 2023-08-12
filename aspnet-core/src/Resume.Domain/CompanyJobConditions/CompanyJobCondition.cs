using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobConditions
{
    public class CompanyJobCondition : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [NotNull]
        public virtual string WorkExperienceYearCode { get; set; }

        [CanBeNull]
        public virtual string? EducationLevel { get; set; }

        [CanBeNull]
        public virtual string? MajorDepartmentCategory { get; set; }

        [CanBeNull]
        public virtual string? LanguageCategory { get; set; }

        [CanBeNull]
        public virtual string? ComputerExpertise { get; set; }

        [CanBeNull]
        public virtual string? ProfessionalLicense { get; set; }

        [CanBeNull]
        public virtual string? DrvingLicense { get; set; }

        [CanBeNull]
        public virtual string? EtcCondition { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobCondition()
        {

        }

        public CompanyJobCondition(Guid id, Guid companyMainId, Guid companyJobId, string workExperienceYearCode, string educationLevel, string majorDepartmentCategory, string languageCategory, string computerExpertise, string professionalLicense, string drvingLicense, string etcCondition, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(workExperienceYearCode, nameof(workExperienceYearCode));
            Check.Length(workExperienceYearCode, nameof(workExperienceYearCode), CompanyJobConditionConsts.WorkExperienceYearCodeMaxLength, 0);
            Check.Length(educationLevel, nameof(educationLevel), CompanyJobConditionConsts.EducationLevelMaxLength, 0);
            Check.Length(majorDepartmentCategory, nameof(majorDepartmentCategory), CompanyJobConditionConsts.MajorDepartmentCategoryMaxLength, 0);
            Check.Length(languageCategory, nameof(languageCategory), CompanyJobConditionConsts.LanguageCategoryMaxLength, 0);
            Check.Length(computerExpertise, nameof(computerExpertise), CompanyJobConditionConsts.ComputerExpertiseMaxLength, 0);
            Check.Length(professionalLicense, nameof(professionalLicense), CompanyJobConditionConsts.ProfessionalLicenseMaxLength, 0);
            Check.Length(drvingLicense, nameof(drvingLicense), CompanyJobConditionConsts.DrvingLicenseMaxLength, 0);
            Check.Length(etcCondition, nameof(etcCondition), CompanyJobConditionConsts.EtcConditionMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobConditionConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobConditionConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobConditionConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            WorkExperienceYearCode = workExperienceYearCode;
            EducationLevel = educationLevel;
            MajorDepartmentCategory = majorDepartmentCategory;
            LanguageCategory = languageCategory;
            ComputerExpertise = computerExpertise;
            ProfessionalLicense = professionalLicense;
            DrvingLicense = drvingLicense;
            EtcCondition = etcCondition;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}