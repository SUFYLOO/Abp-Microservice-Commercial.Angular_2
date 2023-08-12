using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeWorkss
{
    public class ResumeWorksCreateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeWorksConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(ResumeWorksConsts.LinkMaxLength)]
        public string? Link { get; set; }
        [StringLength(ResumeWorksConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeWorksConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeWorksConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}