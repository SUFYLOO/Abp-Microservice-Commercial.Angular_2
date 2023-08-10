using System;

namespace Resume.ResumeCommunications
{
    public class ResumeCommunicationExcelDto
    {
        public Guid ResumeMainId { get; set; }
        public string CommunicationCategoryCode { get; set; }
        public string CommunicationValue { get; set; }
        public bool Main { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
    }
}