using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Repository
{
    public class ManagerRepository : IManager
    {
        public async Task<int> SaveManager(ManagerVm managerVm)
        {
            Manager manager = new Manager();
            manager.EmployeeRoleId = managerVm.EmployeeRoleId;
            manager.EmpIdMgr = managerVm.EmpIdMgr;
            manager.DeptId=managerVm.DeptId;
            manager.EffectiveFromDate = managerVm.EffectiveFromDate;
            manager.EffectiveFromDate=managerVm.EffectiveFromDate;
            manager.EmpId = managerVm.EmpId;
            return manager.ManagerId;
        }
    }
}
