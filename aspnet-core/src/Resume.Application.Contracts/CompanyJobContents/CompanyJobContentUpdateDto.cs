using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentUpdateDto : IHasConcurrencyStamp
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.JobTypeCodeMaxLength)]
        public string JobTypeCode { get; set; }
        public int PeopleRequiredNumber { get; set; }
        public bool PeopleRequiredNumberUnlimited { get; set; }
        [StringLength(CompanyJobContentConsts.JobTypeMaxLength)]
        public string? JobType { get; set; }
        public string? JobTypeContent { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.SalaryPayTypeCodeMaxLength)]
        public string SalaryPayTypeCode { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public bool SalaryUp { get; set; }
        [StringLength(CompanyJobContentConsts.WorkPlaceMaxLength)]
        public string? WorkPlace { get; set; }
        [StringLength(CompanyJobContentConsts.WorkHoursMaxLength)]
        public string? WorkHours { get; set; }
        [StringLength(CompanyJobContentConsts.WorkHourMaxLength)]
        public string? WorkHour { get; set; }
        public bool WorkShift { get; set; }
        public bool WorkRemoteAllow { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.WorkRemoteTypeCodeMaxLength)]
        public string WorkRemoteTypeCode { get; set; }
        [StringLength(CompanyJobContentConsts.WorkRemoteMaxLength)]
        public string? WorkRemote { get; set; }
        [StringLength(CompanyJobContentConsts.WorkDifferentPlacesMaxLength)]
        public string? WorkDifferentPlaces { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.HolidaySystemCodeMaxLength)]
        public string HolidaySystemCode { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.WorkDayCodeMaxLength)]
        public string WorkDayCode { get; set; }
        [StringLength(CompanyJobContentConsts.WorkIdentityCodeMaxLength)]
        public string? WorkIdentityCode { get; set; }
        [StringLength(CompanyJobContentConsts.DisabilityCategoryMaxLength)]
        public string? DisabilityCategory { get; set; }
        [StringLength(CompanyJobContentConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        [StringLength(CompanyJobContentConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.StatusMaxLength)]
        public string Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}