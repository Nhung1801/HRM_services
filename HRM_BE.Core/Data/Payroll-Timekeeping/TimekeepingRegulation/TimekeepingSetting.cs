using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation
{
    //Bảng thiết lập chấm công
    public class TimekeepingSetting:EntityBase<int>
    {   
        public int? OrganizationId { get; set; } // tổ chức công ty

        public AllowApplication? AllowApplication { get; set; }

        //public virtual ICollection<TimekeepingType> TimekeepingTypes { get; set; }
        public TimekeepingType? TimekeepingType { get; set; }

        public virtual Organization Organization { get; set; }
    }

    public enum AllowApplication
    {
        None,
        Website,
        Mobile,
        Both
    }

    public enum TimekeepingType
    {
        GPS,
        TimekeepingMachine
    }


    //Bảng các cách chấm công (vd: GPS, Máy chấm công)
    //public class TimekeepingType:EntityBase<int>
    //{

    //    //Chấm công áp dụng
    //    public int TimekeepingSettingId {  get; set; }

    //    public string Name { get; set; }//Tên

    //    public virtual TimekeepingSetting TimekeepingSetting { get; set; }


    //}

    //Bảng địa điểm chấm công bằng  cách chấm công GPS
    public class TimekeepingLocation : EntityBase<int>
    {
        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }// Tên

        public string Latitude { get; set; }  //Vĩ độ  

        public string Longitude { get; set; }   // Kinh độ 

        public double AllowableRadius {get; set;}// Bán kính cho phép

        public virtual Organization Organization { get; set; }

    }


    //Tổ chức áp dụng
    public class ApplyOrganization:EntityBase<int>
    {
        public int TimekeepingSettingId { get; set; }//Bảng chấm công

        public int? OrganizationId { get; set; } // tổ chức công ty
        public int? TimekeepingLocationId { get; set; }

        public TimekeepingLocationOption TimekeepingLocationOption { get; set; }//Chọn loại địa điểm
        public TimekeepingType? TimekeepingType { get; set; }


        // Yêu cầu xác thực thêm bằng phương pháp khác
        public bool? RequireFaceVerification { get; set; } // Xác thực bằng khuôn mặt
        public bool? RequireDocumentAttachment { get; set; } // Đính kèm tài liệu xác thực
        public bool? RequireManagerApproval { get; set; } // Yêu cầu quản lý xác nhận

        public virtual TimekeepingSetting TimekeepingSetting { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual TimekeepingLocation? TimekeepingLocation { get; set; }
        public virtual ICollection<ApplyEmployeeTimekeepingSetting> ApplyEmployeeTimekeepingSettings { get; set; }

    }

    public enum TimekeepingLocationOption
    {
        Fix,//Cố định
        NotFix //Không có định
    }

    

    //Nhân viên áp dụng
    public class ApplyEmployeeTimekeepingSetting : EntityBase<int>
    {
        public int ApplyOrganizationId { get; set; } //id tổ  chức áp dụng

        public int  EmployeeId { get; set; } //id nhân viên

        public virtual ApplyOrganization ApplyOrganization { get; set; }

        public virtual Employee Employee { get; set; }

    }
}
