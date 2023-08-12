using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessageCreateDto
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
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(SystemDisplayMessageConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(SystemDisplayMessageConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}