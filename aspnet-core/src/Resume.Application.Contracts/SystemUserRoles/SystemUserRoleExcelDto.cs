using System;

namespace Resume.SystemUserRoles
{
    public class SystemUserRoleExcelDto
    {
        public string Name { get; set; }
        public int Keys { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}