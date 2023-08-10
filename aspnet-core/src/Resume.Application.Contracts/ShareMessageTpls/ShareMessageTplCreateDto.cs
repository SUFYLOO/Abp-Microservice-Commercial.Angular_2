using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareMessageTpls
{
    public class ShareMessageTplCreateDto
    {
        [StringLength(ShareMessageTplConsts.Key1MaxLength)]
        public string? Key1 { get; set; }
        [StringLength(ShareMessageTplConsts.Key2MaxLength)]
        public string? Key2 { get; set; }
        [Required]
        [StringLength(ShareMessageTplConsts.Key3MaxLength)]
        public string Key3 { get; set; }
        [Required]
        [StringLength(ShareMessageTplConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(ShareMessageTplConsts.StatementMaxLength)]
        public string? Statement { get; set; }
        [Required]
        [StringLength(ShareMessageTplConsts.TitleContentsMaxLength)]
        public string TitleContents { get; set; }
        public string? ContentMail { get; set; }
        [StringLength(ShareMessageTplConsts.ContentSMSMaxLength)]
        public string? ContentSMS { get; set; }
        [StringLength(ShareMessageTplConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ShareMessageTplConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ShareMessageTplConsts.StatusMaxLength)]
        public string Status { get; set; }
    }
}