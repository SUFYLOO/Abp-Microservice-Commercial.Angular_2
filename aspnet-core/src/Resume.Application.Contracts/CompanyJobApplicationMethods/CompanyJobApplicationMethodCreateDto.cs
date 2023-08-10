using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodCreateDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.OrgDeptMaxLength)]
        public string? OrgDept { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.OrgContactPersonMaxLength)]
        public string? OrgContactPerson { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.OrgContactMailMaxLength)]
        public string? OrgContactMail { get; set; }
        public int ToRespondDay { get; set; }
        public bool ToRespond { get; set; }
        public bool SystemSendResume { get; set; }
        public bool DisplayMail { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.TelephoneMaxLength)]
        public string? Telephone { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.PersonallyMaxLength)]
        public string? Personally { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.PersonallyAddressMaxLength)]
        public string? PersonallyAddress { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.ExtendedInformationMaxLength)]
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        [StringLength(CompanyJobApplicationMethodConsts.NoteMaxLength)]
        public string? Note { get; set; }
        [Required]
        [StringLength(CompanyJobApplicationMethodConsts.StatusMaxLength)]
        public string Status { get; set; }
    }
}