using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Repository
{
    public class AttendanceRepository : IAttendance
    {
        private readonly HrManagerContext _context;

        public AttendanceRepository(HrManagerContext context)
        {
            _context = context;
        }

        public async Task<List<AttendanceVm>> getAllAtendance()
        {
            return  this._context.Attendances.Select(x=>new AttendanceVm
            {
                AttendanceId=x.AttendanceId,
                Status = x.Status,
                InTime = x.InTime,
                OutTime = x.OutTime,
                EmpId = x.EmpId,
                Name=x.Emp.FirstName
            }).ToList();
        }

        public async Task<int> SaveUserAttendance(AttendanceVm attendanceVm)
        {
           Attendance attendance = new Attendance();
            if(attendanceVm != null)
            {
                attendance.InTime = attendanceVm.InTime;
                attendance.OutTime = attendanceVm.OutTime;
                attendance.Status = attendanceVm.Status;
                attendance.EmpId = _context.Employees.Where(x=>x.EmailId==attendanceVm.emailId).Select(x=>x.EmpId).First();
                await _context.AddAsync(attendance);
                _context.SaveChangesAsync();               
            }

            return attendance.AttendanceId;


        }

        public async Task<List<AttendanceVm>> specificAttendance(string emailId)
        {
            return  this._context.Attendances.Where(x => x.EmpId == _context.Employees.Where(x => x.EmailId == emailId).Select(x => x.EmpId).First()).Select(x => new AttendanceVm
            {
                AttendanceId = x.AttendanceId,
                Status = x.Status,
                EmpId = x.EmpId,
                InTime = x.InTime,
                OutTime = x.OutTime,
            }).ToList();
        }
  
    }
}
