using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyPointss
{
    public class CompanyPointsCreateDto
    {
        public Guid CompanyMainId { get; set; }
        [StringLength(CompanyPointsConsts.CompanyPointsTypeCodeMaxLength)]
        public string? CompanyPointsTypeCode { get; set; }
        public int Points { get; set; }
        [StringLength(CompanyPointsConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyPointsConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyPointsConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}