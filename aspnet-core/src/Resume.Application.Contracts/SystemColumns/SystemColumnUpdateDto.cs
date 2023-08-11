using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemColumns
{
    public class SystemColumnUpdateDto
    {
        public Guid SystemTableId { get; set; }
        [Required]
        [StringLength(SystemColumnConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        public bool IsKey { get; set; }
        [Required]
        public bool IsSensitive { get; set; }
        [Required]
        public bool NeedMask { get; set; }
        [StringLength(SystemColumnConsts.DefaultValueMaxLength)]
        public string? DefaultValue { get; set; }
        [Required]
        public bool CheckCode { get; set; }
        [StringLength(SystemColumnConsts.RelatedMaxLength)]
        public string? Related { get; set; }
        [Required]
        public bool AllowUpdate { get; set; }
        [Required]
        public bool AllowNull { get; set; }
        [Required]
        public bool AllowEmpty { get; set; }
        [Required]
        public bool AllowExport { get; set; }
        [Required]
        public bool AllowSort { get; set; }
        [Required]
        [StringLength(SystemColumnConsts.ColumnTypeCodeMaxLength)]
        public string ColumnTypeCode { get; set; }
        [StringLength(SystemColumnConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(SystemColumnConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(SystemColumnConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}