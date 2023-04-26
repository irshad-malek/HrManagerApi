using Hrmanagement.Repository.Data;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using System;
using System.Collections.Generic;
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
    }
}
