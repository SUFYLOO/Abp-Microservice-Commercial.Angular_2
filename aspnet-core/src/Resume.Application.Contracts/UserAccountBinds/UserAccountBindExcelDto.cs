using System;

namespace Resume.UserAccountBinds
{
    public class UserAccountBindExcelDto
    {
        public Guid UserMainId { get; set; }
        public string ThirdPartyTypeCode { get; set; }
        public string ThirdPartyAccountId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}