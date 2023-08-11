using System;

namespace Resume.UserVerifys
{
    public class UserVerifyExcelDto
    {
        public string VerifyId { get; set; }
        public string VerifyCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}