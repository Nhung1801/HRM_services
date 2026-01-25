using HRM_BE.Core.Data.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation
{
    //Bảng Loại ngày nghỉ
    public class TypeOfLeave:EntityBase<int>
    {
        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }//Tên loại

        public decimal? SalaryRate { get; set; }//Tỷ lệ hưởng lương

        public double? MaximumNumberOfDayOff { get; set; } //Số ngày nghỉ tối đa

        public string? Note {  get; set; } //Ghi chú

        public ApplyObject ApplyObject { get; set; } // ĐỐi tượng áp dụng

        public virtual Organization Organization { get; set; }

    }

    //Đối tượng áo dụng option
    public enum ApplyObject
    {
        CompanyWide,//Toàn công ty
        OrganizationalStructure//Cơ cấu tổ chức
    }
}
