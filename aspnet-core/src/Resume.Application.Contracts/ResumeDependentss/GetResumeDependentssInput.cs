using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeDependentss
{
    public class GetResumeDependentssInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? ResumeMainId { get; set; }
        public string? Name { get; set; }
        public string? IdentityNo { get; set; }
        public string? KinshipCode { get; set; }
        public DateTime? BirthDateMin { get; set; }
        public DateTime? BirthDateMax { get; set; }
        public string? Address { get; set; }
        public string? MobilePhone { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetResumeDependentssInput()
        {

        }
    }
}