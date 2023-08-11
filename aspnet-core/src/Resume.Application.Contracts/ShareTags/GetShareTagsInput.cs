using Volo.Abp.Application.Dtos;
using System;

namespace Resume.ShareTags
{
    public class GetShareTagsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? ColorCode { get; set; }
        public string? Key1 { get; set; }
        public string? Key2 { get; set; }
        public string? Key3 { get; set; }
        public string? Name { get; set; }
        public string? TagCategoryCode { get; set; }
        public string? ExtendedInformation { get; set; }
        public DateTime? DateAMin { get; set; }
        public DateTime? DateAMax { get; set; }
        public DateTime? DateDMin { get; set; }
        public DateTime? DateDMax { get; set; }
        public int? SortMin { get; set; }
        public int? SortMax { get; set; }
        public string? Note { get; set; }
        public string? Status { get; set; }

        public GetShareTagsInput()
        {

        }
    }
}