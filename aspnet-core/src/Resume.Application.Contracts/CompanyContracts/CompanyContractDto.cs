using System;
using Volo.Abp.Application.Dtos;

namespace Resume.CompanyContracts
{
    public class CompanyContractDto : FullAuditedEntityDto<Guid>
    {
        public Guid CompanyMainId { get; set; }
        public string PlanCode { get; set; }
        public int PointsTotal { get; set; }
        public int PointsPay { get; set; }
        public int PointsGift { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateA { get; set; }
        public DateTime? DateD { get; set; }
        public int? Sort { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

    }
}