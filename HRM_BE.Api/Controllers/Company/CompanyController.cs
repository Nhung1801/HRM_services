using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Constants;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Company;
using HRM_BE.Data.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Company
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        public CompanyController(IUnitOfWork unitOfWork, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }
        [HttpGet("get-tree")]
        public async Task<ApiResult<CompanyDto>> GetTree([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Companies.GetTree(request.Id);
            return ApiResult<CompanyDto>.Success("Lấy thông tin công ty thành công", result);
        }
        [HttpGet("get-by-id",Name = "CompanyById")]

        public async Task<IActionResult> GetById([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = await _unitOfWork.Companies.GetById(request.Id);
            return Ok(ApiResult<CompanyDto>.Success("Lấy thông tin công ty thành công", result));
        }
        [HttpGet("paging")]

        public async Task<IActionResult> Paging([FromQuery] GetPagingCompanyRequest request)
        {
            var result = await _unitOfWork.Companies.GetPaging(request.keyWord,
                request.SortBy,request.OrderBy,request.PageIndex,request.PageSize);
            return Ok(ApiResult<PagingResult<CompanyDto>>.Success("Lấy danh sách thông tin công ty thành công", result));
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateCompanyRequest request)
        {
            if (request.LogoImage != null)
            {
                request.LogoPath = await _fileService.UploadFileAsync(request.LogoImage, PathFolderConstant.Company);
            }
            else request.LogoPath = ImageConstant.Company;
            var createdCompany = await _unitOfWork.Companies.Create(request);
            return Ok(ApiResult<CompanyDto>.Success("Thêm công ty thành công", createdCompany));
        }
        [HttpPut("update")]
        public async Task<IActionResult> update(int companyId, [FromForm] UpdateCompanyRequest request)
        {
            if (request.LogoImage != null) {
                request.LogoPath = await _fileService.UploadFileAsync(request.LogoImage, PathFolderConstant.Company); 
            }
            await _unitOfWork.Companies.Update(companyId, request);
            return Ok(ApiResult<bool>.Success("Cập nhật công ty thành công",true));
        }

        [HttpPut("delete")]
        public async Task<IActionResult> Delete([FromQuery] EntityIdentityRequest<int> request)
        {
            var result = _unitOfWork.Companies.Delete(request.Id);
            return Ok(ApiResult<bool>.Success("Xoá công ty thành công",true));
        }

    }
}
