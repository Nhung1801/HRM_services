using HRM_BE.Core.Constants.System;
using HRM_BE.Core.Data.Content;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Content.Banner;
using HRM_BE.Data.SeedWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace HRM_BE.Data.Repositories
{
    public class BannerRepository : RepositoryBase<Banner, int>, IBannerRepository
    {


        private readonly IMapper _mapper;
        public BannerRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context,httpContextAccessor)
        {
            _mapper = mapper;
        }


        public async Task<PagingResult<BannerDto>> GetAllPaging(string? place, string? type, string? title, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.Banners.AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(b => b.Type == type);
            }

            if (!string.IsNullOrEmpty(place))
            {
                query = query.Where(b => b.Place == place);
            }

            if (!string.IsNullOrEmpty(title))
            {
                string search = title.ToLower();
                query = query.Where(b => b.Title.ToLower().Contains(title.ToLower()));
            }

            int total = await query.CountAsync();

            if (pageIndex == null) pageIndex = 1;
            if (pageSize == null) pageSize = total;


            if (string.IsNullOrEmpty(orderBy) && string.IsNullOrEmpty(sortBy))
            {
                query = query.OrderByDescending(b => b.Id);
            }
            else if (string.IsNullOrEmpty(orderBy))
            {
                if (sortBy == SortByConstant.Asc)
                {
                    query = query.OrderBy(b => b.Id);
                }
                else
                {
                    query = query.OrderByDescending(b => b.Id);
                }
            }
            else if (string.IsNullOrEmpty(sortBy))
            {
                query = query.OrderByDescending(b => b.Id);
            }
            else
            {
                if (orderBy == OrderByConstant.Id && sortBy == SortByConstant.Asc)
                {
                    query = query.OrderBy(b => b.Id);
                }
                else if (orderBy == OrderByConstant.Id && sortBy == SortByConstant.Desc)
                {
                    query = query.OrderByDescending(b => b.Id);
                }
            }

            query = query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);


            var data = await _mapper.ProjectTo<BannerDto>(query).ToListAsync();




            var result = new PagingResult<BannerDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;

        }

    }
}
