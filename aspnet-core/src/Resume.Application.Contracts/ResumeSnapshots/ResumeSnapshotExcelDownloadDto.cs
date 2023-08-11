using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ResumeSnapshots
{
    public class ResumeSnapshotExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? UserMainId { get; set; }
        public Guid? ResumeMainId { get; set; }
        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public string? Snapshot { get; set; }
        public Guid? UserCompanyBindId { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public ResumeSnapshotExcelDownloadDto()
        {

        }
    }
}