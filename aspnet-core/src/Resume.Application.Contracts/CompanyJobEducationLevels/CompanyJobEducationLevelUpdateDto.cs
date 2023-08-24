using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevelUpdateDto : IHasConcurrencyStamp
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.EducationLevelCodeMaxLength)]
        public string? EducationLevelCode { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobEducationLevelConsts.StatusMaxLength)]
        public string? Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}