using HRM_BE.Core.Data.Payroll_Timekeeping.LeaveRegulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.LeaveRegulation
{
    public class TypeOfLeaveDto
    {
        public int Id { get; set; }
        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }//Tên loại

        public decimal? SalaryRate { get; set; }//Tỷ lệ hưởng lương

        public double? MaximumNumberOfDayOff { get; set; } //Số ngày nghỉ tối đa

        public string? Note { get; set; } //Ghi chú

        public ApplyObject ApplyObject { get; set; } // ĐỐi tượng áp dụng
    }
}
