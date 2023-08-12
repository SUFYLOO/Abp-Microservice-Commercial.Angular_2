using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareDefaults
{
    public class ShareDefaultUpdateDto
    {
        [Required]
        [StringLength(ShareDefaultConsts.GroupCodeMaxLength)]
        public string GroupCode { get; set; }
        [StringLength(ShareDefaultConsts.Key1MaxLength)]
        public string? Key1 { get; set; }
        [StringLength(ShareDefaultConsts.Key2MaxLength)]
        public string? Key2 { get; set; }
        [StringLength(ShareDefaultConsts.Key3MaxLength)]
        public string? Key3 { get; set; }
        [Required]
        [StringLength(ShareDefaultConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(ShareDefaultConsts.FieldKeyMaxLength)]
        public string FieldKey { get; set; }
        [StringLength(ShareDefaultConsts.FieldValueMaxLength)]
        public string? FieldValue { get; set; }
        [Required]
        [StringLength(ShareDefaultConsts.ColumnTypeCodeMaxLength)]
        public string ColumnTypeCode { get; set; }
        [Required]
        [StringLength(ShareDefaultConsts.FormTypeCodeMaxLength)]
        public string FormTypeCode { get; set; }
        [Required]
        public bool SystemUse { get; set; }
        [StringLength(ShareDefaultConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ShareDefaultConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ShareDefaultConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}