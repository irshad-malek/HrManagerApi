using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Repository
{
    public class ManagerRepository : IManager
    {
        private readonly HrManagerContext _context;


        public ManagerRepository(HrManagerContext context)
        {
            _context = context;
        }


        public async Task<List<ManagerVm>> GetAllManagerList()
        {
            return await this._context.Managers.Select(m => new ManagerVm
            {
                ManagerId = m.ManagerId,
                EmployeeRoleId = m.EmployeeRoleId,
                EmployeeRoleName = m.EmployeeRole.EmployeeRoleName,
                EmpIdMgr = m.EmpIdMgr,
                EmployeeName = m.Emp.FirstName,
                ManagerName = m.EmpIdMgrNavigation.FirstName,
                EffectiveFromDate = m.EffectiveFromDate,
                EffectiveToDate = m.EffectiveToDate,
                IsActive = m.IsActive,


            }).ToListAsync();
        }

        public async Task<int> SaveManager(ManagerVm managerVm)
        {
            Manager manager = new Manager();
            if (managerVm != null)
            {
                manager.EmployeeRoleId = managerVm.EmployeeRoleId;
                manager.EmpIdMgr = managerVm.EmpIdMgr;
                manager.DeptId = managerVm.DeptId;
                manager.EffectiveFromDate = managerVm.EffectiveFromDate;
                manager.EffectiveToDate = managerVm.EffectiveToDate;
                manager.EmpId = managerVm.EmpId;
                await _context.Managers.AddAsync(manager);
                _context.SaveChanges();
            }
            return manager.ManagerId;
        }

        public  Manager GetManagerById(int id)
        {
            return  this._context.Managers.Find(id);
        }

        public async Task<int> updateMangers(int id,ManagerVm managerVm)
        {
            Manager manager = new ();
            if (id > 0)
            {

                manager = _context.Managers.FirstOrDefault(t => t.ManagerId == id);
                manager.EmpIdMgr= managerVm.EmpIdMgr;
                manager.DeptId= managerVm.DeptId;
                manager.EffectiveFromDate = managerVm.EffectiveFromDate;
                manager.EffectiveToDate = managerVm.EffectiveToDate;
                manager.EmpId = managerVm.EmpId;
                manager.IsActive = managerVm.IsActive;
                
                _context.Managers.Update(manager);
                 await _context.SaveChangesAsync();
                //hrManagerContext.Employees.Update(emp);
                //hrManagerContext.SaveChanges();
            }
            return manager.ManagerId;
        }
    }


}
