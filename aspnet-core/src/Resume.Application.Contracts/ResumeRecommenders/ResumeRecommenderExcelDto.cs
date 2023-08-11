using System;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommenderExcelDto
    {
        public Guid ResumeMainId { get; set; }
        public string Name { get; set; }
        public string? CompanyName { get; set; }
        public string? JobName { get; set; }
        public string? MobilePhone { get; set; }
        public string? OfficePhone { get; set; }
        public string? Email { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}