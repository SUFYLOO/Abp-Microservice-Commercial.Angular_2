using Volo.Abp.Application.Dtos;
using System;

namespace Resume.UserMains
{
    public class UserMainExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public string? AnonymousName { get; set; }
        public string? LoginAccountCode { get; set; }
        public string? LoginMobilePhoneUpdate { get; set; }
        public string? LoginMobilePhone { get; set; }
        public string? LoginEmailUpdate { get; set; }
        public string? LoginEmail { get; set; }
        public string? LoginIdentityNo { get; set; }
        public string? Password { get; set; }
        public int? SystemUserRoleKeysMin { get; set; }
        public int? SystemUserRoleKeysMax { get; set; }
        public bool? AllowSearch { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
        public bool? Matching { get; set; }

        public UserMainExcelDownloadDto()
        {

        }
    }
}