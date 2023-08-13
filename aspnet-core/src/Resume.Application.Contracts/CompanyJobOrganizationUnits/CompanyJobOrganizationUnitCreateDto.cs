using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobOrganizationUnits
{
    public class CompanyJobOrganizationUnitCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public Guid OrganizationUnitId { get; set; }
        [StringLength(CompanyJobOrganizationUnitConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobOrganizationUnitConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobOrganizationUnitConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}