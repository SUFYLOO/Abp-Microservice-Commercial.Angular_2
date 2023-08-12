using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareSendQueues
{
    public class ShareSendQueueUpdateDto
    {
        [Required]
        [StringLength(ShareSendQueueConsts.Key1MaxLength)]
        public string Key1 { get; set; }
        [Required]
        [StringLength(ShareSendQueueConsts.Key2MaxLength)]
        public string Key2 { get; set; }
        [Required]
        [StringLength(ShareSendQueueConsts.Key3MaxLength)]
        public string Key3 { get; set; }
        [Required]
        [StringLength(ShareSendQueueConsts.SendTypeCodeMaxLength)]
        public string SendTypeCode { get; set; }
        [StringLength(ShareSendQueueConsts.FromAddrMaxLength)]
        public string? FromAddr { get; set; }
        [Required]
        [StringLength(ShareSendQueueConsts.ToAddrMaxLength)]
        public string ToAddr { get; set; }
        [StringLength(ShareSendQueueConsts.TitleContentsMaxLength)]
        public string? TitleContents { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public int Retry { get; set; }
        [Required]
        public bool Sucess { get; set; }
        [Required]
        public bool Suspend { get; set; }
        [Required]
        public DateTime DateSend { get; set; }
        [StringLength(ShareSendQueueConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ShareSendQueueConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ShareSendQueueConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}