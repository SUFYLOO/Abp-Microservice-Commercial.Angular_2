using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeMains
{
    public class GetResumeMainsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? UserMainId { get; set; }
        public string? ResumeName { get; set; }
        public string? MarriageCode { get; set; }
        public string? MilitaryCode { get; set; }
        public string? DisabilityCategoryCode { get; set; }
        public string? SpecialIdentityCode { get; set; }
        public bool? Main { get; set; }
        public string? Autobiography1 { get; set; }
        public string? Autobiography2 { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetResumeMainsInput()
        {

        }
    }
}