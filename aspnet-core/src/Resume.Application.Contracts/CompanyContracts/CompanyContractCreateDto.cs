using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyContracts
{
    public class CompanyContractCreateDto
    {
        public Guid CompanyMainId { get; set; }
        [Required]
        [StringLength(CompanyContractConsts.PlanCodeMaxLength)]
        public string PlanCode { get; set; }
        public int PointsTotal { get; set; }
        public int PointsPay { get; set; }
        public int PointsGift { get; set; }
        [StringLength(CompanyContractConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyContractConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyContractConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}