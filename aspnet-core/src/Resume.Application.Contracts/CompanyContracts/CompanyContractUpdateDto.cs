using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyContracts
{
    public class CompanyContractUpdateDto : IHasConcurrencyStamp
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
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        [StringLength(CompanyContractConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(CompanyContractConsts.StatusMaxLength)]
        public string Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}