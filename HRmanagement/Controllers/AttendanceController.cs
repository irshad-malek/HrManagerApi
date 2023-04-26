using Hrmanagement.Common;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendance attendance;

        public AttendanceController(IAttendance attendance)
        {
            this.attendance = attendance;
        }

        [HttpPost]
        [Route("saveAttendance")]

        public async Task<ActionResult<Common<int>>> saveAttendance(AttendanceVm attendanceVm)
        {
            try
            {
                await attendance.SaveUserAttendance(attendanceVm);
                return Ok(new Common<IEnumerable<AttendanceVm>>
                {
                    Success = true,
                    Message = "data saved succcessfully",
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
