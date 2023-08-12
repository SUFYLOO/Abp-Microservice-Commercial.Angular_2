using System;

namespace Resume.ShareUploads
{
    public class ShareUploadExcelDto
    {
        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string UploadName { get; set; }
        public string ServerName { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public bool SystemUse { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}