using System;

namespace Resume.UserInfos
{
    public class UserInfoExcelDto
    {
        public Guid UserMainId { get; set; }
        public string NameC { get; set; }
        public string? NameE { get; set; }
        public string? IdentityNo { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? SexCode { get; set; }
        public string? BloodCode { get; set; }
        public string? PlaceOfBirthCode { get; set; }
        public string? PassportNo { get; set; }
        public string? NationalityCode { get; set; }
        public string? ResidenceNo { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}