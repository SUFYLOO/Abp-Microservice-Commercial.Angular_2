using Volo.Abp.Application.Dtos;
using System;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoryExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public Guid? CompanyMainId { get; set; }
        public Guid? CompanyJobId { get; set; }
        public string? DisabilityCategoryCode { get; set; }
        public string? DisabilityLevelCode { get; set; }
        public bool? DisabilityCertifiedDocumentsNeed { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public CompanyJobDisabilityCategoryExcelDownloadDto()
        {

        }
    }
}