namespace HRM_BE.Core.Models.Payroll_Timekeeping.Payroll
{
    public class UpdatePayrollDetailRequest
    {
        public decimal? BaseSalary { get; set; }
        public int? StandardWorkDays { get; set; }
        public double? ActualWorkDays { get; set; }

        public decimal? KPI { get; set; }
        public decimal? KpiPercentage { get; set; }
        public decimal? Bonus { get; set; }
        public decimal? SalaryRate { get; set; }
    }
}

