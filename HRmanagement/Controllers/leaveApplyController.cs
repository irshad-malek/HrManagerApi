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
        public List<LeaveVm> getLeave()
        {
            return this.leaveApply.GetLeaves();
        }

        [HttpPost]
        [Route("leaveApplys")]
        public int leaveApplys(LeaveVm leaveVm)
        {
            return this.leaveApply.saveLeave(leaveVm);
        }
        [HttpGet]
        [Route("getLeaveType")]
        public List<leaveTypeVm> getLeaveType()
        {
            return this.leaveApply.GetLeaveTypes();
        }
        [HttpGet]
        [Route("getSession")]
        public List<SessionVm> getSession()
        {
            return this.leaveApply.GetSessions();
        }
        [HttpGet]
        [Route("getEmployee")]
        public List<EmployeeVm> GetEmployee()
        {
            return this.leaveApply.GetEmployees();
        }

        
    }

}
