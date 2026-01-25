using HRM_BE.Core.Data.Profile;
using HRM_BE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

namespace HRM_BE.Core.Models.Profile
{
    public class CreateContractRequest
    {
        public int? EmployeeId { get; set; }
        public string? NameEmployee { get; set; }
        public string? CodeEmployee { get; set; }
        [JsonIgnore]
        public string? Code { get; set; }
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
        public double? KpiSalary { get; set; }
        public int? SalaryRate { get; set; }
        public int? CompanyRepresentativeSigningId { get; set; }
        public string? CompanyRepresentativeSigning { get; set; }
        public string? Representative { get; set; }
        [JsonIgnore]
        public string? Attachment { get; set; }
        public IFormFile? AttachmentFile { get; set; }
        public string? Note { get; set; }
        public SignStatus? SignStatus { get; set; }

        //public virtual HRM_BE.Core.Data.Profile.ContractType? ContractType { get; set; }
        //public virtual HRM_BE.Core.Data.Profile.WorkingForm? WorkingForm { get; set; }
        //public virtual HRM_BE.Core.Data.Profile.ContractDuration? ContractDuration { get; set; }
        //public virtual List<Allowance> Allowances { get; set; }

    }
    public enum SignStatus
    {
        Signed,
        NotSigned
    }
}