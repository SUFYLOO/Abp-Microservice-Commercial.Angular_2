using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencesManager : DomainService
    {
        private readonly IResumeExperiencesRepository _resumeExperiencesRepository;

        public ResumeExperiencesManager(IResumeExperiencesRepository resumeExperiencesRepository)
        {
            _resumeExperiencesRepository = resumeExperiencesRepository;
        }

        public async Task<ResumeExperiences> CreateAsync(
        Guid resumeMainId, string name, string workNatureCode, bool hideCompanyName, string industryCategoryCode, string jobName, string jobType, bool working, string workPlaceCode, bool hideWorkSalary, string salaryPayTypeCode, string currencyTypeCode, decimal salary1, decimal salary2, string companyScaleCode, string companyManagementNumberCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeExperiencesConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(workNatureCode, nameof(workNatureCode));
            Check.Length(workNatureCode, nameof(workNatureCode), ResumeExperiencesConsts.WorkNatureCodeMaxLength);
            Check.NotNullOrWhiteSpace(industryCategoryCode, nameof(industryCategoryCode));
            Check.Length(industryCategoryCode, nameof(industryCategoryCode), ResumeExperiencesConsts.IndustryCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(jobName, nameof(jobName));
            Check.Length(jobName, nameof(jobName), ResumeExperiencesConsts.JobNameMaxLength);
            Check.Length(jobType, nameof(jobType), ResumeExperiencesConsts.JobTypeMaxLength);
            Check.Length(workPlaceCode, nameof(workPlaceCode), ResumeExperiencesConsts.WorkPlaceCodeMaxLength);
            Check.NotNullOrWhiteSpace(salaryPayTypeCode, nameof(salaryPayTypeCode));
            Check.Length(salaryPayTypeCode, nameof(salaryPayTypeCode), ResumeExperiencesConsts.SalaryPayTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(currencyTypeCode, nameof(currencyTypeCode));
            Check.Length(currencyTypeCode, nameof(currencyTypeCode), ResumeExperiencesConsts.CurrencyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyScaleCode, nameof(companyScaleCode));
            Check.Length(companyScaleCode, nameof(companyScaleCode), ResumeExperiencesConsts.CompanyScaleCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyManagementNumberCode, nameof(companyManagementNumberCode));
            Check.Length(companyManagementNumberCode, nameof(companyManagementNumberCode), ResumeExperiencesConsts.CompanyManagementNumberCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeExperiencesConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeExperiencesConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeExperiencesConsts.StatusMaxLength);

            var resumeExperiences = new ResumeExperiences(
             GuidGenerator.Create(),
             resumeMainId, name, workNatureCode, hideCompanyName, industryCategoryCode, jobName, jobType, working, workPlaceCode, hideWorkSalary, salaryPayTypeCode, currencyTypeCode, salary1, salary2, companyScaleCode, companyManagementNumberCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeExperiencesRepository.InsertAsync(resumeExperiences);
        }

        public async Task<ResumeExperiences> UpdateAsync(
            Guid id,
            Guid resumeMainId, string name, string workNatureCode, bool hideCompanyName, string industryCategoryCode, string jobName, string jobType, bool working, string workPlaceCode, bool hideWorkSalary, string salaryPayTypeCode, string currencyTypeCode, decimal salary1, decimal salary2, string companyScaleCode, string companyManagementNumberCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeExperiencesConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(workNatureCode, nameof(workNatureCode));
            Check.Length(workNatureCode, nameof(workNatureCode), ResumeExperiencesConsts.WorkNatureCodeMaxLength);
            Check.NotNullOrWhiteSpace(industryCategoryCode, nameof(industryCategoryCode));
            Check.Length(industryCategoryCode, nameof(industryCategoryCode), ResumeExperiencesConsts.IndustryCategoryCodeMaxLength);
            Check.NotNullOrWhiteSpace(jobName, nameof(jobName));
            Check.Length(jobName, nameof(jobName), ResumeExperiencesConsts.JobNameMaxLength);
            Check.Length(jobType, nameof(jobType), ResumeExperiencesConsts.JobTypeMaxLength);
            Check.Length(workPlaceCode, nameof(workPlaceCode), ResumeExperiencesConsts.WorkPlaceCodeMaxLength);
            Check.NotNullOrWhiteSpace(salaryPayTypeCode, nameof(salaryPayTypeCode));
            Check.Length(salaryPayTypeCode, nameof(salaryPayTypeCode), ResumeExperiencesConsts.SalaryPayTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(currencyTypeCode, nameof(currencyTypeCode));
            Check.Length(currencyTypeCode, nameof(currencyTypeCode), ResumeExperiencesConsts.CurrencyTypeCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyScaleCode, nameof(companyScaleCode));
            Check.Length(companyScaleCode, nameof(companyScaleCode), ResumeExperiencesConsts.CompanyScaleCodeMaxLength);
            Check.NotNullOrWhiteSpace(companyManagementNumberCode, nameof(companyManagementNumberCode));
            Check.Length(companyManagementNumberCode, nameof(companyManagementNumberCode), ResumeExperiencesConsts.CompanyManagementNumberCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeExperiencesConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeExperiencesConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeExperiencesConsts.StatusMaxLength);

            var resumeExperiences = await _resumeExperiencesRepository.GetAsync(id);

            resumeExperiences.ResumeMainId = resumeMainId;
            resumeExperiences.Name = name;
            resumeExperiences.WorkNatureCode = workNatureCode;
            resumeExperiences.HideCompanyName = hideCompanyName;
            resumeExperiences.IndustryCategoryCode = industryCategoryCode;
            resumeExperiences.JobName = jobName;
            resumeExperiences.JobType = jobType;
            resumeExperiences.Working = working;
            resumeExperiences.WorkPlaceCode = workPlaceCode;
            resumeExperiences.HideWorkSalary = hideWorkSalary;
            resumeExperiences.SalaryPayTypeCode = salaryPayTypeCode;
            resumeExperiences.CurrencyTypeCode = currencyTypeCode;
            resumeExperiences.Salary1 = salary1;
            resumeExperiences.Salary2 = salary2;
            resumeExperiences.CompanyScaleCode = companyScaleCode;
            resumeExperiences.CompanyManagementNumberCode = companyManagementNumberCode;
            resumeExperiences.ExtendedInformation = extendedInformation;
            resumeExperiences.DateA = dateA;
            resumeExperiences.DateD = dateD;
            resumeExperiences.Sort = sort;
            resumeExperiences.Note = note;
            resumeExperiences.Status = status;

            return await _resumeExperiencesRepository.UpdateAsync(resumeExperiences);
        }

    }
}