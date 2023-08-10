using Volo.Abp.Application.Dtos;
using System;

namespace Resume.UserInfos
{
    public class GetUserInfosInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? UserMainId { get; set; }
        public string? NameC { get; set; }
        public string? NameE { get; set; }
        public string? IdentityNo { get; set; }
        public DateTime? BirthDateMin { get; set; }
        public DateTime? BirthDateMax { get; set; }
        public string? SexCode { get; set; }
        public string? BloodCode { get; set; }
        public string? PlaceOfBirthCode { get; set; }
        public string? PassportNo { get; set; }
        public string? NationalityCode { get; set; }
        public string? ResidenceNo { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetUserInfosInput()
        {

        }
    }
}