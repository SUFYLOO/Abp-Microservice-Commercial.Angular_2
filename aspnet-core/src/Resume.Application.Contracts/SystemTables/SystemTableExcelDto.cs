using System;

namespace Resume.SystemTables
{
    public class SystemTableExcelDto
    {
        public string Name { get; set; }
        public bool AllowInsert { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowSelect { get; set; }
        public bool AllowExport { get; set; }
        public bool AllowImport { get; set; }
        public bool AllowPage { get; set; }
        public bool AllowSort { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}