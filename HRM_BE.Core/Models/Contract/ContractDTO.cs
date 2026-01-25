using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Models.Contract;
using HRM_BE.Core.Models.Contract.Allowance;
using HRM_BE.Core.Models.Organization;
using HRM_BE.Core.Models.Profile.ContractDuration;
using HRM_BE.Core.Models.Profile.ContractType;
using HRM_BE.Core.Models.Staff;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Models.Profile
{
    public class ContractDTO
    {
        public int? Id { get; set; }
        public int? EmployeeId { get; set; }
        public string? NameEmployee { get; set; }
        public string? CodeEmployee { get; set; }
        public string? Code { get; set; }
        public int? UnitId { get; set; }
        public string? Position { get; set; }
        public DateTime? SigningDate { get; set; }
        public string? ContractName { get; set; }
        public int? ContractTypeId { get; set; }
        public string? ContractTypeName {  get; set; }
        public int? ContractDurationId { get; set; }
        public ContractDurationDto? ContractDuration { get; set; }
        public int? WorkingFormId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Decimal? SalaryAmount { get; set; }
        public Decimal? SalaryInsurance { get; set; }
        public double? KpiSalary { get; set; }
        public int? SalaryRate { get; set; }
        public int? CompanyRepresentativeSigningId { get; set; }
        public string? CompanyRepresentativeSigning { get; set; }
        public string? Representative { get; set; }
        public string? Attachment { get; set; }
        public string? Note { get; set; }
        public SignStatus SignStatus { get; set; }
        public bool? ExpiredStatus { get; set; } = false;

        public ContractTypeDto ContractType { get; set; }
        public ContractTypeStatus ContractTypeStatus { get; set; }

        public virtual ContractOrganizationDto? Unit { get; set; }
        public GetContractEmployeeDto? Employee { get; set; }
        //public virtual HRM_BE.Core.Data.Profile.ContractType? ContractType { get; set; }
        //public virtual HRM_BE.Core.Data.Profile.WorkingForm? WorkingForm { get; set; }
        //public virtual HRM_BE.Core.Data.Profile.ContractDuration? ContractDuration { get; set; }
        public virtual List<AllowanceDto> Allowances { get; set; }
        public decimal? TotalAllowance { get; set; }
    }
}
