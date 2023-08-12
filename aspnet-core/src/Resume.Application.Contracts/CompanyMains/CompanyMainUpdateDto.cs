using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyMains
{
    public class CompanyMainUpdateDto
    {
        [Required]
        [StringLength(CompanyMainConsts.NameMaxLength)]
        public string Name { get; set; }
        [StringLength(CompanyMainConsts.CompilationMaxLength)]
        public string? Compilation { get; set; }
        [StringLength(CompanyMainConsts.OfficePhoneMaxLength)]
        public string? OfficePhone { get; set; }
        [StringLength(CompanyMainConsts.FaxPhoneMaxLength)]
        public string? FaxPhone { get; set; }
        [StringLength(CompanyMainConsts.AddressMaxLength)]
        public string? Address { get; set; }
        [StringLength(CompanyMainConsts.PrincipalMaxLength)]
        public string? Principal { get; set; }
        public bool AllowSearch { get; set; }
        [StringLength(CompanyMainConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        [StringLength(CompanyMainConsts.NoteMaxLength)]
        public string? Note { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyMainConsts.StatusMaxLength)]
        public string? Status { get; set; }
        [Required]
        [StringLength(CompanyMainConsts.IndustryCategoryMaxLength)]
        public string IndustryCategory { get; set; }
        [StringLength(CompanyMainConsts.CompanyUrlMaxLength)]
        public string? CompanyUrl { get; set; }
        public int CapitalAmount { get; set; }
        public bool HideCapitalAmount { get; set; }
        [Required]
        [StringLength(CompanyMainConsts.CompanyScaleCodeMaxLength)]
        public string CompanyScaleCode { get; set; }
        public bool HidePrincipal { get; set; }
        public Guid? CompanyUserId { get; set; }
        [StringLength(CompanyMainConsts.CompanyProfileMaxLength)]
        public string? CompanyProfile { get; set; }
        [StringLength(CompanyMainConsts.BusinessPhilosophyMaxLength)]
        public string? BusinessPhilosophy { get; set; }
        [StringLength(CompanyMainConsts.OperatingItemsMaxLength)]
        public string? OperatingItems { get; set; }
        [StringLength(CompanyMainConsts.WelfareSystemMaxLength)]
        public string? WelfareSystem { get; set; }
        public bool Matching { get; set; }
        public bool ContractPass { get; set; }

    }
}