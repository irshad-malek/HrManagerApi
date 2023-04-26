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
       Task<List<LeaveVm>>  GetLeaves();

        Task<int> saveLeave(LeaveVm leaveVm,string emailId);

        Task<List<leaveTypeVm>> GetLeaveTypes();

        Task<List<SessionVm>> GetSessions();
        Task<List<EmployeeVm>> GetEmployees();

        //List<LeaveApprovedVm> GetLeaveApproved();
        Task<List<ManagerVm>> getManager(string email);


    }
}
