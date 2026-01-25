using AutoMapper;
using HRM_BE.Core.Data.Staff;
using HRM_BE.Core.Data.Task;
using HRM_BE.Core.Models.Approval;
using HRM_BE.Core.Models.CheckList;
using HRM_BE.Core.Models.RemindWork;
using HRM_BE.Core.Models.SubWork;
using HRM_BE.Core.Models.Tag;
using HRM_BE.Core.Models.Work;
using HRM_BE.Core.Models.WorkModel;
using HRM_BE.Core.Models.WorkModelModel;
using System.ComponentModel.Design;

namespace HRM_BE.Api.Mappers
{
    public class WorkMapper:Profile
    {
        public WorkMapper()
        {
            CreateMap<CreateWorkRequest, Work>();
            CreateMap<UpdateWorkRequest, Work>();
            CreateMap<ApprovalEmployee, ApprovalEmployeeDto>();
            CreateMap<Work,WorkDto>();
            CreateMap<CreateCheckListRequest, CheckList>();
            CreateMap<CreateApprovalRequest,Approval>();
            CreateMap<CreateSubWorkRequest, SubWork>();
            CreateMap<CreateTagRequest, Tag>();
            CreateMap<CreateRemindWorkRequest, RemindWork>();
            CreateMap<WorkAssignment,WorkAssignmentDto>();
            CreateMap<CreateWorkAssignmentRequest, WorkAssignment>();

            CreateMap<Employee,ExecutorWorkDto>();

            CreateMap<CreateTagWorkRequest,TagWork>();

            CreateMap<Approval,ApprovalWorkDto>();
            CreateMap<Employee,ReportWorkDto>();
            CreateMap<SubWork,SubWorkDto>();
            CreateMap<TagWork, TagWorkDto>()
                .ForMember( src => src.Name , opt => opt.MapFrom( dest => dest.Tag.Name))
                .ForMember(src => src.Color , opt => opt.MapFrom( dest => dest.Tag.Color));
            CreateMap<RemindWork, RemindWorkDto>();
            CreateMap<CheckList, CheckListWorkDto>();
        }
    }
}
