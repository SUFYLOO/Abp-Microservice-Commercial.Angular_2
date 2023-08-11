using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeEducationss
{
    public class ResumeEducations : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [NotNull]
        public virtual string EducationLevelCode { get; set; }

        [NotNull]
        public virtual string SchoolCode { get; set; }

        [NotNull]
        public virtual string SchoolName { get; set; }

        public virtual bool Night { get; set; }

        public virtual bool Working { get; set; }

        [NotNull]
        public virtual string MajorDepartmentName { get; set; }

        [NotNull]
        public virtual string MajorDepartmentCategoryCode { get; set; }

        [NotNull]
        public virtual string MinorDepartmentName { get; set; }

        [NotNull]
        public virtual string MinorDepartmentCategoryCode { get; set; }

        [NotNull]
        public virtual string GraduationCode { get; set; }

        public virtual bool Domestic { get; set; }

        [NotNull]
        public virtual string CountryCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ResumeEducations()
        {

        }

        public ResumeEducations(Guid id, Guid resumeMainId, string educationLevelCode, string schoolCode, string schoolName, bool night, bool working, string majorDepartmentName, string majorDepartmentCategoryCode, string minorDepartmentName, string minorDepartmentCategoryCode, string graduationCode, bool domestic, string countryCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(educationLevelCode, nameof(educationLevelCode));
            Check.Length(educationLevelCode, nameof(educationLevelCode), ResumeEducationsConsts.EducationLevelCodeMaxLength, 0);
            Check.NotNull(schoolCode, nameof(schoolCode));
            Check.Length(schoolCode, nameof(schoolCode), ResumeEducationsConsts.SchoolCodeMaxLength, 0);
            Check.NotNull(schoolName, nameof(schoolName));
            Check.Length(schoolName, nameof(schoolName), ResumeEducationsConsts.SchoolNameMaxLength, 0);
            Check.NotNull(majorDepartmentName, nameof(majorDepartmentName));
            Check.Length(majorDepartmentName, nameof(majorDepartmentName), ResumeEducationsConsts.MajorDepartmentNameMaxLength, 0);
            Check.NotNull(majorDepartmentCategoryCode, nameof(majorDepartmentCategoryCode));
            Check.Length(majorDepartmentCategoryCode, nameof(majorDepartmentCategoryCode), ResumeEducationsConsts.MajorDepartmentCategoryCodeMaxLength, 0);
            Check.NotNull(minorDepartmentName, nameof(minorDepartmentName));
            Check.Length(minorDepartmentName, nameof(minorDepartmentName), ResumeEducationsConsts.MinorDepartmentNameMaxLength, 0);
            Check.NotNull(minorDepartmentCategoryCode, nameof(minorDepartmentCategoryCode));
            Check.Length(minorDepartmentCategoryCode, nameof(minorDepartmentCategoryCode), ResumeEducationsConsts.MinorDepartmentCategoryCodeMaxLength, 0);
            Check.NotNull(graduationCode, nameof(graduationCode));
            Check.Length(graduationCode, nameof(graduationCode), ResumeEducationsConsts.GraduationCodeMaxLength, 0);
            Check.NotNull(countryCode, nameof(countryCode));
            Check.Length(countryCode, nameof(countryCode), ResumeEducationsConsts.CountryCodeMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ResumeEducationsConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeEducationsConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeEducationsConsts.NoteMaxLength, 0);
            ResumeMainId = resumeMainId;
            EducationLevelCode = educationLevelCode;
            SchoolCode = schoolCode;
            SchoolName = schoolName;
            Night = night;
            Working = working;
            MajorDepartmentName = majorDepartmentName;
            MajorDepartmentCategoryCode = majorDepartmentCategoryCode;
            MinorDepartmentName = minorDepartmentName;
            MinorDepartmentCategoryCode = minorDepartmentCategoryCode;
            GraduationCode = graduationCode;
            Domestic = domestic;
            CountryCode = countryCode;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}