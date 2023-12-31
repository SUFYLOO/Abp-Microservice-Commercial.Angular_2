using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairUpdateDto
    {
        public Guid CompanyMainId { get; set; }
        [Required]
        [StringLength(CompanyJobPairConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(CompanyJobPairConsts.PairConditionMaxLength)]
        public string? PairCondition { get; set; }
        [StringLength(CompanyJobPairConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobPairConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobPairConsts.StatusMaxLength)]
        public string? Status { get; set; }

    }
}