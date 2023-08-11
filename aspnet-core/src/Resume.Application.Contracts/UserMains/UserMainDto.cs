using System;
using Volo.Abp.Application.Dtos;

namespace Resume.UserMains
{
    public class UserMainDto : FullAuditedEntityDto<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string? AnonymousName { get; set; }
        public string LoginAccountCode { get; set; }
        public string? LoginMobilePhoneUpdate { get; set; }
        public string? LoginMobilePhone { get; set; }
        public string? LoginEmailUpdate { get; set; }
        public string? LoginEmail { get; set; }
        public string? LoginIdentityNo { get; set; }
        public string Password { get; set; }
        public int SystemUserRoleKeys { get; set; }
        public bool AllowSearch { get; set; }
        public DateTime DateA { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime DateD { get; set; }
        public int Sort { get; set; }
        public string? Note { get; set; }
        public string Status { get; set; }
        public bool Matching { get; set; }

    }
}