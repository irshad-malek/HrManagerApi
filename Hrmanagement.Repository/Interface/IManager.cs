using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface IManager
    {
        Task<int> SaveManager(ManagerVm managerVm);
        Task<List<ManagerVm>> GetAllManagerList();
        //Task<List<ManagerVm>> getManagerById(int id);

        Manager GetManagerById(int id);
        Task<int> updateMangers(int id, ManagerVm managerVm);

        List<LeaveVm> LeaveApproved(string emailId);

        List<LeaveVm> LeaveApprovedByManager(string emailId);
        int LeaveApprovedSave(int leaveId,LeaveVm leaveVm);

    }
}
