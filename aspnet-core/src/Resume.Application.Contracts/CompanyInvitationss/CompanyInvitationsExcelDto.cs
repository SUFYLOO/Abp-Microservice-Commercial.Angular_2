using System;

namespace Resume.CompanyInvitationss
{
    public class CompanyInvitationsExcelDto
    {
        public Guid CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public bool OpenAllJob { get; set; }
        public Guid? UserMainId { get; set; }
        public string? UserMainName { get; set; }
        public string? UserMainLoginMobilePhone { get; set; }
        public string? UserMainLoginEmail { get; set; }
        public string? UserMainLoginIdentityNo { get; set; }
        public string SendTypeCode { get; set; }
        public string SendStatusCode { get; set; }
        public string ResumeFlowStageCode { get; set; }
        public bool IsRead { get; set; }
        public Guid? UserCompanyBindId { get; set; }
        public Guid? ResumeSnapshotId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }
    }
}