using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotifyCreateDto
    {
        [Required]
        public Guid UserMainId { get; set; }
        [StringLength(SystemUserNotifyConsts.KeyIdMaxLength)]
        public string? KeyId { get; set; }
        [StringLength(SystemUserNotifyConsts.KeyNameMaxLength)]
        public string? KeyName { get; set; }
        [Required]
        [StringLength(SystemUserNotifyConsts.NotifyTypeCodeMaxLength)]
        public string NotifyTypeCode { get; set; }
        [Required]
        [StringLength(SystemUserNotifyConsts.AppNameMaxLength)]
        public string AppName { get; set; }
        [Required]
        [StringLength(SystemUserNotifyConsts.AppCodeMaxLength)]
        public string AppCode { get; set; }
        [Required]
        [StringLength(SystemUserNotifyConsts.TitleContentsMaxLength)]
        public string TitleContents { get; set; }
        [Required]
        [StringLength(SystemUserNotifyConsts.ContentsMaxLength)]
        public string Contents { get; set; }
        [Required]
        public bool IsRead { get; set; }
        [StringLength(SystemUserNotifyConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(SystemUserNotifyConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(SystemUserNotifyConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}