using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Data.Content;
using HRM_BE.Core.Data.Identity;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Content.Banner;
using HRM_BE.Core.Constants;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HRM_BE.Core.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;


namespace HRM_BE.Api.Controllers
{
    [Route("api/banner")]
    [ApiController]
    public class BannerController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public BannerController(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork,IFileService fileService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _fileService = fileService;

        }
        [HttpGet("test")]
        public async Task<IActionResult> Test(int? id)
        {
            throw new EntityNotFoundException(nameof(_unitOfWork.Banners),id);
            var reuslt = await _unitOfWork.Banners.GetByIdAsync(id ?? 0);
            if (reuslt == null) throw new EntityNotFoundException($"Id:{id} không tìm thấy ");
            return Ok(reuslt);
        }

        [HttpGet("paging-v2")]
        public async Task<IActionResult> GetPaging2([FromQuery] GetBannerRequest request)
        {
            var result = await _unitOfWork.Banners.GetAllPaging(request.Place,request.Type, request.Title,request.SortBy, request.OrderBy,request.PageIndex, request.PageSize);

            return Ok( new ApiResult<PagingResult<BannerDto>>("Tạo thành công",result));
        }
        [HttpGet("paging")]
        public async Task<IActionResult> Get([FromQuery] GetBannerRequest request)
        {
            var result = await _unitOfWork.Banners.GetAllPaging(request.Place,request.Type, request.Title,request.SortBy, request.OrderBy,request.PageIndex, request.PageSize);
            if (result == null) return NotFound(new ApiResult<bool>("Lấy kết quả thất bại", false));
            return Ok(new ApiResult<PagingResult<BannerDto>>("Danh sách banner đã được lấy thành công!", result));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateBannerRequest request)
        {

            var banner = _mapper.Map<CreateBannerRequest, Banner>(request);

            banner.Priority = 1;
            banner.Alt=banner.Title;


            if (request.ImageFile?.Length > 0)
            {
                banner.Image = await _fileService.UploadFileAsync(request.ImageFile, PathFolderConstant.Banner);
            }
            else
            {
                banner.Image=ImageConstant.Avatar;
            }

            await _unitOfWork.Banners.CreateAsync(banner);

            await _unitOfWork.CompleteAsync();


            return Ok(new ApiResult<bool>());
;
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] EditBannerRequest request)
        {
            var banner = await _unitOfWork.Banners.GetByIdAsync(request.Id);

                
            if (banner == null) return BadRequest(new ApiResult<bool>(false, $"Không tìm thấy banner có id {request.Id}", false));

            if (request.ImageFile?.Length > 0)
            {
                request.Image = await _fileService.UploadFileAsync(request.ImageFile, PathFolderConstant.Banner);
                await _fileService.DeleteFileAsync(banner.Image);
            }
            else
            {
                request.Image = banner.Image;
            }

            _mapper.Map(request, banner);

            await _unitOfWork.CompleteAsync();


            return Ok(new ApiResult<bool>());


        }

        [HttpPut("delete")]
        public async Task<ApiResult<bool>> Delete([FromBody] EntityIdentityRequest<int> request)
        {
            var banner = await _unitOfWork.Banners.GetByIdAsync(request.Id);

            if (banner == null)
            {
                return new ApiResult<bool>()
                {
                    Status = false,
                    Message = "Không tìm thấy banner",
                    Data = false
                };
            }

            await _unitOfWork.Banners.DeleteAsync(banner);

            await _fileService.DeleteFileAsync(banner.Image);

            await _unitOfWork.CompleteAsync();

            return new ApiResult<bool>()
            {
                Status = true,
                Message = "Xoá banner thành công!",
                Data = true,
            };
        }

       
    }
}
