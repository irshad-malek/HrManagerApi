using Hrmanagement.Common;
using Hrmanagement.DataModel.ViewModel;
using Hrmanagement.Repository.Entities;
using Hrmanagement.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace HRmanagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class leaveApplyController : ControllerBase
    {
        private readonly ILeaveApply leaveApply;

        public leaveApplyController(ILeaveApply leaveApply)
        {
            this.leaveApply = leaveApply;
        }

        [HttpGet]
        [Route("getLeave")]
        public async Task<ActionResult<Common<List<LeaveVm>>>> getLeave()
        {
            try
            {
                return Ok(new Common<IEnumerable<LeaveVm>>
                {
                    Data = await this.leaveApply.GetLeaves(),
                    Success = true,
                    Message = "data display succcessfully",
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        [HttpPost]
        [Route("leaveApplys/{emailId}")]
        public async Task<ActionResult<Common<int>>> leaveApplys(LeaveVm leaveVm,string emailId)
        {
            try
            {
                await this.leaveApply.saveLeave(leaveVm, emailId);
                return Ok(new Common<int>
                {
                    Success = true,
                    Message = "data saved succcessfully"
                });
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }
        [HttpGet]
        [Route("getLeaveType")]
        public async Task<ActionResult<Common<List<leaveTypeVm>>>> getLeaveType()
        {
            try
            {
                return Ok(new Common<IEnumerable<leaveTypeVm>>
                {
                    Data = await this.leaveApply.GetLeaveTypes(),
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
        [Route("getSession")]
        public async Task<ActionResult<Common<List<SessionVm>>>> getSession()
        {
            try
            {
                return Ok(new Common<IEnumerable<SessionVm>>
                {
                    Data = await this.leaveApply.GetSessions(),
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
        [Route("getEmployee")]
        public async Task<ActionResult<List<EmployeeVm>>> GetEmployee()
        {
            try
            {
                return Ok(new Common<IEnumerable<EmployeeVm>>
                {
                    Data = await this.leaveApply.GetEmployees(),
                    Success = true,
                    Message = "data display succcessfully"
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("getManager/{email}")]
        public async Task<ActionResult<Common<List<ManagerVm>>>> getManager(string email)
        {
            try
            {
                return Ok(new Common<IEnumerable<ManagerVm>>
                {
                    Data = await this.leaveApply.getManager(email),
                    Success = true,
                    Message = "data display succcessfully"
                });
            }
            catch (Exception e)
            {
               throw new Exception(e.Message);            
            }
        }
        
    }

}
