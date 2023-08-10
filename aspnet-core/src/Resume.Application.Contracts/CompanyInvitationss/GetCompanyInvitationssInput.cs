using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyInvitationss
{
    public class GetCompanyInvitationssInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public bool? OpenAllJob { get; set; }
        public Guid? UserMainId { get; set; }
        public string? UserMainName { get; set; }
        public string? UserMainLoginMobilePhone { get; set; }
        public string? UserMainLoginEmail { get; set; }
        public string? UserMainLoginIdentityNo { get; set; }
        public string? SendTypeCode { get; set; }
        public string? SendStatusCode { get; set; }
        public string? ResumeFlowStageCode { get; set; }
        public bool? IsRead { get; set; }
        public Guid? UserCompanyBindId { get; set; }
        public Guid? ResumeSnapshotId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetCompanyInvitationssInput()
        {

        }
    }
}