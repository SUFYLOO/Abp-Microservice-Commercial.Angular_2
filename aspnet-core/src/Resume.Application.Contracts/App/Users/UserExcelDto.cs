using System;

namespace Resume.App.Users
{
    public class UserExcelDto
    {
        public string Code { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string AnonymousName { get; set; }
        public string LoginAccountCode { get; set; }
        public string LoginMobilePhone { get; set; }
        public string LoginEmail { get; set; }
        public string LoginIdentityNo { get; set; }
        public string Password { get; set; }
        public int SystemUserRoleKeys { get; set; }
        public bool AllowSearch { get; set; }
        public string ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
    }
}