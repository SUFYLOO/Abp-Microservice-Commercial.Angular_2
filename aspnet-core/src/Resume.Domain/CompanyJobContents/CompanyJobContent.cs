using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContent : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid CompanyMainId { get; set; }

        public virtual Guid CompanyJobId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string JobTypeCode { get; set; }

        public virtual int PeopleRequiredNumber { get; set; }

        public virtual bool PeopleRequiredNumberUnlimited { get; set; }

        [CanBeNull]
        public virtual string? JobType { get; set; }

        [CanBeNull]
        public virtual string? JobTypeContent { get; set; }

        [NotNull]
        public virtual string SalaryPayTypeCode { get; set; }

        public virtual int SalaryMin { get; set; }

        public virtual int SalaryMax { get; set; }

        public virtual bool SalaryUp { get; set; }

        [CanBeNull]
        public virtual string? WorkPlace { get; set; }

        [CanBeNull]
        public virtual string? WorkHours { get; set; }

        [CanBeNull]
        public virtual string? WorkHour { get; set; }

        public virtual bool WorkShift { get; set; }

        public virtual bool WorkRemoteAllow { get; set; }

        [NotNull]
        public virtual string WorkRemoteTypeCode { get; set; }

        [CanBeNull]
        public virtual string? WorkRemote { get; set; }

        [CanBeNull]
        public virtual string? WorkDifferentPlaces { get; set; }

        [NotNull]
        public virtual string HolidaySystemCode { get; set; }

        [NotNull]
        public virtual string WorkDayCode { get; set; }

        [CanBeNull]
        public virtual string? WorkIdentityCode { get; set; }

        [CanBeNull]
        public virtual string? DisabilityCategory { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        public CompanyJobContent()
        {

        }

        public CompanyJobContent(Guid id, Guid companyMainId, Guid companyJobId, string name, string jobTypeCode, int peopleRequiredNumber, bool peopleRequiredNumberUnlimited, string jobType, string jobTypeContent, string salaryPayTypeCode, int salaryMin, int salaryMax, bool salaryUp, string workPlace, string workHours, string workHour, bool workShift, bool workRemoteAllow, string workRemoteTypeCode, string workRemote, string workDifferentPlaces, string holidaySystemCode, string workDayCode, string workIdentityCode, string disabilityCategory, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), CompanyJobContentConsts.NameMaxLength, 0);
            Check.NotNull(jobTypeCode, nameof(jobTypeCode));
            Check.Length(jobTypeCode, nameof(jobTypeCode), CompanyJobContentConsts.JobTypeCodeMaxLength, 0);
            Check.Length(jobType, nameof(jobType), CompanyJobContentConsts.JobTypeMaxLength, 0);
            Check.NotNull(salaryPayTypeCode, nameof(salaryPayTypeCode));
            Check.Length(salaryPayTypeCode, nameof(salaryPayTypeCode), CompanyJobContentConsts.SalaryPayTypeCodeMaxLength, 0);
            Check.Length(workPlace, nameof(workPlace), CompanyJobContentConsts.WorkPlaceMaxLength, 0);
            Check.Length(workHours, nameof(workHours), CompanyJobContentConsts.WorkHoursMaxLength, 0);
            Check.Length(workHour, nameof(workHour), CompanyJobContentConsts.WorkHourMaxLength, 0);
            Check.NotNull(workRemoteTypeCode, nameof(workRemoteTypeCode));
            Check.Length(workRemoteTypeCode, nameof(workRemoteTypeCode), CompanyJobContentConsts.WorkRemoteTypeCodeMaxLength, 0);
            Check.Length(workRemote, nameof(workRemote), CompanyJobContentConsts.WorkRemoteMaxLength, 0);
            Check.Length(workDifferentPlaces, nameof(workDifferentPlaces), CompanyJobContentConsts.WorkDifferentPlacesMaxLength, 0);
            Check.NotNull(holidaySystemCode, nameof(holidaySystemCode));
            Check.Length(holidaySystemCode, nameof(holidaySystemCode), CompanyJobContentConsts.HolidaySystemCodeMaxLength, 0);
            Check.NotNull(workDayCode, nameof(workDayCode));
            Check.Length(workDayCode, nameof(workDayCode), CompanyJobContentConsts.WorkDayCodeMaxLength, 0);
            Check.Length(workIdentityCode, nameof(workIdentityCode), CompanyJobContentConsts.WorkIdentityCodeMaxLength, 0);
            Check.Length(disabilityCategory, nameof(disabilityCategory), CompanyJobContentConsts.DisabilityCategoryMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobContentConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyJobContentConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyJobContentConsts.StatusMaxLength, 0);
            CompanyMainId = companyMainId;
            CompanyJobId = companyJobId;
            Name = name;
            JobTypeCode = jobTypeCode;
            PeopleRequiredNumber = peopleRequiredNumber;
            PeopleRequiredNumberUnlimited = peopleRequiredNumberUnlimited;
            JobType = jobType;
            JobTypeContent = jobTypeContent;
            SalaryPayTypeCode = salaryPayTypeCode;
            SalaryMin = salaryMin;
            SalaryMax = salaryMax;
            SalaryUp = salaryUp;
            WorkPlace = workPlace;
            WorkHours = workHours;
            WorkHour = workHour;
            WorkShift = workShift;
            WorkRemoteAllow = workRemoteAllow;
            WorkRemoteTypeCode = workRemoteTypeCode;
            WorkRemote = workRemote;
            WorkDifferentPlaces = workDifferentPlaces;
            HolidaySystemCode = holidaySystemCode;
            WorkDayCode = workDayCode;
            WorkIdentityCode = workIdentityCode;
            DisabilityCategory = disabilityCategory;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Sort = sort;
            Note = note;
            Status = status;
        }

    }
}