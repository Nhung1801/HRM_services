using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Payroll_Timekeeping.TimekeepingRegulation
{
    public class UpdateTimekeepingLocationRequest
    {
        public int? OrganizationId { get; set; } // tổ chức công ty

        public string? Name { get; set; }// Tên

        public string Latitude { get; set; }  //Vĩ độ  

        public string Longitude { get; set; }   // Kinh độ 

        public double AllowableRadius { get; set; }// Bán kính cho phép
    }
}
