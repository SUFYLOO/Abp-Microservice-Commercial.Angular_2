using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemPages
{
    public class SystemPageUpdateDto
    {
        [Required]
        [StringLength(SystemPageConsts.TypeCodeMaxLength)]
        public string TypeCode { get; set; }
        [StringLength(SystemPageConsts.FilePathMaxLength)]
        public string? FilePath { get; set; }
        [StringLength(SystemPageConsts.FileNameMaxLength)]
        public string? FileName { get; set; }
        [StringLength(SystemPageConsts.FileTitleMaxLength)]
        public string? FileTitle { get; set; }
        [Required]
        [StringLength(SystemPageConsts.SystemUserRoleKeysMaxLength)]
        public string SystemUserRoleKeys { get; set; }
        [Required]
        [StringLength(SystemPageConsts.ParentCodeMaxLength)]
        public string ParentCode { get; set; }
        [StringLength(SystemPageConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(SystemPageConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(SystemPageConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}