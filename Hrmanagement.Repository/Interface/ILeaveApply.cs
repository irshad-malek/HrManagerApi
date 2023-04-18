using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface ILeaveApply
    {
        List<LeaveVm>  GetLeaves();

        int saveLeave(LeaveVm leaveVm);

        List<leaveTypeVm> GetLeaveTypes();

        List<SessionVm> GetSessions();
        List<EmployeeVm> GetEmployees();

        //List<LeaveApprovedVm> GetLeaveApproved();


    }
}
