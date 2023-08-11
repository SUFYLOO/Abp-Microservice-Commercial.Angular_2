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
        public virtual string IndustryCategoryCode { get; set; }

        [NotNull]
        public virtual string JobName { get; set; }

        [CanBeNull]
        public virtual string? JobType { get; set; }

        public virtual bool Working { get; set; }

        [CanBeNull]
        public virtual string? WorkPlaceCode { get; set; }

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

        public virtual DateTime DateA { get; set; }

        public virtual DateTime DateD { get; set; }

        public virtual int Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [NotNull]
        public virtual string Status { get; set; }

        public ResumeExperiences()
        {

        }

        public ResumeExperiences(Guid id, Guid resumeMainId, string name, string workNatureCode, bool hideCompanyName, string industryCategoryCode, string jobName, string jobType, bool working, string workPlaceCode, bool hideWorkSalary, string salaryPayTypeCode, string currencyTypeCode, decimal salary1, decimal salary2, string companyScaleCode, string companyManagementNumberCode, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), ResumeExperiencesConsts.NameMaxLength, 0);
            Check.NotNull(workNatureCode, nameof(workNatureCode));
            Check.Length(workNatureCode, nameof(workNatureCode), ResumeExperiencesConsts.WorkNatureCodeMaxLength, 0);
            Check.NotNull(industryCategoryCode, nameof(industryCategoryCode));
            Check.Length(industryCategoryCode, nameof(industryCategoryCode), ResumeExperiencesConsts.IndustryCategoryCodeMaxLength, 0);
            Check.NotNull(jobName, nameof(jobName));
            Check.Length(jobName, nameof(jobName), ResumeExperiencesConsts.JobNameMaxLength, 0);
            Check.Length(jobType, nameof(jobType), ResumeExperiencesConsts.JobTypeMaxLength, 0);
            Check.Length(workPlaceCode, nameof(workPlaceCode), ResumeExperiencesConsts.WorkPlaceCodeMaxLength, 0);
            Check.NotNull(salaryPayTypeCode, nameof(salaryPayTypeCode));
            Check.Length(salaryPayTypeCode, nameof(salaryPayTypeCode), ResumeExperiencesConsts.SalaryPayTypeCodeMaxLength, 0);
            Check.NotNull(currencyTypeCode, nameof(currencyTypeCode));
            Check.Length(currencyTypeCode, nameof(currencyTypeCode), ResumeExperiencesConsts.CurrencyTypeCodeMaxLength, 0);
            Check.NotNull(companyScaleCode, nameof(companyScaleCode));
            Check.Length(companyScaleCode, nameof(companyScaleCode), ResumeExperiencesConsts.CompanyScaleCodeMaxLength, 0);
            Check.NotNull(companyManagementNumberCode, nameof(companyManagementNumberCode));
            Check.Length(companyManagementNumberCode, nameof(companyManagementNumberCode), ResumeExperiencesConsts.CompanyManagementNumberCodeMaxLength, 0);
            Check.NotNull(status, nameof(status));
            Check.Length(status, nameof(status), ResumeExperiencesConsts.StatusMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeExperiencesConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), ResumeExperiencesConsts.NoteMaxLength, 0);
            ResumeMainId = resumeMainId;
            Name = name;
            WorkNatureCode = workNatureCode;
            HideCompanyName = hideCompanyName;
            IndustryCategoryCode = industryCategoryCode;
            JobName = jobName;
            JobType = jobType;
            Working = working;
            WorkPlaceCode = workPlaceCode;
            HideWorkSalary = hideWorkSalary;
            SalaryPayTypeCode = salaryPayTypeCode;
            CurrencyTypeCode = currencyTypeCode;
            Salary1 = salary1;
            Salary2 = salary2;
            CompanyScaleCode = companyScaleCode;
            CompanyManagementNumberCode = companyManagementNumberCode;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Status = status;
            ExtendedInformation = extendedInformation;
            Note = note;
        }

    }
}