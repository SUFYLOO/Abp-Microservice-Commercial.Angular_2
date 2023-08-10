using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeDependentss
{
    public class ResumeDependentsUpdateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeDependentsConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(ResumeDependentsConsts.IdentityNoMaxLength)]
        public string? IdentityNo { get; set; }
        [Required]
        [StringLength(ResumeDependentsConsts.KinshipCodeMaxLength)]
        public string KinshipCode { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [StringLength(ResumeDependentsConsts.AddressMaxLength)]
        public string? Address { get; set; }
        [StringLength(ResumeDependentsConsts.MobilePhoneMaxLength)]
        public string? MobilePhone { get; set; }
        [StringLength(ResumeDependentsConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ResumeDependentsConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ResumeDependentsConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}