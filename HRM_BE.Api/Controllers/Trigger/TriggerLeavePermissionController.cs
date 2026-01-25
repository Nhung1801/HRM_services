using HRM_BE.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRM_BE.Api.Controllers.Trigger
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggerLeavePermissionController : ControllerBase
    {
        private readonly IJobHangFireService _jobHangFire;

        public TriggerLeavePermissionController(IJobHangFireService jobHangFire)
        {
            _jobHangFire = jobHangFire;
        }
        //[HttpGet("trigger-change-number")]
        //public IActionResult TriggerChangeLeaveNumber(int employeeId, int contractId, double NumberOffLeave)
        //{
        //    _jobHangFire.TriggerChangeLeaveNumber(employeeId, contractId, NumberOffLeave);
        //    return Ok();
        //}
    }
}
