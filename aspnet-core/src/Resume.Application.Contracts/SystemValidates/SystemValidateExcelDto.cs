using System;

namespace Resume.SystemValidates
{
    public class SystemValidateExcelDto
    {
        public string Param { get; set; }
        public DateTime DateOpen { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}