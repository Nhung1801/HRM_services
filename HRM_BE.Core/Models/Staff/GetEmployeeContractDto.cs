using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Profile.ContractType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Staff
{
    public class GetEmployeeContractDto
    {
        public int Id { get; set; }
        public string ContractName { get; set; }
        public ContractTypeDto ContractType { get; set; }
        public List<GetAllowanceEmployeeDto> Allowances { get; set; }
    }
}
