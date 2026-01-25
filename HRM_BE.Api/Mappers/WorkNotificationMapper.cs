using AutoMapper;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Work;
using HRM_BE.Core.Models.WorkNotification;

namespace HRM_BE.Api.Mappers
{
    public class WorkNotificationMapper:Profile
    {
        public WorkNotificationMapper()
        {
            CreateMap<RemindWorkNotification, RemindWorkNotificationDto>().ReverseMap();
        }
    }
}
