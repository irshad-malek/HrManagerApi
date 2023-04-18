using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
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

        public List<EmployeeVm> GetEmployees()
        {
            //int id = 3007;
            //var leftFinal = from left in _context.Assignees
            //                join right in this._context.Employees on id equals right.EmpId into leftRights
            //                from leftRight in leftRights.DefaultIfEmpty()
            //                select new
            //                {
            //                    left.SIdNavigation.EmpId,
                               
            //                };
           


            return this._context.Employees.Select(x => new EmployeeVm
            {
                EmpId = x.EmpId, 
                FirstName = x.FirstName,
                LastName = x.LastName


            }).ToList();
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

        public List<LeaveVm> GetLeaves()
        {
            return this._context.Leaves.Select(x=>new LeaveVm { 
            LeaveId=x.LeaveId,
            LeaveTypeId =x.LeaveTypeId,
            Fromdate=x.Fromdate,
            ToDate=x.ToDate,
            Contact=x.Contact,
            Reason=x.Reason,
            EmpId = x.EmpId,
            //AId = x.AId,
            IsApply = x.IsApply,
            IsAccepted = x.IsAccepted
            }).ToList();
        }

      

        public List<leaveTypeVm> GetLeaveTypes()
        {
            return this._context.LeaveTypes.Select(x => new leaveTypeVm
            {
                LeaveTypeId = x.LeaveTypeId,
                LeaveTypes = x.LeaveTypes
            }).ToList();
        }

        public List<SessionVm> GetSessions()
        {
            return this._context.Sessions.Select(x => new SessionVm
            {
                SId = x.SId,
                Sessions = x.Sessions
            }).ToList();
        }

        public int saveLeave(LeaveVm leaveVm)
        {
            Leave leave = new Leave();
            leave.LeaveTypeId = leaveVm.LeaveTypeId;
            leave.Fromdate = leaveVm.Fromdate;
            leave.ToDate = leaveVm.ToDate;
            leave.SId = leaveVm.SId;
            leave.Contact = leaveVm.Contact;
            leave.Reason = leaveVm.Reason;
            leave.EmpId= leaveVm.EmpId;
            //leave.AId = leaveVm.AId;
            leave.IsApply = true;
            leave.IsAccepted = false;
            _context.Add(leave);
            _context.SaveChanges();
            return leave.LeaveId;
        }
    }
}
