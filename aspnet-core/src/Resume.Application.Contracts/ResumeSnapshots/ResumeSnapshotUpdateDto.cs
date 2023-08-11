using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.ResumeSnapshots
{
    public class ResumeSnapshotUpdateDto
    {
        public Guid UserMainId { get; set; }
        public Guid ResumeMainId { get; set; }
        public Guid CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        [Required]
        public string Snapshot { get; set; }
        public Guid? UserCompanyBindId { get; set; }
        [StringLength(ResumeSnapshotConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        [Required]
        public DateTime DateA { get; set; }
        [Required]
        public DateTime DateD { get; set; }
        [Required]
        public int Sort { get; set; }
        [StringLength(ResumeSnapshotConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(ResumeSnapshotConsts.StatusMaxLength)]
        public string Status { get; set; }

    }
}