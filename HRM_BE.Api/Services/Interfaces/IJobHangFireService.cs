using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.Data.Payroll_Timekeeping.TimekeepingRegulation;
using HRM_BE.Core.Data.Task;

namespace HRM_BE.Api.Services.Interfaces
{
    public interface IJobHangFireService
    {
        Task TriggerChangeLeaveNumber(int employeeId, int contractId, double NumberOffLeave);
        Task CreateTimeSheet(int employeeId, DateTime date, int shiftWorkId, double workingHours,TimeKeepingLeaveStatus timeKeepingLeaveStatus);
        void ScheduleRecurringJob(int employeeId, int contractId, int NumberOfLeave, DateTime startDay, DateTime endDay, int DayInMonth);
        Task UpdateExpireContractStatus(int contractId);

        Task ReSendRemindWorkNotification(int workId, int employeeId, string workName, RemindWorkType remindWorkType, DateTime? startDate, DateTime? dueDate, double? timeBefore, double? timeAfter);

    }
}
