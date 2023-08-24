using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentManager : DomainService
    {
        private readonly ICompanyJobContentRepository _companyJobContentRepository;

        public CompanyJobContentManager(ICompanyJobContentRepository companyJobContentRepository)
        {
            _companyJobContentRepository = companyJobContentRepository;
        }

        public async Task<CompanyJobContent> CreateAsync(
        Guid companyMainId, Guid companyJobId, string name, string jobTypeCode, int peopleRequiredNumber, bool peopleRequiredNumberUnlimited, string jobType, string jobTypeContent, string salaryPayTypeCode, int salaryMin, int salaryMax, bool salaryUp, string workPlace, string workHours, string workHoursCustom, bool workShift, bool workRemoteAllow, string workRemoteTypeCode, string workRemoteDescript, bool businessTrip, string holidaySystemCode, bool dispatched, string workDayCode, string workIdentity, string disabilityCategory, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobContentConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(jobTypeCode, nameof(jobTypeCode));
            Check.Length(jobTypeCode, nameof(jobTypeCode), CompanyJobContentConsts.JobTypeCodeMaxLength);
            Check.Length(jobType, nameof(jobType), CompanyJobContentConsts.JobTypeMaxLength);
            Check.Length(jobTypeContent, nameof(jobTypeContent), CompanyJobContentConsts.JobTypeContentMaxLength);
            Check.NotNullOrWhiteSpace(salaryPayTypeCode, nameof(salaryPayTypeCode));
            Check.Length(salaryPayTypeCode, nameof(salaryPayTypeCode), CompanyJobContentConsts.SalaryPayTypeCodeMaxLength);
            Check.Length(workPlace, nameof(workPlace), CompanyJobContentConsts.WorkPlaceMaxLength);
            Check.Length(workHours, nameof(workHours), CompanyJobContentConsts.WorkHoursMaxLength);
            Check.Length(workHoursCustom, nameof(workHoursCustom), CompanyJobContentConsts.WorkHoursCustomMaxLength);
            Check.NotNullOrWhiteSpace(workRemoteTypeCode, nameof(workRemoteTypeCode));
            Check.Length(workRemoteTypeCode, nameof(workRemoteTypeCode), CompanyJobContentConsts.WorkRemoteTypeCodeMaxLength);
            Check.Length(workRemoteDescript, nameof(workRemoteDescript), CompanyJobContentConsts.WorkRemoteDescriptMaxLength);
            Check.NotNullOrWhiteSpace(holidaySystemCode, nameof(holidaySystemCode));
            Check.Length(holidaySystemCode, nameof(holidaySystemCode), CompanyJobContentConsts.HolidaySystemCodeMaxLength);
            Check.NotNullOrWhiteSpace(workDayCode, nameof(workDayCode));
            Check.Length(workDayCode, nameof(workDayCode), CompanyJobContentConsts.WorkDayCodeMaxLength);
            Check.Length(workIdentity, nameof(workIdentity), CompanyJobContentConsts.WorkIdentityMaxLength);
            Check.Length(disabilityCategory, nameof(disabilityCategory), CompanyJobContentConsts.DisabilityCategoryMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobContentConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobContentConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobContentConsts.StatusMaxLength);

            var companyJobContent = new CompanyJobContent(
             GuidGenerator.Create(),
             companyMainId, companyJobId, name, jobTypeCode, peopleRequiredNumber, peopleRequiredNumberUnlimited, jobType, jobTypeContent, salaryPayTypeCode, salaryMin, salaryMax, salaryUp, workPlace, workHours, workHoursCustom, workShift, workRemoteAllow, workRemoteTypeCode, workRemoteDescript, businessTrip, holidaySystemCode, dispatched, workDayCode, workIdentity, disabilityCategory, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobContentRepository.InsertAsync(companyJobContent);
        }

        public async Task<CompanyJobContent> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string name, string jobTypeCode, int peopleRequiredNumber, bool peopleRequiredNumberUnlimited, string jobType, string jobTypeContent, string salaryPayTypeCode, int salaryMin, int salaryMax, bool salaryUp, string workPlace, string workHours, string workHoursCustom, bool workShift, bool workRemoteAllow, string workRemoteTypeCode, string workRemoteDescript, bool businessTrip, string holidaySystemCode, bool dispatched, string workDayCode, string workIdentity, string disabilityCategory, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobContentConsts.NameMaxLength);
            Check.NotNullOrWhiteSpace(jobTypeCode, nameof(jobTypeCode));
            Check.Length(jobTypeCode, nameof(jobTypeCode), CompanyJobContentConsts.JobTypeCodeMaxLength);
            Check.Length(jobType, nameof(jobType), CompanyJobContentConsts.JobTypeMaxLength);
            Check.Length(jobTypeContent, nameof(jobTypeContent), CompanyJobContentConsts.JobTypeContentMaxLength);
            Check.NotNullOrWhiteSpace(salaryPayTypeCode, nameof(salaryPayTypeCode));
            Check.Length(salaryPayTypeCode, nameof(salaryPayTypeCode), CompanyJobContentConsts.SalaryPayTypeCodeMaxLength);
            Check.Length(workPlace, nameof(workPlace), CompanyJobContentConsts.WorkPlaceMaxLength);
            Check.Length(workHours, nameof(workHours), CompanyJobContentConsts.WorkHoursMaxLength);
            Check.Length(workHoursCustom, nameof(workHoursCustom), CompanyJobContentConsts.WorkHoursCustomMaxLength);
            Check.NotNullOrWhiteSpace(workRemoteTypeCode, nameof(workRemoteTypeCode));
            Check.Length(workRemoteTypeCode, nameof(workRemoteTypeCode), CompanyJobContentConsts.WorkRemoteTypeCodeMaxLength);
            Check.Length(workRemoteDescript, nameof(workRemoteDescript), CompanyJobContentConsts.WorkRemoteDescriptMaxLength);
            Check.NotNullOrWhiteSpace(holidaySystemCode, nameof(holidaySystemCode));
            Check.Length(holidaySystemCode, nameof(holidaySystemCode), CompanyJobContentConsts.HolidaySystemCodeMaxLength);
            Check.NotNullOrWhiteSpace(workDayCode, nameof(workDayCode));
            Check.Length(workDayCode, nameof(workDayCode), CompanyJobContentConsts.WorkDayCodeMaxLength);
            Check.Length(workIdentity, nameof(workIdentity), CompanyJobContentConsts.WorkIdentityMaxLength);
            Check.Length(disabilityCategory, nameof(disabilityCategory), CompanyJobContentConsts.DisabilityCategoryMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobContentConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobContentConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobContentConsts.StatusMaxLength);

            var companyJobContent = await _companyJobContentRepository.GetAsync(id);

            companyJobContent.CompanyMainId = companyMainId;
            companyJobContent.CompanyJobId = companyJobId;
            companyJobContent.Name = name;
            companyJobContent.JobTypeCode = jobTypeCode;
            companyJobContent.PeopleRequiredNumber = peopleRequiredNumber;
            companyJobContent.PeopleRequiredNumberUnlimited = peopleRequiredNumberUnlimited;
            companyJobContent.JobType = jobType;
            companyJobContent.JobTypeContent = jobTypeContent;
            companyJobContent.SalaryPayTypeCode = salaryPayTypeCode;
            companyJobContent.SalaryMin = salaryMin;
            companyJobContent.SalaryMax = salaryMax;
            companyJobContent.SalaryUp = salaryUp;
            companyJobContent.WorkPlace = workPlace;
            companyJobContent.WorkHours = workHours;
            companyJobContent.WorkHoursCustom = workHoursCustom;
            companyJobContent.WorkShift = workShift;
            companyJobContent.WorkRemoteAllow = workRemoteAllow;
            companyJobContent.WorkRemoteTypeCode = workRemoteTypeCode;
            companyJobContent.WorkRemoteDescript = workRemoteDescript;
            companyJobContent.BusinessTrip = businessTrip;
            companyJobContent.HolidaySystemCode = holidaySystemCode;
            companyJobContent.Dispatched = dispatched;
            companyJobContent.WorkDayCode = workDayCode;
            companyJobContent.WorkIdentity = workIdentity;
            companyJobContent.DisabilityCategory = disabilityCategory;
            companyJobContent.ExtendedInformation = extendedInformation;
            companyJobContent.DateA = dateA;
            companyJobContent.DateD = dateD;
            companyJobContent.Sort = sort;
            companyJobContent.Note = note;
            companyJobContent.Status = status;

            return await _companyJobContentRepository.UpdateAsync(companyJobContent);
        }

    }
}