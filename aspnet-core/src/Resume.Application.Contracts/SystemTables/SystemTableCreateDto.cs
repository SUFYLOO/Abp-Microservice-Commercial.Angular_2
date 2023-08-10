using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemTables
{
    public class SystemTableCreateDto
    {
        [Required]
        [StringLength(SystemTableConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public bool AllowInsert { get; set; }
        [Required]
        public bool AllowUpdate { get; set; }
        [Required]
        public bool AllowDelete { get; set; }
        [Required]
        public bool AllowSelect { get; set; }
        [Required]
        public bool AllowExport { get; set; }
        [Required]
        public bool AllowImport { get; set; }
        [Required]
        public bool AllowPage { get; set; }
        [Required]
        public bool AllowSort { get; set; }
        [StringLength(SystemTableConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(SystemTableConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(SystemTableConsts.StatusMaxLength)]
        public string Status { get; set; }
    }
}