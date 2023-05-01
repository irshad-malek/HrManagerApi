using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Hrmanagement.Repository.Repository
{
    public class LeaveApplyRepository : ILeaveApply
    {
        private readonly HrManagerContext _context;

        public LeaveApplyRepository(HrManagerContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeVm>> GetEmployees()
        {
            //int id = 3007;
            //var leftFinal = from left in _context.Assignees
            //                join right in this._context.Employees on id equals right.EmpId into leftRights
            //                from leftRight in leftRights.DefaultIfEmpty()
            //                select new
            //                {
            //                    left.SIdNavigation.EmpId,
                               
            //                };
           


            return await this._context.Employees.Select(x => new EmployeeVm
            {
                EmpId = x.EmpId, 
                FirstName = x.FirstName,
                LastName = x.LastName


            }).ToListAsync();
        }

        //public List<LeaveApprovedVm> GetLeaveApproved()
        //    {
        //    //int id = 3007;
        //    //var data = (from ps1 in _context.Assignees
                        
        //    //            where id == ps1.JIdNavigation.EmpId
        //    //            select new
        //    //            {
        //    //                ps1.SIdNavigation.EmpId,
        //    //                ps1.SIdNavigation.Emp.FirstName
        //    //            }).First();
           
        //        return this._context.AprovedLeaves.Select(x => new LeaveApprovedVm
        //        {
        //            AId = x.AId,
        //            EmpId = x.EmpId,
        //            IsApproved = x.IsApproved

        //        }).ToList();
            
           
        //}

        public async Task<List<ManagerVm>> getManager(string email)
        {
           var employeeId= _context.Employees.Where(x=>x.EmailId==email).Select(x=>x.EmpId).First();
           var match= this._context.Managers.Where(x=>x.EmpId== employeeId).First();
           var data1= _context.Employees.Where(x => x.EmpId == match.EmpIdMgr).First();
                return await this._context.Managers.Where(x => x.ManagerId == match.ManagerId).Select(m => new ManagerVm
                {
                    ManagerId = m.ManagerId,
                    ManagerName=data1.FirstName
                    //FirstName = m.FirstName
                }).ToListAsync();
            
         
        }
        public async Task<List<LeaveVm>> GetLeaves()
        {
            return await this._context.Leaves.Select(x=>new LeaveVm { 
            LeaveId=x.LeaveId,
            LeaveTypeId =x.LeaveTypeId,
            Fromdate=x.Fromdate,
            ToDate=x.ToDate,
            Contact=x.Contact,
            Reason=x.Reason,
            EmpId = x.EmpId,
            ManagerId=x.ManagerId,
            //AId = x.AId,
            IsApply = x.IsApply,
            IsAccepted = x.IsAccepted
            }).ToListAsync();
        }

      

        public async Task<List<leaveTypeVm>> GetLeaveTypes()
        {
            return await this._context.LeaveTypes.Select(x => new leaveTypeVm
            {
                LeaveTypeId = x.LeaveTypeId,
                LeaveTypes = x.LeaveTypes
            }).ToListAsync();
        }

        public async Task<List<SessionVm>> GetSessions()
        {
            return await this._context.Sessions.Select(x => new SessionVm
            {
                SessionId = x.SessionId,
                Sessions = x.Sessions
            }).ToListAsync();
        }

        public async Task<int> saveLeave(LeaveVm leaveVm,string emailId)
        {
            Leave leave = new Leave();
            Manager manager = new Manager();
            leave.LeaveTypeId = leaveVm.LeaveTypeId;
            leave.Fromdate = leaveVm.Fromdate;
            leave.ToDate = leaveVm.ToDate;
            leave.SId = leaveVm.SId;
            leave.Contact = leaveVm.Contact;
            leave.Reason = leaveVm.Reason;
            leave.EmpId= _context.Employees.Where(x=>x.EmailId==emailId).Select(x=>x.EmpId).First();
            
            leave.ManagerId = _context.Managers.Where(x => x.EmpId == leave.EmpId).Select(x => x.ManagerId).First();
            leave.IsApply = true;
            leave.IsAccepted = false;
            await _context.AddAsync(leave);
            _context.SaveChangesAsync();
            return leave.LeaveId;
        }

        public int LeaveWithdraw(int leaveId, LeaveVm leaveVm)
        {
            Leave leave = new();
            if(leaveId > 0)
            {
                leave=_context.Leaves.FirstOrDefault(x=>x.LeaveId==leaveId);
                leave.IsApply=leaveVm.IsApply;
                _context.Leaves.Update(leave);
                _context.SaveChanges();
            }
            return leave.LeaveId;
        }
    }
}
