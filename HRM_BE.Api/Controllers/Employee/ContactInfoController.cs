using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Profile.ContactInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Employee
{
    [Route("api/contact-info")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactInfoController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost("create")]
        public async Task<ContactInfoDto> Create(CreateContactInfoRequest request)
        {
            var result = await _unitOfWork.ContactInfos.Create(request);
            return result;
        } 
        [HttpPut("update")]
        public async Task<IActionResult> Update(int id, UpdateContactInfoRequest request)
        {
            await _unitOfWork.ContactInfos.Update(id,request);
            return Ok(ApiResult<bool>.Success("Cập nhật thông tin liên hệ thành công",true));
        }
    }
}
