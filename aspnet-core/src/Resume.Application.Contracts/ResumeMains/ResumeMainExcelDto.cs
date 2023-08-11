using System;

namespace Resume.ResumeMains
{
    public class ResumeMainExcelDto
    {
        public Guid UserMainId { get; set; }
        public string ResumeName { get; set; }
        public string? MarriageCode { get; set; }
        public string? MilitaryCode { get; set; }
        public string? DisabilityCategoryCode { get; set; }
        public string? SpecialIdentityCode { get; set; }
        public bool Main { get; set; }
        public string? Autobiography1 { get; set; }
        public string? Autobiography2 { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}