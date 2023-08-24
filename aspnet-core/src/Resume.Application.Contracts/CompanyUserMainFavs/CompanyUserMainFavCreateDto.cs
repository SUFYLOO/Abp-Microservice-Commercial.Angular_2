using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyUserMainFavs
{
    public class CompanyUserMainFavCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public Guid UserMainId { get; set; }
        [StringLength(CompanyUserMainFavConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(CompanyUserMainFavConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(CompanyUserMainFavConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}