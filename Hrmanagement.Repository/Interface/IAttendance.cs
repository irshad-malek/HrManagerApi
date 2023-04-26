using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrmanagement.Repository.Interface
{
    public interface IAttendance 
    {
        Task<int> SaveUserAttendance(AttendanceVm attendanceVm);

        Task<List<AttendanceVm>>  specificAttendance(string emailId);

        Task<List<AttendanceVm>> getAllAtendance();

    }
}
