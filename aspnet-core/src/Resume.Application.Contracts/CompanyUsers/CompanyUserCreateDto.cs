using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyUsers
{
    public class CompanyUserCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid UserMainId { get; set; }
        [StringLength(CompanyUserConsts.JobNameMaxLength)]
        public string? JobName { get; set; }
        [StringLength(CompanyUserConsts.OfficePhoneMaxLength)]
        public string? OfficePhone { get; set; }
        [StringLength(CompanyUserConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyUserConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyUserConsts.StatusMaxLength)]
        public string? Status { get; set; }
        public bool? MatchingReceive { get; set; }
    }
}