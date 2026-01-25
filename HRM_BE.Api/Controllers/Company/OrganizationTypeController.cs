using HRM_BE.Core.Constants;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Company;
using HRM_BE.Core.Models.Organization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Company
{
    [Route("api/organization-type")]
    [ApiController]
    public class OrganizationTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrganizationTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery]EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.OrganizationTypes.GetById(request.Id);
            return Ok(ApiResult<OrganizationTypeDto>.Success("Lấy thông tin cấp tổ chức thành công",result));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationTypeRequest request)
        {
           
            var createdOrganizationType = await _unitOfWork.OrganizationTypes.Create(request);
            return Ok(ApiResult<OrganizationTypeDto>.Success("Thêm công ty cấp tổ chức", createdOrganizationType));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateOrganizationTypeRequest request)
        {
            await _unitOfWork.OrganizationTypes.Update(id,request);
            return Ok(ApiResult<bool>.Success("Cập nhật cấp tổ chức thành công", true));
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.OrganizationTypes.GetAll();
            return Ok(ApiResult<List<OrganizationTypeDto>>.Success("Lấy danh sách thông tin cấp tổ chức thành công", result));
        }
    }
}
