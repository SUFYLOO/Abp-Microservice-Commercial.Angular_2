using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPayUpdateDto : IHasConcurrencyStamp
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [Required]
        [StringLength(CompanyJobPayConsts.JobPayTypeCodeMaxLength)]
        public string JobPayTypeCode { get; set; }
        public DateTime? DateReal { get; set; }
        public bool IsCancel { get; set; }
        [StringLength(CompanyJobPayConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        [StringLength(CompanyJobPayConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(CompanyJobPayConsts.StatusMaxLength)]
        public string Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}