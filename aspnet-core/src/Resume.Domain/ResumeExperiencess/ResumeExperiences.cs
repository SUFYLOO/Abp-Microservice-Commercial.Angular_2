using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiences : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid ResumeMainId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string WorkNatureCode { get; set; }

        public virtual bool HideCompanyName { get; set; }

        [NotNull]
        public virtual string IndustryCategory { get; set; }

        [NotNull]
        public virtual string JobName { get; set; }

        [CanBeNull]
        public virtual string? JobType { get; set; }

        public virtual bool Working { get; set; }

        [CanBeNull]
        public virtual string? WorkPlace { get; set; }

        public virtual bool HideWorkSalary { get; set; }

        [NotNull]
        public virtual string SalaryPayTypeCode { get; set; }

        [NotNull]
        public virtual string CurrencyTypeCode { get; set; }

        public virtual decimal Salary1 { get; set; }

        public virtual decimal Salary2 { get; set; }

        [NotNull]
        public virtual string CompanyScaleCode { get; set; }

        [NotNull]
        public virtual string CompanyManagementNumberCode { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public ResumeExperiences()
        {

        }

        public ResumeExperiences(Guid id, Guid resumeMainId, string name, string workNatureCode, bool hideCompanyName, string industryCategory, string jobName, string jobType, bool working, string workPlace, bool hideWorkSalary, string salaryPayTypeCode, string currencyTypeCode, decimal salary1, decimal salary2, string companyScaleCode, string companyManagementNumberCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ResumeExperiencesConsts.NameMaxLength, 0);
            Check.NotNull(workNatureCode, nameof(workNatureCode));
            Check.Length(workNatureCode, nameof(workNatureCode), ResumeExperiencesConsts.WorkNatureCodeMaxLength, 0);
            Check.NotNull(industryCategory, nameof(industryCategory));
            Check.Length(industryCategory, nameof(industryCategory), ResumeExperiencesConsts.IndustryCategoryMaxLength, 0);
            Check.NotNull(jobName, nameof(jobName));
            Check.Length(jobName, nameof(jobName), ResumeExperiencesConsts.JobNameMaxLength, 0);
            Check.Length(jobType, nameof(jobType), ResumeExperiencesConsts.JobTypeMaxLength, 0);
            Check.Length(workPlace, nameof(workPlace), ResumeExperiencesConsts.WorkPlaceMaxLength, 0);
            Check.NotNull(salaryPayTypeCode, nameof(salaryPayTypeCode));
            Check.Length(salaryPayTypeCode, nameof(salaryPayTypeCode), ResumeExperiencesConsts.SalaryPayTypeCodeMaxLength, 0);
            Check.NotNull(currencyTypeCode, nameof(currencyTypeCode));
            Check.Length(currencyTypeCode, nameof(currencyTypeCode), ResumeExperiencesConsts.CurrencyTypeCodeMaxLength, 0);
            Check.NotNull(companyScaleCode, nameof(companyScaleCode));
            Check.Length(companyScaleCode, nameof(companyScaleCode), ResumeExperiencesConsts.CompanyScaleCodeMaxLength, 0);
            Check.NotNull(companyManagementNumberCode, nameof(companyManagementNumberCode));
            Check.Length(companyManagementNumberCode, nameof(companyManagementNumberCode), ResumeExperiencesConsts.CompanyManagementNumberCodeMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeExperiencesConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeExperiencesConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), ResumeExperiencesConsts.StatusMaxLength, 0);
            ResumeMainId = resumeMainId;
            Name = name;
            WorkNatureCode = workNatureCode;
            HideCompanyName = hideCompanyName;
            IndustryCategory = industryCategory;
            JobName = jobName;
            JobType = jobType;
            Working = working;
            WorkPlace = workPlace;
            HideWorkSalary = hideWorkSalary;
            SalaryPayTypeCode = salaryPayTypeCode;
            CurrencyTypeCode = currencyTypeCode;
            Salary1 = salary1;
            Salary2 = salary2;
            CompanyScaleCode = companyScaleCode;
            CompanyManagementNumberCode = companyManagementNumberCode;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}