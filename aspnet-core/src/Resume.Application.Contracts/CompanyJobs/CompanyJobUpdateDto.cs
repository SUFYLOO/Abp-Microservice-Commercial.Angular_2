using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobs
{
    public class CompanyJobUpdateDto
    {
        public Guid CompanyMainId { get; set; }
        [Required]
        [StringLength(CompanyJobConsts.NameMaxLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(CompanyJobConsts.JobTypeCodeMaxLength)]
        public string JobTypeCode { get; set; }
        [Required]
        public bool JobOpen { get; set; }
        [Required]
        [StringLength(CompanyJobConsts.MailTplIdMaxLength)]
        public string MailTplId { get; set; }
        [Required]
        [StringLength(CompanyJobConsts.SMSTplIdMaxLength)]
        public string SMSTplId { get; set; }
        [StringLength(CompanyJobConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}