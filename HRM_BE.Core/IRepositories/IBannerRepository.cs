
using HRM_BE.Core.Data.Content;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Content.Banner;

namespace HRM_BE.Core.IRepositories
{
    public interface IBannerRepository: IRepositoryBase<Banner, int>
    {

        Task<PagingResult<BannerDto>> GetAllPaging(string? place, string? type ,string? title, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10);

    }
}
