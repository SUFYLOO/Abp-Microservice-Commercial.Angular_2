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
        Guid resumeMainId, string educationLevelCode, string schoolCode, string schoolName, bool night, bool working, string majorDepartmentName, string majorDepartmentCategoryCode, string minorDepartmentName, string minorDepartmentCategoryCode, string graduationCode, bool domestic, string countryCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(educationLevelCode, nameof(educationLevelCode));
            Check.Length(educationLevelCode, nameof(educationLevelCode), ResumeEducationsConsts.EducationLevelCodeMaxLength);
            Check.NotNullOrWhiteSpace(schoolCode, nameof(schoolCode));
            Check.Length(schoolCode, nameof(schoolCode), ResumeEducationsConsts.SchoolCodeMaxLength);
            Check.NotNullOrWhiteSpace(schoolName, nameof(schoolName));
            Check.Length(schoolName, nameof(schoolName), ResumeEducationsConsts.SchoolNameMaxLength);
            Check.NotNullOrWhiteSpace(majorDepartmentName, nameof(majorDepartmentName));
            Check.Length(majorDepartmentName, nameof(majorDepartmentName), ResumeEducationsConsts.MajorDepartmentNameMaxLength);
            Check.NotNullOrWhiteSpace(majorDepartmentCategoryCode, nameof(majorDepartmentCategoryCode));
            Check.Length(majorDepartmentCategoryCode, nameof(majorDepartmentCategoryCode), ResumeEducationsConsts.MajorDepartmentCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentName, nameof(minorDepartmentName));
            Check.Length(minorDepartmentName, nameof(minorDepartmentName), ResumeEducationsConsts.MinorDepartmentNameMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentCategoryCode, nameof(minorDepartmentCategoryCode));
            Check.Length(minorDepartmentCategoryCode, nameof(minorDepartmentCategoryCode), ResumeEducationsConsts.MinorDepartmentCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(graduationCode, nameof(graduationCode));
            Check.Length(graduationCode, nameof(graduationCode), ResumeEducationsConsts.GraduationCodeMaxLength);
            Check.NotNullOrWhiteSpace(countryCode, nameof(countryCode));
            Check.Length(countryCode, nameof(countryCode), ResumeEducationsConsts.CountryCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeEducationsConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeEducationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeEducationsConsts.NoteMaxLength);

            var resumeEducations = new ResumeEducations(
             GuidGenerator.Create(),
             resumeMainId, educationLevelCode, schoolCode, schoolName, night, working, majorDepartmentName, majorDepartmentCategoryCode, minorDepartmentName, minorDepartmentCategoryCode, graduationCode, domestic, countryCode, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _resumeEducationsRepository.InsertAsync(resumeEducations);
        }

        public async Task<ResumeEducations> UpdateAsync(
            Guid id,
            Guid resumeMainId, string educationLevelCode, string schoolCode, string schoolName, bool night, bool working, string majorDepartmentName, string majorDepartmentCategoryCode, string minorDepartmentName, string minorDepartmentCategoryCode, string graduationCode, bool domestic, string countryCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
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
            Check.NotNullOrWhiteSpace(majorDepartmentCategoryCode, nameof(majorDepartmentCategoryCode));
            Check.Length(majorDepartmentCategoryCode, nameof(majorDepartmentCategoryCode), ResumeEducationsConsts.MajorDepartmentCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentName, nameof(minorDepartmentName));
            Check.Length(minorDepartmentName, nameof(minorDepartmentName), ResumeEducationsConsts.MinorDepartmentNameMaxLength);
            Check.NotNullOrWhiteSpace(minorDepartmentCategoryCode, nameof(minorDepartmentCategoryCode));
            Check.Length(minorDepartmentCategoryCode, nameof(minorDepartmentCategoryCode), ResumeEducationsConsts.MinorDepartmentCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(graduationCode, nameof(graduationCode));
            Check.Length(graduationCode, nameof(graduationCode), ResumeEducationsConsts.GraduationCodeMaxLength);
            Check.NotNullOrWhiteSpace(countryCode, nameof(countryCode));
            Check.Length(countryCode, nameof(countryCode), ResumeEducationsConsts.CountryCodeMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeEducationsConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeEducationsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeEducationsConsts.NoteMaxLength);

            var resumeEducations = await _resumeEducationsRepository.GetAsync(id);

            resumeEducations.ResumeMainId = resumeMainId;
            resumeEducations.EducationLevelCode = educationLevelCode;
            resumeEducations.SchoolCode = schoolCode;
            resumeEducations.SchoolName = schoolName;
            resumeEducations.Night = night;
            resumeEducations.Working = working;
            resumeEducations.MajorDepartmentName = majorDepartmentName;
            resumeEducations.MajorDepartmentCategoryCode = majorDepartmentCategoryCode;
            resumeEducations.MinorDepartmentName = minorDepartmentName;
            resumeEducations.MinorDepartmentCategoryCode = minorDepartmentCategoryCode;
            resumeEducations.GraduationCode = graduationCode;
            resumeEducations.Domestic = domestic;
            resumeEducations.CountryCode = countryCode;
            resumeEducations.DateA = dateA;
            resumeEducations.DateD = dateD;
            resumeEducations.Sort = sort;
            resumeEducations.Status = status;
            resumeEducations.ExtendedInformation = extendedInformation;
            resumeEducations.Note = note;

            return await _resumeEducationsRepository.UpdateAsync(resumeEducations);
        }

    }
}