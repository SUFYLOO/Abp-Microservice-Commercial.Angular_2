using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareUploads
{
    public class ShareUploadCreateDto
    {
        [StringLength(ShareUploadConsts.Key1MaxLength)]
        public string? Key1 { get; set; }
        [StringLength(ShareUploadConsts.Key2MaxLength)]
        public string? Key2 { get; set; }
        [StringLength(ShareUploadConsts.Key3MaxLength)]
        public string? Key3 { get; set; }
        [Required]
        [StringLength(ShareUploadConsts.UploadNameMaxLength)]
        public string UploadName { get; set; }
        [Required]
        [StringLength(ShareUploadConsts.ServerNameMaxLength)]
        public string ServerName { get; set; }
        [Required]
        [StringLength(ShareUploadConsts.TypeMaxLength)]
        public string Type { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public bool SystemUse { get; set; }
        [StringLength(ShareUploadConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ShareUploadConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ShareUploadConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}