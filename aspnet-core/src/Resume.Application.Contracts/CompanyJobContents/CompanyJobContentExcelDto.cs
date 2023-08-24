using System;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string Name { get; set; }
        public string JobTypeCode { get; set; }
        public int PeopleRequiredNumber { get; set; }
        public bool PeopleRequiredNumberUnlimited { get; set; }
        public string? JobType { get; set; }
        public string? JobTypeContent { get; set; }
        public string SalaryPayTypeCode { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public bool SalaryUp { get; set; }
        public string? WorkPlace { get; set; }
        public string? WorkHours { get; set; }
        public string? WorkHoursCustom { get; set; }
        public bool WorkShift { get; set; }
        public bool WorkRemoteAllow { get; set; }
        public string WorkRemoteTypeCode { get; set; }
        public string? WorkRemoteDescript { get; set; }
        public bool BusinessTrip { get; set; }
        public string HolidaySystemCode { get; set; }
        public bool Dispatched { get; set; }
        public string WorkDayCode { get; set; }
        public string? WorkIdentity { get; set; }
        public string? DisabilityCategory { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}