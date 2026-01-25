using AutoMapper;
using HRM_BE.Core.Data.Payroll_Timekeeping.Payroll;
using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.Extension;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Payroll_Timekeeping.Payroll;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Data.Repositories
{
    public class PayrollInquiryRepository : RepositoryBase<PayrollInquiry, int>, IPayrollInquiryRepository
    {
        private readonly IMapper _mapper;

        public PayrollInquiryRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<PayrollInquiryDto> Create(CreatePayrollInquiryRequest request)
        {
            var entity = _mapper.Map<PayrollInquiry>(request);
            await CreateAsync(entity);
            return _mapper.Map<PayrollInquiryDto>(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetPayrollInquiryAndCheckExist(id);
            await DeleteAsync(entity);
        }

        public async Task<PayrollInquiryDto> GetById(int id)
        {
            var entity = await GetPayrollInquiryAndCheckExist(id);
            return _mapper.Map<PayrollInquiryDto>(entity);
        }

        public async Task<PagingResult<PayrollInquiryDto>> Paging(int? payrollDetailId, int? payrollId, string? sortBy, string? orderBy, int pageIndex = 1, int pageSize = 10)
        {
            var query = _dbContext.PayrollInquiries.Include(p => p.PayrollDetail).ThenInclude(d => d.Payroll).Where(p => p.IsDeleted != true).AsQueryable();

            if (payrollId.HasValue)
            {
                query = query.Where(p => p.PayrollDetail.PayrollId == payrollId);
            }

            if (payrollDetailId.HasValue)
            {
                query = query.Where(p => p.PayrollDetailId == payrollDetailId);
            }

            // Áp dụng sắp xếp
            query = query.ApplySorting(sortBy, orderBy);
            // Tính tổng số bản ghi
            int total = await query.CountAsync();
            // Áp dụng phân trang
            query = query.ApplyPaging(pageIndex, pageSize);

            var data = await _mapper.ProjectTo<PayrollInquiryDto>(query).ToListAsync();

            var result = new PagingResult<PayrollInquiryDto>(data, pageIndex, pageSize, sortBy, orderBy, total);

            return result;
        }

        private async Task<PayrollInquiry> GetPayrollInquiryAndCheckExist(int payrollInquiryId)
        {
            var payrollInquiry = await _dbContext.PayrollInquiries.FindAsync(payrollInquiryId);
            if (payrollInquiry is null)
                throw new EntityNotFoundException(nameof(PayrollInquiry), $"Id = {payrollInquiryId}");
            return payrollInquiry;
        }
    }
}
