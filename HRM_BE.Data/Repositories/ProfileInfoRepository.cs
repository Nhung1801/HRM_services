using AutoMapper;
using HRM_BE.Core.Data.ProfileEntity;
using HRM_BE.Core.Exceptions;
using HRM_BE.Core.IRepositories;
using HRM_BE.Core.Models.ProfileInfoModel;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRM_BE.Data.Repositories
{
    public class ProfileInfoRepository : RepositoryBase<ProfileInfo, int>, IProfileInfoRepository
    {
        private readonly IMapper _mapper;
        public ProfileInfoRepository(HrmContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
            _mapper = mapper;
        }

        public async Task<ProfileInfoDto> Create(CreateProfileInfoRequest request)
        {
            var entity = _mapper.Map<ProfileInfo>(request);
            var entityReturn = await CreateAsync(entity);
            return _mapper.Map<ProfileInfoDto>(entityReturn);
        }

        public Task Delete(int profileId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProfileInfoDto> GetById(int profileId)
        {
            var entity = await GetProfileInfoAndCheckExsit(profileId);
            return _mapper.Map<ProfileInfoDto>(entity);
        }

        public async Task Update(int profileId, UpdateProfileInfoRequest request)
        {
            var entity = await GetProfileInfoAndCheckExsit(profileId);
            await UpdateAsync(_mapper.Map(request, entity));
        }
        private async Task<ProfileInfo> GetProfileInfoAndCheckExsit(int profileInfoId)
        {
            var profile = await _dbContext.ProfileInfos.FindAsync(profileInfoId);
            if (profile is null)
                throw new EntityNotFoundException(nameof(ProfileInfo), $"Id = {profileInfoId}");
            return profile;
        }

        public async Task UpdateV2(int profileInfoId, UpdateProfileInfoRequestV2 request)
        {

            var profileInfo = await _dbContext.ProfileInfos.Include(p => p.Employee)
                                                            .FirstOrDefaultAsync(p => p.Id == profileInfoId);

            if (profileInfo is null)
                throw new EntityNotFoundException(nameof(ProfileInfo), $"Id = {profileInfoId}");

            _mapper.Map(request, profileInfo);

            if (profileInfo.Employee != null)
            {
                profileInfo.Employee.AvatarUrl = request.AvatarUrl;
                profileInfo.Employee.FirstName = request.FirstName;
                profileInfo.Employee.LastName = request.LastName;
                profileInfo.Employee.DateOfBirth = request.DateOfBirth;
                profileInfo.Employee.Sex = request.Sex;
                profileInfo.Employee.PhoneNumber = request.PhoneNumber;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
