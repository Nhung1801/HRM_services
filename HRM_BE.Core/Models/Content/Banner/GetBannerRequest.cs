
using HRM_BE.Core.Models.Common;

namespace HRM_BE.Core.Models.Content.Banner
{
    public class GetBannerRequest : PagingRequest
    {
        public string? Place { get; set; }

        public string? Type { get; set; }

        public string? Title { get; set; }
    }

}
