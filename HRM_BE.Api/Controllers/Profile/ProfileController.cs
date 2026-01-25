using AutoMapper;
using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Profile
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public ProfileController(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileService = fileService;
        }

        /// <summary>
        /// BE - HRM - là Admin/HR tôi muốn xem danh sách hồ sơ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("paging")]
        public async Task<PagingResult<EmployeeDto>> Paging([FromQuery] GetProfilePagingRequest request)
        {
            var result = await _unitOfWork.Profiles.Paging(request.workingStatus, request.employeeId, request.organizationId, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return result;
        }
        //[HttpGet("all")]
        //public async Task<List<EmployeeDto>> GetAll([FromQuery] GetProfilePagingRequest request)
        //{
        //    var result = await _unitOfWork.Profiles.GetAll(request.workingStatus, request.employeeId, request.SortBy, request.OrderBy);
        //    return result;
        //}
    }
}
