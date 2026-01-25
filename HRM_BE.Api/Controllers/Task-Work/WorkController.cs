using Hangfire;
using HRM_BE.Api.Hubs;
using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Constants;
using HRM_BE.Core.Constants.Mail;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.ISeedWorks;
using HRM_BE.Core.Models.Common;
using HRM_BE.Core.Models.Mail;
using HRM_BE.Core.Models.Work;
using HRM_BE.Core.Models.WorkModel;
using HRM_BE.Core.Models.WorkModelModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using static System.Net.WebRequestMethods;

namespace HRM_BE.Api.Controllers.Task_Work
{
    [Route("api/work")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IJobHangFireService _jobHangFireService;
        private readonly IMailService _mailService;
        private readonly IHubContext<RemindWorkHub> _hubContext;
        public WorkController(IUnitOfWork unitOfWork, IFileService fileService, IJobHangFireService jobHangFireService, IMailService mailService, IHubContext<RemindWorkHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _fileService = fileService;
            _jobHangFireService = jobHangFireService;
            _mailService = mailService;
            _hubContext = hubContext;
        }
        [HttpPost("create")]
        public async Task<ApiResult<WorkDto>> Create([FromBody] CreateWorkRequest request)
        {
            var entity = await _unitOfWork.Works.Create(request);

            // gửi thông báo tới user
            //handle send notification realtime
            if ( entity.ExecutorId != null) // chỉ gửi thông báo khi có người tiếp nhận
            {
                #region xử lý thông báo sau khi tạo công việc có người thực hiện
                var connectionId = _unitOfWork.UserConnections.Find(uc => uc.EmployeeId == entity.ExecutorId).ToList();

                //var remindWork = _unitOfWork.RemindWorks.Find(s => s.WorkId == entity.Id).FirstOrDefault();
                var notiRemindEnd = await _unitOfWork.RemindWorkNotifications.CreateAsync(new RemindWorkNotification
                {
                    WorkId = entity.Id,
                    Content = $" Bạn vừa được giao công việc {entity.Name}",
                });
                foreach (var item in connectionId)
                {
                    await _hubContext.Clients.Client(item.ConnectionId).SendAsync("ReceiveWorkNotification", new {
                        content = $" Bạn vừa được giao công việc {entity.Name}",
                        WorkId = entity.Id
                    });
                }
                #endregion


                var userReceiMail = _unitOfWork.Employees.Find(s => s.Id == entity.ExecutorId).FirstOrDefault();

                if (request.RemindWork != null) // chỉ gửi nhắc việc khi có 
                {
                    await _jobHangFireService.ReSendRemindWorkNotification(entity.Id, userReceiMail.Id, entity.Name, entity.RemindWork.RemindWorkType,
                    entity.StartTime, entity.DueDate, entity.RemindWork.TimeRemindStart, entity.RemindWork.TimeRemindEnd);
                }


                string workName = entity.Name;
                string projectName = _unitOfWork.Projects.Find( p => p.Id ==  entity.ProjectId.Value ).FirstOrDefault().Name;
                var reporterEntity = _unitOfWork.Employees.Find(p => p.Id == entity.ReporterId.Value).FirstOrDefault();
                string reporterName = reporterEntity.LastName + reporterEntity.FirstName;
                string workDueDate = entity.DueDate.ToString();
                string workUrl = "https://hrm.smomedia.vn/";
                // gửi mail khi có người thực hiện
                BackgroundJob.Enqueue(() =>
                     _mailService.WorkSendMail(new SendMailRequest
                     {
                         Body = MailSendWorkBody.CreateBodyHTMLFormat(userReceiMail.CreatedName,reporterName,workName,workUrl,workDueDate,projectName),
                         ToEmail = userReceiMail.PersonalEmail,
                         Subject = "Thông báo công việc mới"
                     }));
            }




            return ApiResult<WorkDto>.Success("Tạo thành công công việc", entity);
        }
        [HttpPut("update")]
        public async Task<ApiResult<WorkDto>> Update([FromQuery] int id, [FromBody] UpdateWorkRequest request)
        {
            var entity = await _unitOfWork.Works.Update(id, request);
            if (entity.ExecutorId != null )
            { 
                #region   xử lý gửi thông báo sau khi cập nhật
                //var connectionId = _unitOfWork.UserConnections.
                //Find(uc => uc.EmployeeId == entity.ExecutorId).ToList();

                ////var remindWork = _unitOfWork.RemindWorks.Find(s => s.WorkId == entity.Id).FirstOrDefault();
                //var notiRemindEnd = await _unitOfWork.RemindWorkNotifications.CreateAsync(new RemindWorkNotification
                //{
                //    WorkId = entity.Id,
                //    Content = $" Công việc mà bạn được giao: {entity.Name} vừa cập nhật"
                //});
                //foreach (var item in connectionId)
                //{
                //    await _hubContext.Clients.Client(item.ConnectionId).SendAsync("ReceiveWorkNotification", notiRemindEnd);
                //}
                #endregion


                #region xử lý nhắc việc sau khi cập nhật
                var userReceiMail = _unitOfWork.Employees.Find(s => s.Id == entity.ExecutorId).FirstOrDefault();

                if (entity.RemindWork != null)
                {
                    await _jobHangFireService.ReSendRemindWorkNotification(entity.Id, userReceiMail.Id, entity.Name, entity.RemindWork.RemindWorkType,
                    entity.StartTime, entity.DueDate, entity.RemindWork.TimeRemindStart, entity.RemindWork.TimeRemindEnd);
                }

                string workName = entity.Name;
                string projectName = _unitOfWork.Projects.Find(p => p.Id == entity.ProjectId.Value).FirstOrDefault().Name;
                var reporterEntity = _unitOfWork.Employees.Find(p => p.Id == entity.ReporterId.Value).FirstOrDefault();
                string reporterName = reporterEntity.LastName + reporterEntity.FirstName;
                string workDueDate = entity.DueDate.ToString();
                string workUrl = "https://hrm.smomedia.vn/";

                BackgroundJob.Enqueue(() =>
                _mailService.WorkSendMail(new SendMailRequest
                {
                    Body = MailSendWorkBody.UpdateBodyHTMLFormat(userReceiMail.UpdatedName, reporterName, workName, workUrl, workDueDate, projectName),
                    ToEmail = userReceiMail.PersonalEmail,
                    Subject = "Thông báo chỉnh sửa công việc"
                }));
                #endregion
            }


            return ApiResult<WorkDto>.Success("Update thành công công việc", entity);
        }
        [HttpPut("delete")]
        public async Task<ApiResult<bool>> Delete(int workId)
        {
            await _unitOfWork.Works.Delete(workId);
            return ApiResult<bool>.Success("Xóa công việc thành công", true);
        }
        [HttpGet("paging")]
        public async Task<ApiResult<PagingResult<WorkDto>>> Paging([FromQuery] GetWorkPagingRequest request)
        {
            var result = await _unitOfWork.Works.Paging(request.KeyWork, request.OrderBy, request.SortBy, request.PageIndex, request.PageSize);
            return ApiResult<PagingResult<WorkDto>>.Success("Lấy danh sách công việc thành công", result);
        }
    }
}
