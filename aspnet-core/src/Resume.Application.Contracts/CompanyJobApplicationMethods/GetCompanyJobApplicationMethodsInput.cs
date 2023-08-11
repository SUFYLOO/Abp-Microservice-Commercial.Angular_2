using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyJobApplicationMethods
{
    public class GetCompanyJobApplicationMethodsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public string? OrgDept { get; set; }
        public string? OrgContactPerson { get; set; }
        public string? OrgContactMail { get; set; }
        public int? ToRespondDayMin { get; set; }
        public int? ToRespondDayMax { get; set; }
        public bool? ToRespond { get; set; }
        public bool? SystemSendResume { get; set; }
        public bool? DisplayMail { get; set; }
        public string? Telephone { get; set; }
        public string? Personally { get; set; }
        public string? PersonallyAddress { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetCompanyJobApplicationMethodsInput()
        {

        }
    }
}