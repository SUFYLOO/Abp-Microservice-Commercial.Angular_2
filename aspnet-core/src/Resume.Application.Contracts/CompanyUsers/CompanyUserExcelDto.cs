using System;

namespace Resume.CompanyUsers
{
    public class CompanyUserExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid UserMainId { get; set; }
        public string? JobName { get; set; }
        public string? OfficePhone { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
        public bool MatchingReceive { get; set; }
    }
}