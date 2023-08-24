using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public string? Name { get; set; }
        public string? JobTypeCode { get; set; }
        public int? PeopleRequiredNumberMin { get; set; }
        public int? PeopleRequiredNumberMax { get; set; }
        public bool? PeopleRequiredNumberUnlimited { get; set; }
        public string? JobType { get; set; }
        public string? JobTypeContent { get; set; }
        public string? SalaryPayTypeCode { get; set; }
        public int? SalaryMinMin { get; set; }
        public int? SalaryMinMax { get; set; }
        public int? SalaryMaxMin { get; set; }
        public int? SalaryMaxMax { get; set; }
        public bool? SalaryUp { get; set; }
        public string? WorkPlace { get; set; }
        public string? WorkHours { get; set; }
        public string? WorkHoursCustom { get; set; }
        public bool? WorkShift { get; set; }
        public bool? WorkRemoteAllow { get; set; }
        public string? WorkRemoteTypeCode { get; set; }
        public string? WorkRemoteDescript { get; set; }
        public bool? BusinessTrip { get; set; }
        public string? HolidaySystemCode { get; set; }
        public bool? Dispatched { get; set; }
        public string? WorkDayCode { get; set; }
        public string? WorkIdentity { get; set; }
        public string? DisabilityCategory { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public CompanyJobContentExcelDownloadDto()
        {

        }
    }
}