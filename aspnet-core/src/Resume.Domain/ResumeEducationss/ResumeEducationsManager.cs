using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationsManager : DomainService
    {
        private readonly IResumeEducationsRepository _resumeEducationsRepository;

        public ResumeEducationsManager(IResumeEducationsRepository resumeEducationsRepository)
        {
            _resumeEducationsRepository = resumeEducationsRepository;
        }

        public async Task<ResumeEducations> CreateAsync(
        Guid resumeMainId, string educationLevelCode, string schoolCode, string schoolName, bool night, bool working, string majorDepartmentName, string majorDepartmentCategory, string minorDepartmentName, string minorDepartmentCategory, string graduationCode, bool domestic, string countryCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(educationLevelCode, nameof(educationLevelCode));
            Check.Length(educationLevelCode, nameof(educationLevelCode), ResumeEducationsConsts.EducationLevelCodeMaxLength);
            Check.NotNullOrWhiteSpace(schoolCode, nameof(schoolCode));
            Check.Length(schoolCode, nameof(schoolCode), ResumeEducationsConsts.SchoolCodeMaxLength);
            Check.NotNullOrWhiteSpace(schoolName, nameof(schoolName));
            Check.Length(schoolName, nameof(schoolName), ResumeEducationsConsts.SchoolNameMaxLength);
            Check.NotNullOrWhiteSpace(majorDepartmentName, nameof(majorDepartmentName));
            Check.Length(majorDepartmentName, nameof(majorDepartmentName), ResumeEducationsConsts.MajorDepartmentNameMaxLength);
            Check.NotNullOrWhiteSpace(majorDepartmentCategory, nameof(majorDepartmentCategory));
            Check.Length(majorDepartmentCategory, nameof(majorDepartmentCategory), ResumeEducationsConsts.MajorDepartmentCategoryMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentName, nameof(minorDepartmentName));
            Check.Length(minorDepartmentName, nameof(minorDepartmentName), ResumeEducationsConsts.MinorDepartmentNameMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentCategory, nameof(minorDepartmentCategory));
            Check.Length(minorDepartmentCategory, nameof(minorDepartmentCategory), ResumeEducationsConsts.MinorDepartmentCategoryMaxLength);
            Check.NotNullOrWhiteSpace(graduationCode, nameof(graduationCode));
            Check.Length(graduationCode, nameof(graduationCode), ResumeEducationsConsts.GraduationCodeMaxLength);
            Check.NotNullOrWhiteSpace(countryCode, nameof(countryCode));
            Check.Length(countryCode, nameof(countryCode), ResumeEducationsConsts.CountryCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeEducationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeEducationsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeEducationsConsts.StatusMaxLength);

            var resumeEducations = new ResumeEducations(
             GuidGenerator.Create(),
             resumeMainId, educationLevelCode, schoolCode, schoolName, night, working, majorDepartmentName, majorDepartmentCategory, minorDepartmentName, minorDepartmentCategory, graduationCode, domestic, countryCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeEducationsRepository.InsertAsync(resumeEducations);
        }

        public async Task<ResumeEducations> UpdateAsync(
            Guid id,
            Guid resumeMainId, string educationLevelCode, string schoolCode, string schoolName, bool night, bool working, string majorDepartmentName, string majorDepartmentCategory, string minorDepartmentName, string minorDepartmentCategory, string graduationCode, bool domestic, string countryCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(educationLevelCode, nameof(educationLevelCode));
            Check.Length(educationLevelCode, nameof(educationLevelCode), ResumeEducationsConsts.EducationLevelCodeMaxLength);
            Check.NotNullOrWhiteSpace(schoolCode, nameof(schoolCode));
            Check.Length(schoolCode, nameof(schoolCode), ResumeEducationsConsts.SchoolCodeMaxLength);
            Check.NotNullOrWhiteSpace(schoolName, nameof(schoolName));
            Check.Length(schoolName, nameof(schoolName), ResumeEducationsConsts.SchoolNameMaxLength);
            Check.NotNullOrWhiteSpace(majorDepartmentName, nameof(majorDepartmentName));
            Check.Length(majorDepartmentName, nameof(majorDepartmentName), ResumeEducationsConsts.MajorDepartmentNameMaxLength);
            Check.NotNullOrWhiteSpace(majorDepartmentCategory, nameof(majorDepartmentCategory));
            Check.Length(majorDepartmentCategory, nameof(majorDepartmentCategory), ResumeEducationsConsts.MajorDepartmentCategoryMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentName, nameof(minorDepartmentName));
            Check.Length(minorDepartmentName, nameof(minorDepartmentName), ResumeEducationsConsts.MinorDepartmentNameMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentCategory, nameof(minorDepartmentCategory));
            Check.Length(minorDepartmentCategory, nameof(minorDepartmentCategory), ResumeEducationsConsts.MinorDepartmentCategoryMaxLength);
            Check.NotNullOrWhiteSpace(graduationCode, nameof(graduationCode));
            Check.Length(graduationCode, nameof(graduationCode), ResumeEducationsConsts.GraduationCodeMaxLength);
            Check.NotNullOrWhiteSpace(countryCode, nameof(countryCode));
            Check.Length(countryCode, nameof(countryCode), ResumeEducationsConsts.CountryCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeEducationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeEducationsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeEducationsConsts.StatusMaxLength);

            var resumeEducations = await _resumeEducationsRepository.GetAsync(id);

            resumeEducations.ResumeMainId = resumeMainId;
            resumeEducations.EducationLevelCode = educationLevelCode;
            resumeEducations.SchoolCode = schoolCode;
            resumeEducations.SchoolName = schoolName;
            resumeEducations.Night = night;
            resumeEducations.Working = working;
            resumeEducations.MajorDepartmentName = majorDepartmentName;
            resumeEducations.MajorDepartmentCategory = majorDepartmentCategory;
            resumeEducations.MinorDepartmentName = minorDepartmentName;
            resumeEducations.MinorDepartmentCategory = minorDepartmentCategory;
            resumeEducations.GraduationCode = graduationCode;
            resumeEducations.Domestic = domestic;
            resumeEducations.CountryCode = countryCode;
            resumeEducations.ExtendedInformation = extendedInformation;
            resumeEducations.DateA = dateA;
            resumeEducations.DateD = dateD;
            resumeEducations.Sort = sort;
            resumeEducations.Note = note;
            resumeEducations.Status = status;

            return await _resumeEducationsRepository.UpdateAsync(resumeEducations);
        }

    }
}