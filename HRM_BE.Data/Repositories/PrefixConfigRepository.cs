using AutoMapper;
using HRM_BE.Core.Data;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.PrefixConfig;
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
    public class PrefixConfigRepository : RepositoryBase<PrefixConfig, int>, IPrefixConfigRepository
    {
        private readonly IMapper _mapper;

        public PrefixConfigRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task Create(CreatePrefixConfigRequest prefixConfig)
        {
            var entity = _mapper.Map<PrefixConfig>(prefixConfig);
            var entityCreated = await CreateAsync(entity);
        }

        public async Task<PrefixConfigDto> GetByKey(string key)
        {
            var entity = await _dbContext.PrefixConfigs.Where(s => s.Key == key).FirstOrDefaultAsync();
            return _mapper.Map<PrefixConfigDto>(entity);
        }

        public async Task Update(int id, UpdatePrefixConfigRequest request)
        {
            var entity = await _dbContext.PrefixConfigs.FindAsync(id);
            _mapper.Map(request, entity);

            await UpdateAsync(entity);

        }
        public async Task<string> GetAndUpdatePrefix(string key, string prefixFormat = "SMO")
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            var entity = await _dbContext.PrefixConfigs
                .Where(s => s.Key == key)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                // Nếu chưa có prefix cho key này, tạo mới
                entity = new PrefixConfig
                {
                    Key = key,
                    Value = "0001"
                };

                await _dbContext.PrefixConfigs.AddAsync(entity);
            }
            else
            {
                // Tăng giá trị hiện tại lên 1
                var nextValue = int.Parse(entity.Value) + 1;
                entity.Value = nextValue.ToString("D4"); // Định dạng thành 3 chữ số
            }

            // Lưu thay đổi
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            // Trả về mã đầy đủ (ví dụ: SMO001)
            return $"{prefixFormat}{entity.Value}";
        }

        private async Task<PrefixConfig> GetByIdAndCheckExsit(int id)
        {
            var entity = await _dbContext.PrefixConfigs.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (entity == null)
                throw new EntityNotFoundException("PrefixConfig not found");

            return entity;
        }
    }
}
