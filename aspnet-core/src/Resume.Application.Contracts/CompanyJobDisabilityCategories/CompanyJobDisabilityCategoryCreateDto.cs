using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoryCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [StringLength(CompanyJobDisabilityCategoryConsts.DisabilityCategoryCodeMaxLength)]
        public string? DisabilityCategoryCode { get; set; }
        [StringLength(CompanyJobDisabilityCategoryConsts.DisabilityLevelCodeMaxLength)]
        public string? DisabilityLevelCode { get; set; }
        public bool DisabilityCertifiedDocumentsNeed { get; set; }
        [StringLength(CompanyJobDisabilityCategoryConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobDisabilityCategoryConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobDisabilityCategoryConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}