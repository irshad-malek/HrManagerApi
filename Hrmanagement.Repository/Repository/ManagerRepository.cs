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

        public List<LeaveVm> LeaveApproved(string emailId)
        {
            return this._context.Leaves.Where(x=>x.Emp.EmailId==emailId && x.IsApply==true).Select(x => new LeaveVm
            {
                LeaveId = x.LeaveId,
                LeaveTypeId = x.LeaveTypeId,
                Fromdate = x.Fromdate,
                ToDate = x.ToDate,
                Reason = x.Reason,
                SeniorEmpName=x.Manager.EmpIdMgrNavigation.FirstName,
                Contact=x.Contact,
                FirstName=x.Emp.FirstName,
                SId=x.SId,
                LeaveType=x.LeaveType.LeaveTypes,
                IsAccepted=x.IsAccepted,
                EmpId=x.EmpId,
                IsApply=x.IsApply,

            }).Where(x=>x.IsAccepted==false).ToList();
        }

        public List<LeaveVm> LeaveApprovedByManager(string emailId)
        {
            var dataobject = (from ME in _context.Leaves
                              join RT in _context.Managers on ME.ManagerId equals RT.ManagerId
                              where RT.EmpIdMgrNavigation.EmailId==emailId

                              select new LeaveVm
                              {
                                  LeaveId=ME.LeaveId,
                                 LeaveType=ME.LeaveType.LeaveTypes,
                                 Fromdate=ME.Fromdate,
                                 ToDate=ME.ToDate,
                                 Contact=ME.Contact,
                                 Reason=ME.Reason,
                                 IsApply=ME.IsApply,
                                 FirstName=ME.Emp.FirstName,
                                 IsAccepted=ME.IsAccepted,


                              }).Where(x=>x.IsAccepted==false).ToList();

            return dataobject;
        }

        public int LeaveApprovedSave(int leaveId,LeaveVm leaveVm)
        {
            Leave leave = new();
            if(leaveId>0)
            {
                leave = _context.Leaves.FirstOrDefault(x => x.LeaveId == leaveId);
                leave.IsAccepted = leaveVm.IsAccepted;

                _context.Leaves.Update(leave);
                _context.SaveChanges();
            }
            return leave.LeaveId;
        }
    }


}
