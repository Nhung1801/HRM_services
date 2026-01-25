using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class CreateApplyOrganizationRequest
    {
        public int? TimekeepingSettingId { get; set; }//Bảng chấm công
        public int? OrganizationId { get; set; } // tổ chức công ty
        public TimekeepingLocationOption TimekeepingLocationOption { get; set; }//Chọn loại địa điểm
        public TimekeepingType? TimekeepingType { get; set; }
        public int? TimekeepingLocationId { get; set; } // ID địa điểm cố định
        // Yêu cầu xác thực thêm bằng phương pháp khác
        public bool? RequireFaceVerification { get; set; } // Xác thực bằng khuôn mặt
        public bool? RequireDocumentAttachment { get; set; } // Đính kèm tài liệu xác thực
        public bool? RequireManagerApproval { get; set; } // Yêu cầu quản lý xác nhận
    }
}
