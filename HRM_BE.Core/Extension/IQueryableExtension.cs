using HRM_BE.Core.Constants.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Extension
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> ApplySorting<T>(
        this IQueryable<T> query,
        string orderBy,
        string sortBy,
        string defaultSortColumn = "Id") where T : class
        {
            // Nếu không truyền vào orderBy, sắp xếp theo cột mặc định (Id)
            orderBy = string.IsNullOrEmpty(orderBy) ? defaultSortColumn : orderBy;

            // Kiểm tra nếu sortBy là Desc, thì áp dụng sắp xếp giảm dần
            if (sortBy == SortByConstant.Desc)
            {
                return query.OrderByDescending(GetSortExpression<T>(orderBy));
            }

            // Mặc định sắp xếp tăng dần
            return query.OrderBy(GetSortExpression<T>(orderBy));
        }
        // Phương thức giúp lấy biểu thức sắp xếp từ một trường
        private static Expression<Func<T, object>> GetSortExpression<T>(string sortBy)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, sortBy);
            var converted = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(converted, parameter);
        }
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return query
                .Skip((pageIndex - 1) * pageSize)  // Bỏ qua số lượng bản ghi đã hiển thị
                .Take(pageSize);                   // Lấy số lượng bản ghi theo pageSize
        }
    }
}