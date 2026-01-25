using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Organization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HRM_BE.Api.Controllers.Company
{
    [Route("api/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        public OrganizationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Organizations.GetById(request.Id);
            return Ok(ApiResult<OrganizationDto>.Success("Lấy thông tin tổ chức thành công", result));
        }
        //[HttpGet("paging")]
        //public async Task<ApiResult<PagingResult<GetOrganizationDto>>> Paging([FromQuery] GetPagingOrganizationRequest request)
        //{
        //    var result = await _unitOfWork.Organizations.GetAll(request.keyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
        //    return ApiResult<PagingResult<GetOrganizationDto>>.Success("Lấy danh sách tổ chức thành công", result);
        //}

        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<GetOrganizationDto>>> Paging([FromQuery] GetPagingOrganizationRequest request)
        {
            var result = await _unitOfWork.Organizations.Paging(request.keyWord, request.SortBy, request.OrderBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<GetOrganizationDto>>.Success("Lấy danh sách tổ chức thành công", result);
        }

        [HttpGet("get-select")]
        public async Task<IActionResult> GetSelect([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Organizations.GetSelect(request.Id);
            return Ok(ApiResult<OrganizationSelectDto>.Success("Lấy thông tin tổ chức thành công", result));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationRequest request)
        {

            var createdOrganization = await _unitOfWork.Organizations.Create(request);
            return Ok(ApiResult<OrganizationDto>.Success("Thêm tổ chức thành công", createdOrganization));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrganizationRequest request)
        {
            await _unitOfWork.Organizations.Update(id, request);
            return Ok(ApiResult<bool>.Success("Cập nhật tổ chức thành công",true));
        }
        [HttpPut("delete")]
        public async Task<IActionResult> Delete(int organizationId)
        {
            await _unitOfWork.Organizations.Delete(organizationId);
            return Ok(ApiResult<bool>.Success("Xoá tổ chức thành công",true));
        }
    }
}
