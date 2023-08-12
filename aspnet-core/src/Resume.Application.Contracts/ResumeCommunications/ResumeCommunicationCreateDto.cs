using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeCommunications
{
    public class ResumeCommunicationCreateDto
    {
        public Guid ResumeMainId { get; set; }
        [Required]
        [StringLength(ResumeCommunicationConsts.CommunicationCategoryCodeMaxLength)]
        public string CommunicationCategoryCode { get; set; }
        [Required]
        [StringLength(ResumeCommunicationConsts.CommunicationValueMaxLength)]
        public string CommunicationValue { get; set; }
        [Required]
        public bool Main { get; set; }
        [StringLength(ResumeCommunicationConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(ResumeCommunicationConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(ResumeCommunicationConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}