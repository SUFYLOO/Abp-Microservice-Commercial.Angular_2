using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeExperiencess
{
    public class GetResumeExperiencessInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? ResumeMainId { get; set; }
        public string? Name { get; set; }
        public string? WorkNatureCode { get; set; }
        public bool? HideCompanyName { get; set; }
        public string? IndustryCategoryCode { get; set; }
        public string? JobName { get; set; }
        public string? JobType { get; set; }
        public bool? Working { get; set; }
        public string? WorkPlaceCode { get; set; }
        public bool? HideWorkSalary { get; set; }
        public string? SalaryPayTypeCode { get; set; }
        public string? CurrencyTypeCode { get; set; }
        public decimal? Salary1Min { get; set; }
        public decimal? Salary1Max { get; set; }
        public decimal? Salary2Min { get; set; }
        public decimal? Salary2Max { get; set; }
        public string? CompanyScaleCode { get; set; }
        public string? CompanyManagementNumberCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetResumeExperiencessInput()
        {

        }
    }
}