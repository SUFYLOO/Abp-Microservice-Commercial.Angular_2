using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ShareExtendeds
{
    public class ShareExtendedUpdateDto
    {
        [StringLength(ShareExtendedConsts.Key1MaxLength)]
        public string? Key1 { get; set; }
        [StringLength(ShareExtendedConsts.Key2MaxLength)]
        public string? Key2 { get; set; }
        [StringLength(ShareExtendedConsts.Key3MaxLength)]
        public string? Key3 { get; set; }
        [StringLength(ShareExtendedConsts.Key4MaxLength)]
        public string? Key4 { get; set; }
        [StringLength(ShareExtendedConsts.Key5MaxLength)]
        public string? Key5 { get; set; }
        public Guid? KeyId { get; set; }
        [StringLength(ShareExtendedConsts.FieldValueMaxLength)]
        public string? FieldValue { get; set; }
        [StringLength(ShareExtendedConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ShareExtendedConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ShareExtendedConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}