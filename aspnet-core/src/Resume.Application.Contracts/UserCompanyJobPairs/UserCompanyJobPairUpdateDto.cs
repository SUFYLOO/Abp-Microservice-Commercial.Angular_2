using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairUpdateDto : IHasConcurrencyStamp
    {
        public Guid UserMainId { get; set; }
        [Required]
        [StringLength(UserCompanyJobPairConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(UserCompanyJobPairConsts.PairConditionMaxLength)]
        public string? PairCondition { get; set; }
        [StringLength(UserCompanyJobPairConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(UserCompanyJobPairConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(UserCompanyJobPairConsts.StatusMaxLength)]
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}