using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.SystemValidates
{
    public class SystemValidateUpdateDto
    {
        [Required]
        [StringLength(SystemValidateConsts.ParamMaxLength)]
        public string Param { get; set; }
        [Required]
        public DateTime DateOpen { get; set; }
        [StringLength(SystemValidateConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(SystemValidateConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(SystemValidateConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}