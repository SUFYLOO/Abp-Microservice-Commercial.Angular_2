using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentUpdateDto
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
        [StringLength(CompanyJobContentConsts.JobTypeContentMaxLength)]
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
        [StringLength(CompanyJobContentConsts.WorkHoursCustomMaxLength)]
        public string? WorkHoursCustom { get; set; }
        public bool WorkShift { get; set; }
        public bool WorkRemoteAllow { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.WorkRemoteTypeCodeMaxLength)]
        public string WorkRemoteTypeCode { get; set; }
        [StringLength(CompanyJobContentConsts.WorkRemoteDescriptMaxLength)]
        public string? WorkRemoteDescript { get; set; }
        public bool BusinessTrip { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.HolidaySystemCodeMaxLength)]
        public string HolidaySystemCode { get; set; }
        public bool Dispatched { get; set; }
        [Required]
        [StringLength(CompanyJobContentConsts.WorkDayCodeMaxLength)]
        public string WorkDayCode { get; set; }
        [StringLength(CompanyJobContentConsts.WorkIdentityMaxLength)]
        public string? WorkIdentity { get; set; }
        [StringLength(CompanyJobContentConsts.DisabilityCategoryMaxLength)]
        public string? DisabilityCategory { get; set; }
        [StringLength(CompanyJobContentConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobContentConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobContentConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}