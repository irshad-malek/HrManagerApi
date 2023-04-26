using Hrmanagement.Common;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
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
        [HttpGet]
        [Route("getAllAttendanceDetails")]
        public async Task<ActionResult<Common<List<AttendanceVm>>>> getAllAttendanceDetails()
        {
            try
            {
               
                return Ok(new Common<IEnumerable<AttendanceVm>>
                {
                    Data = await this.attendance.getAllAtendance(),
                    Success = true,
                    Message = "data display succcessfully",
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpGet]
        [Route("getAllAttendanceSpecific/{emailId}")]
        public async Task<ActionResult<Common<List<AttendanceVm>>>> getAllAttendanceSpecific(string emailId)
        {
            try
            {

                return Ok(new Common<IEnumerable<AttendanceVm>>
                {
                    Data = await this.attendance.specificAttendance(emailId),
                    Success = true,
                    Message = "data display succcessfully",
                });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
