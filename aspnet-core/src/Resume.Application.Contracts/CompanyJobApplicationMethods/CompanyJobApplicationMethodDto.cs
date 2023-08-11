using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public Guid CompanyMainId { get; set; }
        public Guid CompanyJobId { get; set; }
        public string? OrgDept { get; set; }
        public string? OrgContactPerson { get; set; }
        public string? OrgContactMail { get; set; }
        public int ToRespondDay { get; set; }
        public bool ToRespond { get; set; }
        public bool SystemSendResume { get; set; }
        public bool DisplayMail { get; set; }
        public string? Telephone { get; set; }
        public string? Personally { get; set; }
        public string? PersonallyAddress { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateA { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}