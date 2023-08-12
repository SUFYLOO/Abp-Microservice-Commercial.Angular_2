using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFavCreateDto
    {
        public Guid UserMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [StringLength(UserCompanyJobFavConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        [StringLength(UserCompanyJobFavConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [StringLength(UserCompanyJobFavConsts.StatusMaxLength)]
        public string? Status { get; set; }
    }
}