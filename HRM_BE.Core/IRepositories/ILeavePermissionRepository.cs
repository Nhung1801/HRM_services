using HRM_BE.Core.Data.Official_Form;
using HRM_BE.Core.ISeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_BE.Core.IRepositories
{
    public interface ILeavePermissionRepository:IRepositoryBase<LeavePermission, int>
    {
        Task TriggerCreateLeavePermission(int employeeId, int contractId,int numberOfLeave ,DateTime start,DateTime end);
        Task TriggerUpdateNumberLeavePermission(int employeeId,double numberOfLeave,DateTime startDate, DateTime endDate);

        Task<double> CountDayOff(int employeeId);

    }
}
