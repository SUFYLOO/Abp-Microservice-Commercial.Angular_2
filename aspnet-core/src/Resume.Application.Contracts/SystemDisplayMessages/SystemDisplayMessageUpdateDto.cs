using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessageUpdateDto
    {
        [Required]
        [StringLength(SystemDisplayMessageConsts.DisplayTypeCodeMaxLength)]
        public string DisplayTypeCode { get; set; }
        [Required]
        [StringLength(SystemDisplayMessageConsts.TitleContentsMaxLength)]
        public string TitleContents { get; set; }
        [Required]
        [StringLength(SystemDisplayMessageConsts.ContentsMaxLength)]
        public string Contents { get; set; }
        [StringLength(SystemDisplayMessageConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(SystemDisplayMessageConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(SystemDisplayMessageConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}