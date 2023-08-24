using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobWorkHourss
{
    public class CompanyJobWorkHoursCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [Required]
        [StringLength(CompanyJobWorkHoursConsts.WorkHoursCodeMaxLength)]
        public string WorkHoursCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyJobWorkHoursConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyJobWorkHoursConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}