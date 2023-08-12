using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemValidates
{
    public class SystemValidateCreateDto
    {
        [Required]
        [StringLength(SystemValidateConsts.ParamMaxLength)]
        public string Param { get; set; }
        [Required]
        public DateTime DateOpen { get; set; }
        [StringLength(SystemValidateConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(SystemValidateConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(SystemValidateConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}