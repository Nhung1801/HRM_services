using HRM_BE.Core.Data.Company;
using HRM_BE.Core.Data.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.Data.Profile
{
    public class Contract : EntityBase<int> 
    {
        public int? EmployeeId { get; set; }
        public string? NameEmployee { get; set; }
        public string? CodeEmployee { get; set; }
        public string? Code { get; set; }
        //public string? Unit { get; set; }
        public int? UnitId { get; set; }
        public string? Position { get; set; }
        public DateTime? SigningDate { get; set; }
        public string? ContractName { get; set; }
        public int? ContractTypeId { get; set; }
        public int? ContractDurationId { get; set; }
        public int? WorkingFormId { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Decimal? SalaryAmount { get; set; }
        public Decimal? SalaryInsurance { get; set; }
        public int? SalaryRate { get; set; }
        public int? CompanyRepresentativeSigningId { get; set; }
        public double? KpiSalary { get; set; } = 0;
        public string? CompanyRepresentativeSigning { get; set; }
        public string? Representative { get; set; }
        public string? Attachment { get; set; }
        public string? Note { get; set; }
        public SignStatus SignStatus { get; set; } = HRM_BE.Core.Data.Profile.SignStatus.NotSigned;
        public ContractTypeStatus ContractTypeStatus { get; set; } = ContractTypeStatus.Official;
        public bool? ExpiredStatus { get; set; } = false;
        public virtual ContractType? ContractType { get; set; }
        public virtual WorkingForm? WorkingForm { get; set; }
        public virtual ContractDuration? ContractDuration { get; set; }
        public virtual List<Allowance> Allowances { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Organization? Unit { get; set; }
        public virtual NatureOfLabor? NatureOfLabor { get; set; }

    }
    public enum SignStatus
    {
        Signed,
        NotSigned
    }
    public enum ContractTypeStatus
    {
        TryJob,
        Official
    }
}
